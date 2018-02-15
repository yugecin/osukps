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
			this.buttonCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeInactiveColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeActiveColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsiReset = new System.Windows.Forms.ToolStripMenuItem();
			this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.startStopRecHotkeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.disabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsStartStopRecording = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsPlaybackRecording = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.saveKeySettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.currentConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.loadKeySetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsiAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.tsiExit = new System.Windows.Forms.ToolStripMenuItem();
			this.tmrProcess = new System.Windows.Forms.Timer(this.components);
			this.fontDialog = new System.Windows.Forms.FontDialog();
			this.noConfigurationsFoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			this.pnlKeys.Size = new System.Drawing.Size(0, 36);
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
			this.pnlInfo.MinimumSize = new System.Drawing.Size(55, 36);
			this.pnlInfo.Name = "pnlInfo";
			this.pnlInfo.Size = new System.Drawing.Size(55, 36);
			this.pnlInfo.TabIndex = 1;
			// 
			// lblTotal
			// 
			this.lblTotal.AutoSize = true;
			this.lblTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotal.ForeColor = System.Drawing.Color.White;
			this.lblTotal.Location = new System.Drawing.Point(0, 18);
			this.lblTotal.MinimumSize = new System.Drawing.Size(0, 18);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(16, 18);
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
			this.lblKps.MinimumSize = new System.Drawing.Size(0, 18);
			this.lblKps.Name = "lblKps";
			this.lblKps.Size = new System.Drawing.Size(42, 18);
			this.lblKps.TabIndex = 0;
			this.lblKps.Text = "0 kps";
			this.lblKps.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cms
			// 
			this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonCountToolStripMenuItem,
            this.changeInactiveColorToolStripMenuItem,
            this.changeActiveColorToolStripMenuItem,
            this.toolStripSeparator2,
            this.tsiReset,
            this.resetToolStripMenuItem,
            this.resetAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.startStopRecHotkeyToolStripMenuItem,
            this.cmsStartStopRecording,
            this.cmsPlaybackRecording,
            this.toolStripSeparator3,
            this.saveKeySettingsToolStripMenuItem,
            this.loadKeySetupToolStripMenuItem,
            this.toolStripSeparator5,
            this.settingsToolStripMenuItem,
            this.changeFontToolStripMenuItem,
            this.resetFontToolStripMenuItem,
            this.toolStripSeparator4,
            this.tsiAbout,
            this.tsiExit});
			this.cms.Name = "cms";
			this.cms.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.cms.ShowImageMargin = false;
			this.cms.Size = new System.Drawing.Size(156, 408);
			this.cms.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Opening);
			// 
			// buttonCountToolStripMenuItem
			// 
			this.buttonCountToolStripMenuItem.Name = "buttonCountToolStripMenuItem";
			this.buttonCountToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.buttonCountToolStripMenuItem.Text = "Button count";
			// 
			// changeInactiveColorToolStripMenuItem
			// 
			this.changeInactiveColorToolStripMenuItem.Name = "changeInactiveColorToolStripMenuItem";
			this.changeInactiveColorToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.changeInactiveColorToolStripMenuItem.Text = "Change inactive color";
			this.changeInactiveColorToolStripMenuItem.Click += new System.EventHandler(this.changeInactiveColorToolStripMenuItem_Click);
			// 
			// changeActiveColorToolStripMenuItem
			// 
			this.changeActiveColorToolStripMenuItem.Name = "changeActiveColorToolStripMenuItem";
			this.changeActiveColorToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.changeActiveColorToolStripMenuItem.Text = "Change active color";
			this.changeActiveColorToolStripMenuItem.Click += new System.EventHandler(this.changeActiveColorToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
			// 
			// tsiReset
			// 
			this.tsiReset.Name = "tsiReset";
			this.tsiReset.Size = new System.Drawing.Size(155, 22);
			this.tsiReset.Text = "Reset total keys";
			this.tsiReset.Click += new System.EventHandler(this.tsiReset_Click);
			// 
			// resetToolStripMenuItem
			// 
			this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
			this.resetToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.resetToolStripMenuItem.Text = "Reset max kps";
			this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
			// 
			// resetAllToolStripMenuItem
			// 
			this.resetAllToolStripMenuItem.Name = "resetAllToolStripMenuItem";
			this.resetAllToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.resetAllToolStripMenuItem.Text = "Reset all";
			this.resetAllToolStripMenuItem.Click += new System.EventHandler(this.resetAllToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
			// 
			// startStopRecHotkeyToolStripMenuItem
			// 
			this.startStopRecHotkeyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disabledToolStripMenuItem});
			this.startStopRecHotkeyToolStripMenuItem.Name = "startStopRecHotkeyToolStripMenuItem";
			this.startStopRecHotkeyToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.startStopRecHotkeyToolStripMenuItem.Text = "Start/Stop rec hotkey";
			// 
			// disabledToolStripMenuItem
			// 
			this.disabledToolStripMenuItem.Checked = true;
			this.disabledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.disabledToolStripMenuItem.Name = "disabledToolStripMenuItem";
			this.disabledToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.disabledToolStripMenuItem.Tag = 0;
			this.disabledToolStripMenuItem.Text = "disabled";
			this.disabledToolStripMenuItem.Click += new System.EventHandler(this.SSRHotkey_Click);
			// 
			// cmsStartStopRecording
			// 
			this.cmsStartStopRecording.Name = "cmsStartStopRecording";
			this.cmsStartStopRecording.Size = new System.Drawing.Size(155, 22);
			this.cmsStartStopRecording.Text = "Start recording";
			this.cmsStartStopRecording.Click += new System.EventHandler(this.cmsStartStopRecording_Click);
			// 
			// cmsPlaybackRecording
			// 
			this.cmsPlaybackRecording.Name = "cmsPlaybackRecording";
			this.cmsPlaybackRecording.Size = new System.Drawing.Size(155, 22);
			this.cmsPlaybackRecording.Text = "Playback recording";
			this.cmsPlaybackRecording.Click += new System.EventHandler(this.cmsPlaybackRecording_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(152, 6);
			// 
			// saveKeySettingsToolStripMenuItem
			// 
			this.saveKeySettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newConfigurationToolStripMenuItem,
            this.currentConfigurationToolStripMenuItem,
            this.toolStripSeparator6});
			this.saveKeySettingsToolStripMenuItem.Name = "saveKeySettingsToolStripMenuItem";
			this.saveKeySettingsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.saveKeySettingsToolStripMenuItem.Text = "Save Key Setup";
			this.saveKeySettingsToolStripMenuItem.Click += new System.EventHandler(this.saveKeySettingsToolStripMenuItem_Click);
			// 
			// newConfigurationToolStripMenuItem
			// 
			this.newConfigurationToolStripMenuItem.Name = "newConfigurationToolStripMenuItem";
			this.newConfigurationToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.newConfigurationToolStripMenuItem.Text = "(save as new configuration)";
			this.newConfigurationToolStripMenuItem.Click += new System.EventHandler(this.newConfigurationToolStripMenuItem_Click);
			// 
			// currentConfigurationToolStripMenuItem
			// 
			this.currentConfigurationToolStripMenuItem.Name = "currentConfigurationToolStripMenuItem";
			this.currentConfigurationToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.currentConfigurationToolStripMenuItem.Text = "osukps.ini";
			this.currentConfigurationToolStripMenuItem.Click += new System.EventHandler(this.currentConfigurationToolStripMenuItem_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(205, 6);
			// 
			// loadKeySetupToolStripMenuItem
			// 
			this.loadKeySetupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noConfigurationsFoundToolStripMenuItem});
			this.loadKeySetupToolStripMenuItem.Name = "loadKeySetupToolStripMenuItem";
			this.loadKeySetupToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.loadKeySetupToolStripMenuItem.Text = "Load Key Setup";
			this.loadKeySetupToolStripMenuItem.Click += new System.EventHandler(this.loadKeySetupToolStripMenuItem_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(152, 6);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.settingsToolStripMenuItem.Text = "Settings(Not Working)";
			this.settingsToolStripMenuItem.Visible = false;
			// 
			// changeFontToolStripMenuItem
			// 
			this.changeFontToolStripMenuItem.Name = "changeFontToolStripMenuItem";
			this.changeFontToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.changeFontToolStripMenuItem.Text = "Change font";
			this.changeFontToolStripMenuItem.Click += new System.EventHandler(this.changeFontToolStripMenuItem_Click);
			// 
			// resetFontToolStripMenuItem
			// 
			this.resetFontToolStripMenuItem.Name = "resetFontToolStripMenuItem";
			this.resetFontToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.resetFontToolStripMenuItem.Text = "Reset font";
			this.resetFontToolStripMenuItem.Click += new System.EventHandler(this.resetFontToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(152, 6);
			// 
			// tsiAbout
			// 
			this.tsiAbout.Name = "tsiAbout";
			this.tsiAbout.Size = new System.Drawing.Size(155, 22);
			this.tsiAbout.Text = "About";
			this.tsiAbout.Click += new System.EventHandler(this.tsiAbout_Click);
			// 
			// tsiExit
			// 
			this.tsiExit.Name = "tsiExit";
			this.tsiExit.Size = new System.Drawing.Size(155, 22);
			this.tsiExit.Text = "&Exit";
			this.tsiExit.Click += new System.EventHandler(this.tsiExit_Click);
			// 
			// tmrProcess
			// 
			this.tmrProcess.Enabled = true;
			this.tmrProcess.Interval = 2;
			this.tmrProcess.Tick += new System.EventHandler(this.tmrProcess_Tick);
			// 
			// noConfigurationsFoundToolStripMenuItem
			// 
			this.noConfigurationsFoundToolStripMenuItem.Enabled = false;
			this.noConfigurationsFoundToolStripMenuItem.Name = "noConfigurationsFoundToolStripMenuItem";
			this.noConfigurationsFoundToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.noConfigurationsFoundToolStripMenuItem.Text = "(no configurations found)";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Magenta;
			this.ClientSize = new System.Drawing.Size(139, 36);
			this.ContextMenuStrip = this.cms;
			this.Controls.Add(this.pnlInfo);
			this.Controls.Add(this.pnlKeys);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(0, 36);
			this.Name = "frmMain";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "osukps";
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
		private System.Windows.Forms.ToolStripMenuItem saveKeySettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadKeySetupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeInactiveColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem resetAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeActiveColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem buttonCountToolStripMenuItem;
		private System.Windows.Forms.FontDialog fontDialog;
		private System.Windows.Forms.ToolStripMenuItem changeFontToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetFontToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cmsStartStopRecording;
		private System.Windows.Forms.ToolStripMenuItem cmsPlaybackRecording;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem startStopRecHotkeyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem disabledToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem tsiAbout;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem newConfigurationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem currentConfigurationToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem noConfigurationsFoundToolStripMenuItem;
	}
}