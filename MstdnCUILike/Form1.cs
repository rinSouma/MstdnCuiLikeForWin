using Mastonet;
using Mastonet.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MstdnCUILike {
    public partial class MstdnCUILike : Form {
        private string hostName;
        private string mail;
        private string pass;
        private string clientId = Properties.Settings.Default.AppID;
        private string clientSecret = Properties.Settings.Default.AppSecret;
        private string userId = string.Empty;
        private int tootsCounter = 0;

        private TimelineStreaming streaming;
        private MastodonClient client;
        private MediaEditClass media;

        private System.Reflection.Assembly myAssembly;

        private Dictionary<string, string> shortcat;

        private int scrollPoint = int.MinValue;
        public MstdnCUILike() {
            InitializeComponent();

            // 表示領域の設定
            TimeLineView.ColumnHeadersVisible = false;
            TimeLineView.RowHeadersVisible = false;
            TimeLineView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TimeLineView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            TimeLineView.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            TimeLineView.BorderStyle = BorderStyle.None;
            TimeLineView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.myAssembly = System.Reflection.Assembly.GetExecutingAssembly();

            shortcat = new Dictionary<string, string>();
        }

        private void Form1_Shown(object sender, EventArgs e) {
            // 初期設定していない場合は設定画面を呼び出し
            if (Properties.Settings.Default.HostName == "") {
                Form2 fm2 = new Form2();
                var rtn = fm2.ShowDialog(this);
            }

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // 設定を反映
            ChangeSettings();
            SetShortcat();
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

            var account = await client.GetCurrentUser();
            this.userId = account.AccountName;

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

            // メディア処理用
            media = new MediaEditClass(ref client);

            Timer timer = new Timer();
            timer.Interval = DefaultValues.TOOTS_INTERVAL;
            timer.Tick += (object sender, EventArgs e) => {
                // トゥート回数のリセット
                tootsCounter = 0;
            };
            timer.Start();

            streaming.Start();
        }

        private void TextWrite(Status item) {
            string outputText = string.Empty;

            outputText += item.Account.DisplayName + "@" + item.Account.AccountName + "  " + item.Account.StatusesCount + "回目のトゥート" + Environment.NewLine;

            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            DateTime outTime = TimeZoneInfo.ConvertTimeFromUtc(item.CreatedAt, tzi);

            outputText += outTime.ToString("yy/MM/dd HH:mm:ss") + Environment.NewLine;

            // HTMLタグの処理
            string temp = item.Content.Replace(DefaultValues.STREAM_BR, Environment.NewLine);
            temp = temp.Replace(DefaultValues.STREAM_DOUBLEBR, Environment.NewLine + Environment.NewLine);
            string patternStr = @"<.*?>";
            string outputString = Regex.Replace(temp, patternStr, string.Empty);

            string outImage = "";
            string linkText = item.Account.ProfileUrl + "&" + item.Account.AvatarUrl +  Environment.NewLine;

            // 画像の処理
            if (item.MediaAttachments.Count() > 0) {
                if (item.Sensitive ?? false) {
                    outImage = "不適切な画像" + Environment.NewLine;
                }
                foreach (var media in item.MediaAttachments) {
                    outputString = outputString.Replace(media.TextUrl, "");
                    outImage += media.TextUrl + Environment.NewLine;
                    linkText += media.TextUrl + Environment.NewLine;
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
            //outputText += Environment.NewLine;

            // 出力
            var i = TimeLineView.Rows.Count;
            TimeLineView.Rows.Add();
            TimeLineView.Rows[i].Cells[0].Value = outputText;
            TimeLineView.Rows[i].Selected = false;

            // リンク用処理
            int start = 0;
            while (true) {
                var reg = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=@]*)?");
                var match = reg.Match(outputString, start);

                if (match.Success == true) {
                    linkText += match.Value.ToString() + Environment.NewLine;
                    start = match.Index + match.Length;
                } else {
                    break;
                }
            }
            TimeLineView.Rows[i].Cells[0].ToolTipText = linkText;

            // ステータスＩＤの保存
            TimeLineView.Rows[i].Cells[0].Tag = item.Id;

            // 行数が多いと不安定になるので古いものを削除する
            while (TimeLineView.Rows.Count > Properties.Settings.Default.MaxLine) {
                TimeLineView.Rows.RemoveAt(0);
                if(TimeLineView.FirstDisplayedScrollingRowIndex > 0) {
                    TimeLineView.FirstDisplayedScrollingRowIndex = TimeLineView.FirstDisplayedScrollingRowIndex - 1;
                    if (scrollPoint <= TimeLineView.FirstDisplayedScrollingRowIndex + 1) {
                        scrollPoint = TimeLineView.FirstDisplayedScrollingRowIndex - 2;
                    }
                }
                i--;
            }

            // スクロール位置の調整
            if (scrollPoint <= TimeLineView.FirstDisplayedScrollingRowIndex) {
                TimeLineView.FirstDisplayedScrollingRowIndex = i;
                scrollPoint = TimeLineView.FirstDisplayedScrollingRowIndex - 2;
            }

            // 特定ユーザの場合色を変える
            SetColor(i, item.Account.AccountName);

            // 入力欄にフォーカス
            InputBox.Focus();

            // 特定ワードに反応して特定ワードをトゥートする
            TootWord(outputString, item.Account.AccountName);

        }

        private void TimeLineBox_LinkClicked(object sender, LinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && (e.Modifiers & Keys.Control) == Keys.Control) {
                // 設定画面起動コマンド
                if (InputBox.Text.IndexOf(DefaultValues.CMD_SETTING) == 0) {
                    Form2 fm2 = new Form2();
                    var rtn = fm2.ShowDialog(this);

                    ChangeSettings();
                    // 終了コマンド
                } else if (InputBox.Text.IndexOf(DefaultValues.CMD_END) == 0) {
                    this.Close();
                    // 画像アップロード
                } else if (InputBox.Text.IndexOf(DefaultValues.CMD_IMAGE) == 0) {
                    PostImage();
                    // ショートカット
                } else if (InputBox.Text.IndexOf(DefaultValues.CMD_SHORTCAT) == 0) {
                    Form3 fm3 = new Form3();
                    var rtn = fm3.ShowDialog(this);

                    SetShortcat();
                } else {
                    // トゥートする
                    this.PostStatus(InputBox.Text, Visibility.Public);
                }
                InputBox.Text = "";
            } else if(e.KeyCode >= Keys.F1 && e.KeyCode <= Keys.F12) {
                ShortcatKey(e.KeyCode.ToString());
            }

            // 画像コマンドショートカット
            if (e.KeyCode == Keys.Q && (e.Modifiers & Keys.Control) == Keys.Control) {
                this.InputBox.Text = DefaultValues.IMAGE_CMD_SHORTCUT;
            }
        }

        private void ShortcatKey(string key) {
            if (shortcat.ContainsKey(key)) {
                this.InputBox.SelectedText = shortcat[key];
                this.InputBox.SelectionStart = this.InputBox.TextLength;
            }
        }

        private void InputBox_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && (e.Modifiers & Keys.Control) == Keys.Control) {
                //var status = client.PostStatus(InputBox.Text, Visibility.Public);
                //status = client.GetStatus(status.Id);
                InputBox.Text = "";
            }
        }

        private void ChangeSettings() {
            if (streaming != null) {
                streaming.Stop();
            }
            hostName = Properties.Settings.Default.HostName;
            mail = Properties.Settings.Default.UserID;
            pass = Properties.Settings.Default.UserPass;
            TimeLineView.DefaultCellStyle.Font = Properties.Settings.Default.FontSetting;
            TimeLineView.DefaultCellStyle.ForeColor = Properties.Settings.Default.FontColorSetting;
            InputBox.Font = Properties.Settings.Default.FontSetting;
            InputBox.ForeColor = Properties.Settings.Default.FontColorSetting;
            this.BackColor = Properties.Settings.Default.BackColorSetting;
            TimeLineView.BackgroundColor = Properties.Settings.Default.BackColorSetting;
            TimeLineView.DefaultCellStyle.BackColor = Properties.Settings.Default.BackColorSetting;
            TimeLineView.DefaultCellStyle.SelectionBackColor = Properties.Settings.Default.BackColorSetting;
            TimeLineView.DefaultCellStyle.SelectionForeColor = Properties.Settings.Default.FontColorSetting;
            InputBox.BackColor = Properties.Settings.Default.BackColorSetting;
            InputBox.Focus();
            Run();
        }

        // 特定ユーザの色を変える
        private void SetColor(int row, string target) {
            if(target == this.userId) {
                TimeLineView.Rows[row].Cells[0].Style.ForeColor = Properties.Settings.Default.SelfColor;
                return;
            }

            var list = Properties.Settings.Default.NameList.Split(';');
            foreach (var name in list) {
                if(name == target) {
                    TimeLineView.Rows[row].Cells[0].Style.ForeColor = Properties.Settings.Default.NameColor;
                }
            }
        }

        // 特定ワードに反応して特定ワードをトゥートする
        private void TootWord(string str, string user) {
            // 自分のトゥートには反応しない
            if(user == this.userId) {
                return;
            }

            var wordlist = Properties.Settings.Default.BaseWord.Split(';');
            var tootlist = Properties.Settings.Default.TootWord.Split(';');
            var i = 0;
            foreach (var word in wordlist) {
                if(word.Length <= 0) {
                    continue;
                }
                if(i >= tootlist.Count()) {
                    break;
                }
                if(str.IndexOf(word) >= 0) {
                    // トゥートする
                    this.PostStatus(tootlist[i], Visibility.Public);
                }
                i++;
            }
        }

        // トゥート処理
        private void PostStatus(string word, Visibility visibility, int? replyStatusId = default(int?), IEnumerable<int> mediaIds = null, bool sensitive = false, string spoilerText = null) {
            if(this.tootsCounter < DefaultValues.TOOTS_PAR_INTERVAL) {
                var status = client.PostStatus(word, visibility, replyStatusId, mediaIds, sensitive, spoilerText);
                tootsCounter++;
            }
        }

        // トゥート処理（画像）
        private async Task PostImage() {
            try {
                var mc = await media.AnalysisCommand(InputBox.Text);
                if (mc.mediaId == null) {
                    return;
                }
                this.PostStatus(mc.status, Visibility.Public, mediaIds: mc.mediaId, sensitive: mc.sensitive);
            } catch (Exception ex) {
                var i = TimeLineView.Rows.Count;
                TimeLineView.Rows.Add();
                TimeLineView.Rows[i].Cells[0].Value = ex.Message;
                TimeLineView.Rows[i].Selected = false;
                TimeLineView.Rows[i].Cells[0].Style.ForeColor = Color.Red;
            }
        }

        // 右クリック処理
        private void TimeLineView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if((e.RowIndex < 0) || (e.ColumnIndex < 0)) {
                return;
            }
            if (e.Button != MouseButtons.Right) {
                return;
            }

            var cell = this.TimeLineView[e.ColumnIndex, e.RowIndex];
            ViewContext(cell);
        }

        // コンテキストメニューを表示
        private void ViewContext(DataGridViewCell cell) {
            this.gridContextMenu.Items.Clear();
            var target = cell.ToolTipText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            try {
                // ファボ
                ToolStripItem tsif = new ToolStripMenuItem();
                tsif.Text = DefaultValues.CONTEXT_FAV;
                tsif.Tag = cell.Tag;
                tsif.MouseDown += Fav_MouseDown;
                tsif.Image = new Bitmap(this.myAssembly.GetManifestResourceStream("MstdnCUILike.Resource.fav.png"));
                this.gridContextMenu.Items.Add(tsif);

                // ブースト
                ToolStripItem tsib = new ToolStripMenuItem();
                tsib.Text = DefaultValues.CONTEXT_BOOST;
                tsib.Tag = cell.Tag;
                tsib.MouseDown += Boost_MouseDown;
                tsib.Image = new Bitmap(this.myAssembly.GetManifestResourceStream("MstdnCUILike.Resource.boost.png"));
                this.gridContextMenu.Items.Add(tsib);

                // URLの一覧
                int i = 0;
                foreach (var url in target) {
                    if (url.Length <= 0) {
                        continue;
                    }
                    // 1件目はプロフィールのURL
                    if (i == 0) {
                        var profile = url.Split('&');
                        Bitmap viewImg = null;

                        // 画像ダウンロード
                        WebClient cl = new WebClient();
                        byte[] pic = cl.DownloadData(profile[1]);
                        MemoryStream st = new MemoryStream(pic);
                        Image img = new Bitmap(st);

                        // アニメーション画像は最初の1フレームだけ取得する
                        var fd = new FrameDimension(img.FrameDimensionsList[0]);
                        int frameCount = img.GetFrameCount(fd);
                        if(frameCount > 1) {
                            img.SelectActiveFrame(fd, 0);
                        }
                        viewImg = new Bitmap(img);

                        ToolStripItem tsip = new ToolStripMenuItem();
                        tsip.Text = DefaultValues.CONTEXT_PROFILE;
                        tsip.Tag = profile[0];
                        tsip.MouseDown += Profile_MouseDown;
                        tsip.Image = viewImg;
                        this.gridContextMenu.Items.Add(tsip);
                        i = 1;
                        st.Close();
                        continue;
                    }
                    this.gridContextMenu.Items.Add(url, null, Context_Click);
                }
                if (gridContextMenu.Items.Count > 0) {
                    var point = Cursor.Position;
                    this.gridContextMenu.Show(point);
                    this.gridContextMenu.ImageScalingSize = new Size(24, 24);
                }

            } catch (Exception e) {
                return;
            }
        }

        // ファボクリック
        private void Fav_MouseDown(object sender, MouseEventArgs e) {
            var item = (ToolStripItem)sender;
            int id = 0;
            if(!int.TryParse(item.Tag.ToString(), out id)) { return; }
            client.Favourite(id);
        }

        // ブーストクリック
        private void Boost_MouseDown(object sender, MouseEventArgs e) {
            var item = (ToolStripItem)sender;
            int id = 0;
            if (!int.TryParse(item.Tag.ToString(), out id)) { return; }
            client.Reblog(id);
        }

        // Profileクリック
        private void Profile_MouseDown(object sender, MouseEventArgs e) {
            var item = (ToolStripItem)sender;
            System.Diagnostics.Process.Start(item.Tag.ToString());
        }

        // URLクリック
        private void Context_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(sender.ToString());
        }

        private void MstdnCUILike_Load(object sender, EventArgs e) {
            // ウィンドウの位置・サイズを復元
            Bounds = Properties.Settings.Default.Bounds;
            WindowState = Properties.Settings.Default.WindowState;
            splitContainer1.SplitterDistance = Properties.Settings.Default.SpliterDistance;
        }

        private void MstdnCUILike_FormClosing(object sender, FormClosingEventArgs e) {
            // ウィンドウの位置・サイズを保存
            if (WindowState == FormWindowState.Normal) {
                Properties.Settings.Default.Bounds = Bounds;
            } else {
                Properties.Settings.Default.Bounds = RestoreBounds;
            }

            Properties.Settings.Default.WindowState = WindowState;
            Properties.Settings.Default.SpliterDistance = splitContainer1.SplitterDistance;
            Properties.Settings.Default.Save();
        }

        private void SetShortcat() {
            var list = Properties.Settings.Default.Shortcat;
            shortcat.Clear();
            foreach (string str in list) {
                var item = str.Split(';');
                shortcat.Add(item[0], item[1]);
            }
        }
    }
}

