namespace MstdnCUILike {
    partial class Form2 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UserId = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.FontSetting = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.ColorSetting = new System.Windows.Forms.Button();
            this.ViewTest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ユーザーＩＤ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "パスワード";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(13, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "背景色";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(14, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "フォント";
            // 
            // UserId
            // 
            this.UserId.Location = new System.Drawing.Point(88, 9);
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(321, 19);
            this.UserId.TabIndex = 4;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(88, 47);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(321, 19);
            this.Password.TabIndex = 5;
            // 
            // FontSetting
            // 
            this.FontSetting.Location = new System.Drawing.Point(88, 134);
            this.FontSetting.Name = "FontSetting";
            this.FontSetting.Size = new System.Drawing.Size(74, 23);
            this.FontSetting.TabIndex = 7;
            this.FontSetting.Text = "設定";
            this.FontSetting.UseVisualStyleBackColor = true;
            this.FontSetting.Click += new System.EventHandler(this.FontSetting_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(334, 160);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 8;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // ColorSetting
            // 
            this.ColorSetting.Location = new System.Drawing.Point(87, 90);
            this.ColorSetting.Name = "ColorSetting";
            this.ColorSetting.Size = new System.Drawing.Size(75, 23);
            this.ColorSetting.TabIndex = 9;
            this.ColorSetting.UseVisualStyleBackColor = true;
            this.ColorSetting.Click += new System.EventHandler(this.ColorSetting_Click);
            // 
            // ViewTest
            // 
            this.ViewTest.AutoSize = true;
            this.ViewTest.Location = new System.Drawing.Point(188, 139);
            this.ViewTest.Name = "ViewTest";
            this.ViewTest.Size = new System.Drawing.Size(29, 12);
            this.ViewTest.TabIndex = 10;
            this.ViewTest.Text = "見本";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 195);
            this.Controls.Add(this.ViewTest);
            this.Controls.Add(this.ColorSetting);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.FontSetting);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.UserId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UserId;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button FontSetting;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button ColorSetting;
        private System.Windows.Forms.Label ViewTest;
    }
}