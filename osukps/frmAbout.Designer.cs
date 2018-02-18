namespace osukps {
	partial class frmAbout {
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
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.lblInfo = new System.Windows.Forms.Label();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.txtChangelog = new System.Windows.Forms.TextBox();
			this.lblDownload = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(12, 44);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(302, 22);
			this.linkLabel1.TabIndex = 0;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "https://github.com/yugecin/osukps";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FollowLink);
			// 
			// lblInfo
			// 
			this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblInfo.Location = new System.Drawing.Point(12, 9);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(302, 35);
			this.lblInfo.TabIndex = 1;
			this.lblInfo.Text = "osukps v{0} by yugecin/robin_be et al.";
			this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnUpdate
			// 
			this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUpdate.Location = new System.Drawing.Point(15, 99);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(299, 23);
			this.btnUpdate.TabIndex = 2;
			this.btnUpdate.Text = "Check for updates";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// txtChangelog
			// 
			this.txtChangelog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtChangelog.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtChangelog.Location = new System.Drawing.Point(12, 69);
			this.txtChangelog.Multiline = true;
			this.txtChangelog.Name = "txtChangelog";
			this.txtChangelog.ReadOnly = true;
			this.txtChangelog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtChangelog.Size = new System.Drawing.Size(302, 2);
			this.txtChangelog.TabIndex = 3;
			this.txtChangelog.Visible = false;
			// 
			// lblDownload
			// 
			this.lblDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDownload.Location = new System.Drawing.Point(12, 74);
			this.lblDownload.Name = "lblDownload";
			this.lblDownload.Size = new System.Drawing.Size(302, 22);
			this.lblDownload.TabIndex = 4;
			this.lblDownload.TabStop = true;
			this.lblDownload.Text = "https://github.com/yugecin/osukps/releases/tag/{0}";
			this.lblDownload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblDownload.Visible = false;
			this.lblDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FollowLink);
			// 
			// frmAbout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(326, 134);
			this.Controls.Add(this.lblDownload);
			this.Controls.Add(this.txtChangelog);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.linkLabel1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.MaximizeBox = false;
			this.Name = "frmAbout";
			this.Text = "About osukps v{0}";
			this.Load += new System.EventHandler(this.frmAbout_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.TextBox txtChangelog;
		private System.Windows.Forms.LinkLabel lblDownload;
	}
}