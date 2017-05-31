using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MstdnCUILike {
    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
            this.ControlBox = !this.ControlBox;
            if (Properties.Settings.Default.HostName == "") {
                ColorSetting.BackColor = Color.Black;
                ViewTest.ForeColor = Color.White;
                NameColorSetting.BackColor = Color.Red;
            } else {
                ColorSetting.BackColor = Properties.Settings.Default.BackColorSetting;
                ViewTest.Font = Properties.Settings.Default.FontSetting;
                ViewTest.ForeColor = Properties.Settings.Default.FontColorSetting;
                NameColorSetting.BackColor = Properties.Settings.Default.NameColor;
            }
            UserId.Text = Properties.Settings.Default.UserID;
            Password.Text = Properties.Settings.Default.UserPass;
            NameList.Text = Properties.Settings.Default.NameList;
            MaxLine.Text = Properties.Settings.Default.MaxLine.ToString();
            BaseWord.Text = Properties.Settings.Default.BaseWord;
            TootWord.Text = Properties.Settings.Default.TootWord;
        }

        private void Save_Click(object sender, EventArgs e) {
            if(UserId.Text == "" || Password.Text == "") {
                MessageBox.Show("ID/パスワード入力必須＞＜");
                return;
            }
            int maxline = 0;
            if (!int.TryParse(MaxLine.Text, out maxline)) {
                MessageBox.Show("行数は数字のみ！");
                return;
            }

            Properties.Settings.Default["BackColorSetting"] = ColorSetting.BackColor;
            Properties.Settings.Default["FontSetting"] = ViewTest.Font;
            Properties.Settings.Default["FontColorSetting"] = ViewTest.ForeColor;
            Properties.Settings.Default["UserID"] = UserId.Text;
            Properties.Settings.Default["UserPass"] = Password.Text;
            Properties.Settings.Default["HostName"] = DefaultValues.MSTDN_HOST;
            Properties.Settings.Default["NameList"] = NameList.Text;
            Properties.Settings.Default["NameColor"] = NameColorSetting.BackColor;
            Properties.Settings.Default["MaxLine"] = maxline;
            Properties.Settings.Default["BaseWord"] = BaseWord.Text;
            Properties.Settings.Default["TootWord"] = TootWord.Text;
            Properties.Settings.Default.Save();
            this.Close();

        }

        private void FontSetting_Click(object sender, EventArgs e) {
            fontDialog1.Font = ViewTest.Font;
            fontDialog1.Color = ViewTest.ForeColor;
            fontDialog1.ShowColor = true;

            DialogResult dr = fontDialog1.ShowDialog();
            if (dr == DialogResult.OK) {
                ViewTest.Font = fontDialog1.Font;
                ViewTest.ForeColor = fontDialog1.Color;
            }
        }

        private void ColorSetting_Click(object sender, EventArgs e) {
            colorDialog1.Color = ColorSetting.BackColor;
            DialogResult cd = colorDialog1.ShowDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                //選択された色の取得
                ColorSetting.BackColor = colorDialog1.Color;
            }
        }

        private void NameColorSetting_Click(object sender, EventArgs e) {
            colorDialog2.Color = NameColorSetting.BackColor;
            DialogResult cd = colorDialog2.ShowDialog();
            if (colorDialog2.ShowDialog() == DialogResult.OK) {
                //選択された色の取得
                NameColorSetting.BackColor = colorDialog2.Color;
            }
        }
    }
}
