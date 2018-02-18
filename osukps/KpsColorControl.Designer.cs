namespace osukps {
	partial class KpsColorControl {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.chkSmoothColor = new System.Windows.Forms.CheckBox();
			this.btnColor = new System.Windows.Forms.Button();
			this.nudKps = new System.Windows.Forms.NumericUpDown();
			this.btnRemove = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nudKps)).BeginInit();
			this.SuspendLayout();
			// 
			// chkSmoothColor
			// 
			this.chkSmoothColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkSmoothColor.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.chkSmoothColor.Location = new System.Drawing.Point(259, 3);
			this.chkSmoothColor.Name = "chkSmoothColor";
			this.chkSmoothColor.Size = new System.Drawing.Size(85, 21);
			this.chkSmoothColor.TabIndex = 10;
			this.chkSmoothColor.UseVisualStyleBackColor = true;
			// 
			// btnColor
			// 
			this.btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnColor.Location = new System.Drawing.Point(131, 3);
			this.btnColor.Name = "btnColor";
			this.btnColor.Size = new System.Drawing.Size(119, 21);
			this.btnColor.TabIndex = 9;
			this.btnColor.UseVisualStyleBackColor = true;
			this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
			// 
			// nudKps
			// 
			this.nudKps.Location = new System.Drawing.Point(3, 3);
			this.nudKps.Name = "nudKps";
			this.nudKps.Size = new System.Drawing.Size(119, 20);
			this.nudKps.TabIndex = 8;
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemove.Location = new System.Drawing.Point(350, 2);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(27, 23);
			this.btnRemove.TabIndex = 11;
			this.btnRemove.Text = "x";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// KpsColorControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.chkSmoothColor);
			this.Controls.Add(this.btnColor);
			this.Controls.Add(this.nudKps);
			this.Name = "KpsColorControl";
			this.Size = new System.Drawing.Size(380, 26);
			((System.ComponentModel.ISupportInitialize)(this.nudKps)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox chkSmoothColor;
		private System.Windows.Forms.Button btnColor;
		private System.Windows.Forms.NumericUpDown nudKps;
		private System.Windows.Forms.Button btnRemove;

	}
}
