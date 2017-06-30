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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MstdnCUILike));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TimeLineView = new System.Windows.Forms.DataGridView();
            this.View = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.gridContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeLineView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(4, 5);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TimeLineView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.InputBox);
            this.splitContainer1.Size = new System.Drawing.Size(398, 614);
            this.splitContainer1.SplitterDistance = 480;
            this.splitContainer1.TabIndex = 3;
            // 
            // TimeLineView
            // 
            this.TimeLineView.AllowUserToAddRows = false;
            this.TimeLineView.AllowUserToDeleteRows = false;
            this.TimeLineView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeLineView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TimeLineView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.View});
            this.TimeLineView.Location = new System.Drawing.Point(0, 0);
            this.TimeLineView.Name = "TimeLineView";
            this.TimeLineView.ReadOnly = true;
            this.TimeLineView.RowTemplate.Height = 21;
            this.TimeLineView.Size = new System.Drawing.Size(395, 472);
            this.TimeLineView.TabIndex = 0;
            this.TimeLineView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TimeLineView_CellMouseClick);
            // 
            // View
            // 
            this.View.HeaderText = "";
            this.View.Name = "View";
            this.View.ReadOnly = true;
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
            this.InputBox.MaxLength = 500;
            this.InputBox.Multiline = true;
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(395, 125);
            this.InputBox.TabIndex = 2;
            this.InputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputBox_KeyDown);
            this.InputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.InputBox_KeyUp);
            // 
            // gridContextMenu
            // 
            this.gridContextMenu.Name = "gridContextMenu";
            this.gridContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // MstdnCUILike
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(405, 622);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MstdnCUILike";
            this.Text = "MstdnCUILike";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MstdnCUILike_FormClosing);
            this.Load += new System.EventHandler(this.MstdnCUILike_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TimeLineView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.DataGridView TimeLineView;
        private System.Windows.Forms.DataGridViewTextBoxColumn View;
        private System.Windows.Forms.ContextMenuStrip gridContextMenu;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

