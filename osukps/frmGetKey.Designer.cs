namespace osukps
{
	partial class frmGetKey
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblKey = new System.Windows.Forms.Label();
			this.chkShowLabel = new System.Windows.Forms.CheckBox();
			this.txtKey = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(15, 62);
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
			this.btnCancel.Location = new System.Drawing.Point(15, 91);
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
			this.txtKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtKey.Location = new System.Drawing.Point(102, 36);
			this.txtKey.Name = "txtKey";
			this.txtKey.Size = new System.Drawing.Size(242, 20);
			this.txtKey.TabIndex = 4;
			this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// frmGetKey
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(356, 129);
			this.Controls.Add(this.txtKey);
			this.Controls.Add(this.chkShowLabel);
			this.Controls.Add(this.lblKey);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.KeyPreview = true;
			this.Name = "frmGetKey";
			this.Text = "Set key";
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
	}
}