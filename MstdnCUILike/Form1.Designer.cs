namespace MstdnCUILike {
    partial class MstdnCUILike {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.SplitContainer splitContainer1;
            this.TimeLineBox = new System.Windows.Forms.RichTextBox();
            this.InputBox = new System.Windows.Forms.TextBox();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimeLineBox
            // 
            this.TimeLineBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeLineBox.BackColor = System.Drawing.Color.Black;
            this.TimeLineBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TimeLineBox.CausesValidation = false;
            this.TimeLineBox.ForeColor = System.Drawing.SystemColors.Menu;
            this.TimeLineBox.Location = new System.Drawing.Point(0, 0);
            this.TimeLineBox.Name = "TimeLineBox";
            this.TimeLineBox.ReadOnly = true;
            this.TimeLineBox.Size = new System.Drawing.Size(398, 471);
            this.TimeLineBox.TabIndex = 1;
            this.TimeLineBox.Text = "";
            this.TimeLineBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.TimeLineBox_LinkClicked);
            // 
            // InputBox
            // 
            this.InputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputBox.BackColor = System.Drawing.Color.Black;
            this.InputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.InputBox.Location = new System.Drawing.Point(0, 2);
            this.InputBox.Multiline = true;
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(395, 125);
            this.InputBox.TabIndex = 2;
            this.InputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputBox_KeyDown);
            this.InputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.InputBox_KeyUp);
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            splitContainer1.Location = new System.Drawing.Point(4, 5);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(this.TimeLineBox);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(this.InputBox);
            splitContainer1.Size = new System.Drawing.Size(398, 614);
            splitContainer1.SplitterDistance = 480;
            splitContainer1.TabIndex = 3;
            // 
            // MstdnCUILike
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(405, 622);
            this.Controls.Add(splitContainer1);
            this.Name = "MstdnCUILike";
            this.Text = "MstdnCUILike";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).EndInit();
            splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.RichTextBox TimeLineBox;
    }
}

