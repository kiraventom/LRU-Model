namespace K_Forms2
{
    partial class MainForm
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
            this.PagesFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.PagesMockBt = new System.Windows.Forms.Button();
            this.MemoryFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.MemoryMockBt = new System.Windows.Forms.Button();
            this.MemoryL = new System.Windows.Forms.Label();
            this.PagesL = new System.Windows.Forms.Label();
            this.LogLB = new System.Windows.Forms.ListBox();
            this.HelpButton = new System.Windows.Forms.Button();
            this.PagesFLP.SuspendLayout();
            this.MemoryFLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // PagesFLP
            // 
            this.PagesFLP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PagesFLP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PagesFLP.Controls.Add(this.PagesMockBt);
            this.PagesFLP.Location = new System.Drawing.Point(13, 233);
            this.PagesFLP.Name = "PagesFLP";
            this.PagesFLP.Size = new System.Drawing.Size(762, 304);
            this.PagesFLP.TabIndex = 1;
            // 
            // PagesMockBt
            // 
            this.PagesMockBt.BackColor = System.Drawing.Color.Transparent;
            this.PagesMockBt.Enabled = false;
            this.PagesMockBt.FlatAppearance.BorderSize = 0;
            this.PagesMockBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PagesMockBt.Location = new System.Drawing.Point(3, 3);
            this.PagesMockBt.Name = "PagesMockBt";
            this.PagesMockBt.Size = new System.Drawing.Size(107, 87);
            this.PagesMockBt.TabIndex = 0;
            this.PagesMockBt.UseVisualStyleBackColor = false;
            // 
            // MemoryFLP
            // 
            this.MemoryFLP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MemoryFLP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MemoryFLP.Controls.Add(this.MemoryMockBt);
            this.MemoryFLP.Location = new System.Drawing.Point(13, 45);
            this.MemoryFLP.Name = "MemoryFLP";
            this.MemoryFLP.Size = new System.Drawing.Size(762, 108);
            this.MemoryFLP.TabIndex = 1;
            // 
            // MemoryMockBt
            // 
            this.MemoryMockBt.BackColor = System.Drawing.Color.Transparent;
            this.MemoryMockBt.Enabled = false;
            this.MemoryMockBt.FlatAppearance.BorderSize = 0;
            this.MemoryMockBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MemoryMockBt.Location = new System.Drawing.Point(3, 3);
            this.MemoryMockBt.Name = "MemoryMockBt";
            this.MemoryMockBt.Size = new System.Drawing.Size(107, 87);
            this.MemoryMockBt.TabIndex = 0;
            this.MemoryMockBt.UseVisualStyleBackColor = false;
            // 
            // MemoryL
            // 
            this.MemoryL.AutoSize = true;
            this.MemoryL.Location = new System.Drawing.Point(12, 15);
            this.MemoryL.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            this.MemoryL.Name = "MemoryL";
            this.MemoryL.Size = new System.Drawing.Size(57, 17);
            this.MemoryL.TabIndex = 2;
            this.MemoryL.Text = "Память";
            // 
            // PagesL
            // 
            this.PagesL.AutoSize = true;
            this.PagesL.Location = new System.Drawing.Point(15, 203);
            this.PagesL.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            this.PagesL.Name = "PagesL";
            this.PagesL.Size = new System.Drawing.Size(74, 17);
            this.PagesL.TabIndex = 2;
            this.PagesL.Text = "Страницы";
            // 
            // LogLB
            // 
            this.LogLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogLB.ItemHeight = 16;
            this.LogLB.Location = new System.Drawing.Point(781, 15);
            this.LogLB.Name = "LogLB";
            this.LogLB.Size = new System.Drawing.Size(237, 580);
            this.LogLB.TabIndex = 3;
            // 
            // HelpButton
            // 
            this.HelpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HelpButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.HelpButton.Location = new System.Drawing.Point(731, 543);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(44, 46);
            this.HelpButton.TabIndex = 4;
            this.HelpButton.Text = "?";
            this.HelpButton.UseVisualStyleBackColor = false;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 601);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.LogLB);
            this.Controls.Add(this.PagesL);
            this.Controls.Add(this.MemoryL);
            this.Controls.Add(this.MemoryFLP);
            this.Controls.Add(this.PagesFLP);
            this.MinimumSize = new System.Drawing.Size(868, 608);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Замещение страниц";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.PagesFLP.ResumeLayout(false);
            this.MemoryFLP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel PagesFLP;
        private System.Windows.Forms.FlowLayoutPanel MemoryFLP;
        private System.Windows.Forms.Button MemoryMockBt;
        private System.Windows.Forms.Button PagesMockBt;
        private System.Windows.Forms.Label MemoryL;
        private System.Windows.Forms.Label PagesL;
        private System.Windows.Forms.ListBox LogLB;
        private System.Windows.Forms.Button HelpButton;
    }
}

