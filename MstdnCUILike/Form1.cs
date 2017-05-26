using Mastonet;
using Mastonet.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MstdnCUILike {
    public partial class MstdnCUILike : Form {
        private string hostName;
        private string mail;
        private string pass;
        private string clientId = Properties.Settings.Default.AppID;
        private string clientSecret = Properties.Settings.Default.AppSecret;

        private TimelineStreaming streaming;
        private MastodonClient client;

        public MstdnCUILike() {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e) {
            // 初期設定していない場合は設定画面を呼び出し
            if(Properties.Settings.Default.HostName == "") {
                Form2 fm2 = new Form2();
                var rtn = fm2.ShowDialog(this);
            }

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // 設定を反映
            ChangeSettings();
        }

        private async Task Run() {
            Dictionary<string, string> uri_list = new Dictionary<string, string>();

            var appRegistration = new AppRegistration {
                Instance = hostName,
                ClientId = clientId,
                ClientSecret = clientSecret,
                Scope = Scope.Read | Scope.Write
            };
            var authClient = new AuthenticationClient(appRegistration);

            var auth = await authClient.ConnectWithPassword(mail, pass);

            client = new MastodonClient(appRegistration, auth);

            streaming = client.GetPublicStreaming();
            streaming.OnUpdate += (sender, e) => {
                // 自インスタンスのみを表示の対象にする
                var uri = e.Status.Uri;
                var temp = uri.Split(',');
                uri_list.Clear();
                foreach (var word in temp) {
                    var temp2 = word.Split(':');
                    if (temp2.Length >= 2) {
                        uri_list.Add(temp2[0], temp2[1]);
                    }
                }
                if (uri_list.ContainsKey(DefaultValues.STREAM_TAG)) {
                    if (uri_list[DefaultValues.STREAM_TAG] == hostName) {
                        TextWrite(e.Status);
                    }
                }
            };

            streaming.Start();
        }

        private void TextWrite(Status item) {
            string outputText = string.Empty;

            // スクロール位置の判定
            TimeLineBox.Focus();
            var scrollFlg = GetScrollPosition.IsScrollBarEnd(TimeLineBox.Handle, GetScrollPosition.ScrollBarKind.Vertical, TimeLineBox.Height);
            var point = GetScrollPosition.GetPoint(TimeLineBox.Handle);

            outputText += item.Account.DisplayName + "@" + item.Account.AccountName + "  " + item.Account.StatusesCount + "回目のトゥート" + Environment.NewLine;

            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            DateTime outTime = TimeZoneInfo.ConvertTimeFromUtc(item.CreatedAt, tzi);

            outputText += outTime.ToString("yy/MM/dd HH:mm:ss") + Environment.NewLine;

            // HTMLタグの処理
            string temp = item.Content.Replace(DefaultValues.STREAM_BR, Environment.NewLine);
            string patternStr = @"<.*?>";
            string outputString = Regex.Replace(temp, patternStr, string.Empty);

            string outImage = "";

            // 画像の処理
            if (item.MediaAttachments.Count() > 0) {
                if (item.Sensitive ?? true) {
                    outImage = "不適切な画像" + Environment.NewLine;
                }
                foreach (var media in item.MediaAttachments) {
                    outputString = outputString.Replace(media.TextUrl, "");
                    outImage += media.TextUrl + Environment.NewLine;
                }
            }

            // HTMLデコード
            outputString = WebUtility.HtmlDecode(outputString);

            if (item.SpoilerText != "") {
                outputText += item.SpoilerText + Environment.NewLine;
                outputText += "非表示のテキスト：" + outputString + Environment.NewLine;
            } else {
                outputText += outputString + Environment.NewLine;
            }
            if (outImage != "") {
                outputText += outImage + Environment.NewLine;
            }
            outputText += Environment.NewLine;

            // 出力
            TimeLineBox.Select(TimeLineBox.TextLength, 0);
            TimeLineBox.SelectedText = outputText;

            // 行数が多いと不安定になるので古いものを削除する
            while (TimeLineBox.GetLineFromCharIndex(TimeLineBox.TextLength) > Properties.Settings.Default.MaxLine) {
                List<string> lines = new List<string>(TimeLineBox.Lines);
                lines.RemoveAt(0);
                TimeLineBox.Text = String.Join(Environment.NewLine, lines);
            }

            SetColor(0);

            // スクロール
            if (scrollFlg) {
                TimeLineBox.SelectionStart = TimeLineBox.Text.Length;
                TimeLineBox.Focus();
                TimeLineBox.ScrollToCaret();
            } else {
                TimeLineBox.Focus();
                GetScrollPosition.SetPoint(TimeLineBox.Handle, point);
            }
            InputBox.Focus();
        }

        private void TimeLineBox_LinkClicked(object sender, LinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter && (e.Modifiers & Keys.Control) == Keys.Control) {
                // 設定画面起動コマンド
                if (InputBox.Text.IndexOf(DefaultValues.CMD_SETTING) == 0) {
                    Form2 fm2 = new Form2();
                    var rtn = fm2.ShowDialog(this);

                    ChangeSettings();
                // 終了コマンド
                }else if (InputBox.Text.IndexOf(DefaultValues.CMD_END) == 0) {
                    this.Close();
                } else {
                    // トゥートする
                    var status = client.PostStatus(InputBox.Text, Visibility.Public);
                }
                InputBox.Text = "";
            }
        }

        private void InputBox_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && (e.Modifiers & Keys.Control) == Keys.Control) {
                var status = client.PostStatus(InputBox.Text, Visibility.Public);
                status = client.GetStatus(status.Id);
                InputBox.Text = "";
            }
        }

        private void ChangeSettings() {
            if(streaming != null) {
                streaming.Stop();
            }
            hostName = Properties.Settings.Default.HostName;
            mail = Properties.Settings.Default.UserID;
            pass = Properties.Settings.Default.UserPass;
            TimeLineBox.Font = Properties.Settings.Default.FontSetting;
            TimeLineBox.ForeColor = Properties.Settings.Default.FontColorSetting;
            InputBox.Font = Properties.Settings.Default.FontSetting;
            InputBox.ForeColor = Properties.Settings.Default.FontColorSetting;
            this.BackColor = Properties.Settings.Default.BackColorSetting;
            TimeLineBox.BackColor = Properties.Settings.Default.BackColorSetting;
            InputBox.BackColor = Properties.Settings.Default.BackColorSetting;
            InputBox.Focus();
            Run();
        }

        // 特定ユーザのNameの色を変える
        private void SetColor(int start) {
            var list = Properties.Settings.Default.NameList.Split(';');
            foreach(var name in list) {
                var target = "@" + name + " ";
                int cnt = start - 1;
                while (true) {
                    cnt = TimeLineBox.Find(target, cnt + 1, RichTextBoxFinds.MatchCase);
                    if (cnt >= 0) {
                        TimeLineBox.SelectionStart = cnt;
                        TimeLineBox.SelectionLength = name.Length + 1;
                        TimeLineBox.SelectionColor = Properties.Settings.Default.NameColor;
                    } else {
                        break;
                    }
                }
            }
        }
    }
}

