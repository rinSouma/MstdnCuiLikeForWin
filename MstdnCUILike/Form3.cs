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
    public partial class Form3 : Form {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        int selectedIndex = 0;
        string selectItem = "";
        bool flg = false;

        public Form3() {
            InitializeComponent();

            var shortcat = Properties.Settings.Default.Shortcat;
            int i = 0;
            foreach (string str in shortcat) {
                var item = str.Split(';');
                dic.Add(item[0], item[1]);
                SelectList.Items.Add(item[0]);
                if(i == 0) {
                    InputArea.Text = item[1];
                }
                i++;
            }
            SelectList.SelectedIndex = 0;
            selectItem = SelectList.SelectedItem.ToString();
            flg = true;
        }

        private void button1_Click(object sender, EventArgs e) {
            System.Collections.Specialized.StringCollection sc = new System.Collections.Specialized.StringCollection();
            foreach (var list in dic) {
                sc.Add(list.Key + ";" + list.Value);
            }
            Properties.Settings.Default.Shortcat = sc;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void SelectList_SelectedIndexChanged(object sender, EventArgs e) {
            if (!flg) {
                return;
            }
            SetText(selectItem);
            selectItem = SelectList.SelectedItem.ToString();
            GetText(selectItem);
        }

        private void SetText(string str) {
            dic[str] = InputArea.Text;
        }

        private void GetText(string str) {
            InputArea.Text = dic[str];
        }
    }
}
