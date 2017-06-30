namespace MstdnCUILike {
    partial class Form3 {
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
            this.InputArea = new System.Windows.Forms.RichTextBox();
            this.SelectList = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InputArea
            // 
            this.InputArea.Location = new System.Drawing.Point(12, 57);
            this.InputArea.Name = "InputArea";
            this.InputArea.Size = new System.Drawing.Size(304, 84);
            this.InputArea.TabIndex = 13;
            this.InputArea.Text = "";
            // 
            // SelectList
            // 
            this.SelectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectList.FormattingEnabled = true;
            this.SelectList.Location = new System.Drawing.Point(12, 12);
            this.SelectList.Name = "SelectList";
            this.SelectList.Size = new System.Drawing.Size(121, 20);
            this.SelectList.TabIndex = 14;
            this.SelectList.SelectedIndexChanged += new System.EventHandler(this.SelectList_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(244, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 211);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SelectList);
            this.Controls.Add(this.InputArea);
            this.Name = "Form3";
            this.Text = "定型文";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox InputArea;
        private System.Windows.Forms.ComboBox SelectList;
        private System.Windows.Forms.Button button1;
    }
}