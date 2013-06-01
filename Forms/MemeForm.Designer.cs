namespace mxplx.Forms
{
    partial class MemeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemeForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.memeQuote = new System.Windows.Forms.Label();
            this.memeText = new System.Windows.Forms.Label();
            this.memeTitle = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.MemeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(604, 329);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.tabPage1.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.tabPage1.BackColor = System.Drawing.Color.Lavender;
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(596, 303);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Meme";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.memeQuote, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.memeText, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.memeTitle, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.MaximumSize = new System.Drawing.Size(570, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(570, 77);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // memeQuote
            // 
            this.memeQuote.AutoEllipsis = true;
            this.memeQuote.AutoSize = true;
            this.memeQuote.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memeQuote.Location = new System.Drawing.Point(4, 51);
            this.memeQuote.MinimumSize = new System.Drawing.Size(565, 0);
            this.memeQuote.Name = "memeQuote";
            this.memeQuote.Size = new System.Drawing.Size(565, 25);
            this.memeQuote.TabIndex = 3;
            this.memeQuote.Text = "Quote";
            this.memeQuote.Click += new System.EventHandler(this.memeQuote_Click);
            // 
            // memeText
            // 
            this.memeText.AutoEllipsis = true;
            this.memeText.AutoSize = true;
            this.memeText.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memeText.Location = new System.Drawing.Point(4, 27);
            this.memeText.MaximumSize = new System.Drawing.Size(570, 0);
            this.memeText.Name = "memeText";
            this.memeText.Size = new System.Drawing.Size(49, 23);
            this.memeText.TabIndex = 4;
            this.memeText.Text = "Text";
            // 
            // memeTitle
            // 
            this.memeTitle.AutoEllipsis = true;
            this.memeTitle.AutoSize = true;
            this.memeTitle.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memeTitle.Location = new System.Drawing.Point(4, 1);
            this.memeTitle.MaximumSize = new System.Drawing.Size(570, 0);
            this.memeTitle.Name = "memeTitle";
            this.memeTitle.Size = new System.Drawing.Size(64, 25);
            this.memeTitle.TabIndex = 5;
            this.memeTitle.Text = "Title";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(596, 303);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reference";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MemeLinkLabel
            // 
            this.MemeLinkLabel.AutoSize = true;
            this.MemeLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.MemeLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemeLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.MemeLinkLabel.Location = new System.Drawing.Point(13, 347);
            this.MemeLinkLabel.Name = "MemeLinkLabel";
            this.MemeLinkLabel.Size = new System.Drawing.Size(91, 20);
            this.MemeLinkLabel.TabIndex = 3;
            this.MemeLinkLabel.TabStop = true;
            this.MemeLinkLabel.Text = "mxplx.com";
            this.MemeLinkLabel.VisitedLinkColor = System.Drawing.Color.LavenderBlush;
            this.MemeLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MemeLinkLabel_LinkClicked);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(535, 344);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MemeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(629, 369);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.MemeLinkLabel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MemeForm";
            this.Text = "Meme";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button CloseButton;
        public System.Windows.Forms.LinkLabel MemeLinkLabel;
        public System.Windows.Forms.Label memeTitle;
        public System.Windows.Forms.Label memeQuote;
        public System.Windows.Forms.Label memeText;
    }
}