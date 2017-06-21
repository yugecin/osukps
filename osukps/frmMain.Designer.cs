namespace osukps {
	partial class frmMain {
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
            this.components = new System.ComponentModel.Container();
            this.pnlKeys = new System.Windows.Forms.Panel();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblKps = new System.Windows.Forms.Label();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsiAddButton = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiRemoveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.changeInactiveColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeActiveColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsiReset = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveKeySettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadKeySetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrProcess = new System.Windows.Forms.Timer(this.components);
            this.hideAddButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlInfo.SuspendLayout();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlKeys
            // 
            this.pnlKeys.AutoSize = true;
            this.pnlKeys.BackColor = System.Drawing.Color.Black;
            this.pnlKeys.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKeys.Location = new System.Drawing.Point(0, 0);
            this.pnlKeys.Name = "pnlKeys";
            this.pnlKeys.Size = new System.Drawing.Size(0, 33);
            this.pnlKeys.TabIndex = 0;
            // 
            // pnlInfo
            // 
            this.pnlInfo.AutoSize = true;
            this.pnlInfo.BackColor = System.Drawing.Color.Black;
            this.pnlInfo.Controls.Add(this.lblTotal);
            this.pnlInfo.Controls.Add(this.lblKps);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.MinimumSize = new System.Drawing.Size(64, 33);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(64, 33);
            this.pnlInfo.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(0, 17);
            this.lblTotal.MinimumSize = new System.Drawing.Size(0, 17);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(16, 17);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKps
            // 
            this.lblKps.AutoSize = true;
            this.lblKps.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKps.ForeColor = System.Drawing.Color.White;
            this.lblKps.Location = new System.Drawing.Point(0, 0);
            this.lblKps.MinimumSize = new System.Drawing.Size(0, 17);
            this.lblKps.Name = "lblKps";
            this.lblKps.Size = new System.Drawing.Size(42, 17);
            this.lblKps.TabIndex = 0;
            this.lblKps.Text = "0 kps";
            this.lblKps.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiAddButton,
            this.tsiRemoveButton,
            this.changeInactiveColorToolStripMenuItem,
            this.changeActiveColorToolStripMenuItem,
            this.hideAddButtonToolStripMenuItem,
            this.toolStripSeparator2,
            this.tsiReset,
            this.resetToolStripMenuItem,
            this.resetAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveKeySettingsToolStripMenuItem,
            this.loadKeySetupToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.tsiExit});
            this.cms.Name = "cms";
            this.cms.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cms.ShowImageMargin = false;
            this.cms.Size = new System.Drawing.Size(170, 302);
            // 
            // tsiAddButton
            // 
            this.tsiAddButton.Name = "tsiAddButton";
            this.tsiAddButton.Size = new System.Drawing.Size(169, 22);
            this.tsiAddButton.Text = "Add button";
            this.tsiAddButton.Click += new System.EventHandler(this.tsiAddButton_Click);
            // 
            // tsiRemoveButton
            // 
            this.tsiRemoveButton.Name = "tsiRemoveButton";
            this.tsiRemoveButton.Size = new System.Drawing.Size(169, 22);
            this.tsiRemoveButton.Text = "Remove button";
            this.tsiRemoveButton.Click += new System.EventHandler(this.tsiRemoveButton_Click);
            // 
            // changeInactiveColorToolStripMenuItem
            // 
            this.changeInactiveColorToolStripMenuItem.Name = "changeInactiveColorToolStripMenuItem";
            this.changeInactiveColorToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.changeInactiveColorToolStripMenuItem.Text = "Change inactive color";
            this.changeInactiveColorToolStripMenuItem.Click += new System.EventHandler(this.changeInactiveColorToolStripMenuItem_Click);
            // 
            // changeActiveColorToolStripMenuItem
            // 
            this.changeActiveColorToolStripMenuItem.Name = "changeActiveColorToolStripMenuItem";
            this.changeActiveColorToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.changeActiveColorToolStripMenuItem.Text = "Change active color";
            this.changeActiveColorToolStripMenuItem.Click += new System.EventHandler(this.changeActiveColorToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(166, 6);
            // 
            // tsiReset
            // 
            this.tsiReset.Name = "tsiReset";
            this.tsiReset.Size = new System.Drawing.Size(169, 22);
            this.tsiReset.Text = "Reset total keys";
            this.tsiReset.Click += new System.EventHandler(this.tsiReset_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.resetToolStripMenuItem.Text = "Reset max kps";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // resetAllToolStripMenuItem
            // 
            this.resetAllToolStripMenuItem.Name = "resetAllToolStripMenuItem";
            this.resetAllToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.resetAllToolStripMenuItem.Text = "Reset all";
            this.resetAllToolStripMenuItem.Click += new System.EventHandler(this.resetAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // saveKeySettingsToolStripMenuItem
            // 
            this.saveKeySettingsToolStripMenuItem.Name = "saveKeySettingsToolStripMenuItem";
            this.saveKeySettingsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveKeySettingsToolStripMenuItem.Text = "Save Key Setup";
            this.saveKeySettingsToolStripMenuItem.Click += new System.EventHandler(this.saveKeySettingsToolStripMenuItem_Click);
            // 
            // loadKeySetupToolStripMenuItem
            // 
            this.loadKeySetupToolStripMenuItem.Name = "loadKeySetupToolStripMenuItem";
            this.loadKeySetupToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.loadKeySetupToolStripMenuItem.Text = "Load Key Setup";
            this.loadKeySetupToolStripMenuItem.Click += new System.EventHandler(this.loadKeySetupToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.settingsToolStripMenuItem.Text = "Settings(Not Working)";
            // 
            // tsiExit
            // 
            this.tsiExit.Name = "tsiExit";
            this.tsiExit.Size = new System.Drawing.Size(169, 22);
            this.tsiExit.Text = "&Exit";
            this.tsiExit.Click += new System.EventHandler(this.tsiExit_Click);
            // 
            // tmrProcess
            // 
            this.tmrProcess.Enabled = true;
            this.tmrProcess.Interval = 5;
            this.tmrProcess.Tick += new System.EventHandler(this.tmrProcess_Tick);
            // 
            // hideAddButtonToolStripMenuItem
            // 
            this.hideAddButtonToolStripMenuItem.Name = "hideAddButtonToolStripMenuItem";
            this.hideAddButtonToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.hideAddButtonToolStripMenuItem.Text = "Hide Add button";
            this.hideAddButtonToolStripMenuItem.Click += new System.EventHandler(this.hideAddButtonToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Magenta;
            this.ClientSize = new System.Drawing.Size(162, 33);
            this.ContextMenuStrip = this.cms;
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlKeys);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(0, 33);
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlKeys;
		private System.Windows.Forms.Panel pnlInfo;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label lblKps;
		private System.Windows.Forms.ContextMenuStrip cms;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem tsiExit;
		private System.Windows.Forms.ToolStripMenuItem tsiReset;
		private System.Windows.Forms.Timer tmrProcess;
		private System.Windows.Forms.ToolStripMenuItem tsiAddButton;
		private System.Windows.Forms.ToolStripMenuItem tsiRemoveButton;
		private System.Windows.Forms.ToolStripMenuItem saveKeySettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadKeySetupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeInactiveColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem resetAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeActiveColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideAddButtonToolStripMenuItem;
    }
}