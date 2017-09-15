namespace osukps {
	partial class frmGetKey {
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
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblKey = new System.Windows.Forms.Label();
			this.chkShowLabel = new System.Windows.Forms.CheckBox();
			this.txtKey = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnColActive = new System.Windows.Forms.Button();
			this.btnColInactive = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(15, 95);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(329, 23);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(15, 124);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(329, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblKey
			// 
			this.lblKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblKey.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblKey.Location = new System.Drawing.Point(12, 9);
			this.lblKey.Name = "lblKey";
			this.lblKey.Size = new System.Drawing.Size(332, 26);
			this.lblKey.TabIndex = 2;
			this.lblKey.Text = "[Press a key]";
			this.lblKey.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// chkShowLabel
			// 
			this.chkShowLabel.AutoSize = true;
			this.chkShowLabel.Checked = true;
			this.chkShowLabel.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkShowLabel.Location = new System.Drawing.Point(15, 38);
			this.chkShowLabel.Name = "chkShowLabel";
			this.chkShowLabel.Size = new System.Drawing.Size(81, 17);
			this.chkShowLabel.TabIndex = 3;
			this.chkShowLabel.Text = "Show label:";
			this.chkShowLabel.UseVisualStyleBackColor = true;
			// 
			// txtKey
			// 
			this.txtKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtKey.Location = new System.Drawing.Point(102, 36);
			this.txtKey.Name = "txtKey";
			this.txtKey.Size = new System.Drawing.Size(242, 20);
			this.txtKey.TabIndex = 4;
			this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(163, 68);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Colors";
			// 
			// btnColActive
			// 
			this.btnColActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnColActive.Location = new System.Drawing.Point(205, 63);
			this.btnColActive.Name = "btnColActive";
			this.btnColActive.Size = new System.Drawing.Size(139, 23);
			this.btnColActive.TabIndex = 7;
			this.btnColActive.UseVisualStyleBackColor = true;
			this.btnColActive.Click += new System.EventHandler(this.btnColActive_Click);
			// 
			// btnColInactive
			// 
			this.btnColInactive.Location = new System.Drawing.Point(15, 63);
			this.btnColInactive.Name = "btnColInactive";
			this.btnColInactive.Size = new System.Drawing.Size(142, 23);
			this.btnColInactive.TabIndex = 8;
			this.btnColInactive.UseVisualStyleBackColor = true;
			this.btnColInactive.Click += new System.EventHandler(this.btnColInactive_Click);
			// 
			// frmGetKey
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(356, 162);
			this.Controls.Add(this.btnColInactive);
			this.Controls.Add(this.btnColActive);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtKey);
			this.Controls.Add(this.chkShowLabel);
			this.Controls.Add(this.lblKey);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(362, 184);
			this.Name = "frmGetKey";
			this.Text = "osukps - key config";
			this.Load += new System.EventHandler(this.frmGetKey_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmGetKey_KeyUp);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblKey;
		private System.Windows.Forms.CheckBox chkShowLabel;
		private System.Windows.Forms.TextBox txtKey;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnColActive;
		private System.Windows.Forms.Button btnColInactive;
	}
}