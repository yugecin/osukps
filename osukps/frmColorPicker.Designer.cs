namespace osukps {
	partial class frmColorPicker {
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
			this.rscroll = new System.Windows.Forms.HScrollBar();
			this.gscroll = new System.Windows.Forms.HScrollBar();
			this.bscroll = new System.Windows.Forms.HScrollBar();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.preview = new System.Windows.Forms.Label();
			this.rnum = new System.Windows.Forms.NumericUpDown();
			this.gnum = new System.Windows.Forms.NumericUpDown();
			this.bnum = new System.Windows.Forms.NumericUpDown();
			this.txtHex = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.rnum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gnum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bnum)).BeginInit();
			this.SuspendLayout();
			// 
			// rscroll
			// 
			this.rscroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rscroll.Location = new System.Drawing.Point(101, 9);
			this.rscroll.Maximum = 255;
			this.rscroll.Name = "rscroll";
			this.rscroll.Size = new System.Drawing.Size(304, 16);
			this.rscroll.TabIndex = 0;
			this.rscroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.rscroll_Scroll);
			// 
			// gscroll
			// 
			this.gscroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gscroll.Location = new System.Drawing.Point(101, 35);
			this.gscroll.Maximum = 255;
			this.gscroll.Name = "gscroll";
			this.gscroll.Size = new System.Drawing.Size(304, 16);
			this.gscroll.TabIndex = 0;
			this.gscroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gscroll_Scroll);
			// 
			// bscroll
			// 
			this.bscroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bscroll.Location = new System.Drawing.Point(101, 61);
			this.bscroll.Maximum = 255;
			this.bscroll.Name = "bscroll";
			this.bscroll.Size = new System.Drawing.Size(304, 16);
			this.bscroll.TabIndex = 0;
			this.bscroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.bscroll_Scroll);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(12, 143);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(393, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(12, 114);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(393, 23);
			this.btnOk.TabIndex = 5;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// preview
			// 
			this.preview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.preview.Location = new System.Drawing.Point(101, 88);
			this.preview.Name = "preview";
			this.preview.Size = new System.Drawing.Size(304, 23);
			this.preview.TabIndex = 5;
			// 
			// rnum
			// 
			this.rnum.Location = new System.Drawing.Point(12, 9);
			this.rnum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.rnum.Name = "rnum";
			this.rnum.Size = new System.Drawing.Size(86, 21);
			this.rnum.TabIndex = 1;
			this.rnum.ValueChanged += new System.EventHandler(this.rnum_ValueChanged);
			// 
			// gnum
			// 
			this.gnum.Location = new System.Drawing.Point(12, 35);
			this.gnum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.gnum.Name = "gnum";
			this.gnum.Size = new System.Drawing.Size(86, 21);
			this.gnum.TabIndex = 2;
			this.gnum.ValueChanged += new System.EventHandler(this.gnum_ValueChanged);
			// 
			// bnum
			// 
			this.bnum.Location = new System.Drawing.Point(12, 61);
			this.bnum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.bnum.Name = "bnum";
			this.bnum.Size = new System.Drawing.Size(86, 21);
			this.bnum.TabIndex = 3;
			this.bnum.ValueChanged += new System.EventHandler(this.bnum_ValueChanged);
			// 
			// txtHex
			// 
			this.txtHex.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtHex.Location = new System.Drawing.Point(12, 91);
			this.txtHex.Name = "txtHex";
			this.txtHex.Size = new System.Drawing.Size(86, 20);
			this.txtHex.TabIndex = 4;
			this.txtHex.Text = "000000";
			this.txtHex.TextChanged += new System.EventHandler(this.txtHex_TextChanged);
			// 
			// frmColorPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(417, 178);
			this.Controls.Add(this.txtHex);
			this.Controls.Add(this.bnum);
			this.Controls.Add(this.gnum);
			this.Controls.Add(this.rnum);
			this.Controls.Add(this.preview);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.bscroll);
			this.Controls.Add(this.gscroll);
			this.Controls.Add(this.rscroll);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmColorPicker";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "osukps - colorpicker";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.frmColorPicker_Load);
			((System.ComponentModel.ISupportInitialize)(this.rnum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gnum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bnum)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.HScrollBar rscroll;
		private System.Windows.Forms.HScrollBar gscroll;
		private System.Windows.Forms.HScrollBar bscroll;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label preview;
		private System.Windows.Forms.NumericUpDown rnum;
		private System.Windows.Forms.NumericUpDown gnum;
		private System.Windows.Forms.NumericUpDown bnum;
		private System.Windows.Forms.TextBox txtHex;
	}
}