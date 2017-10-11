namespace ABPlayer
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.monoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.jumpForwardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.minuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpBackwardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.secondsToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.minuteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showArtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.hideAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkArtPlaying = new System.Windows.Forms.CheckBox();
            this.pBoxArt = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlPlayerControls = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tBarVol = new System.Windows.Forms.TrackBar();
            this.lblVol = new System.Windows.Forms.Label();
            this.btnPausePlay = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.fileList = new ABPlayer.ABListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scrubber1 = new ABPlayer.Scrubber();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxArt)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlPlayerControls.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarVol)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(930, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openFolderToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.channelsToolStripMenuItem,
            this.speedToolStripMenuItem,
            this.toolStripSeparator2,
            this.jumpForwardsToolStripMenuItem,
            this.jumpBackwardsToolStripMenuItem,
            this.jumpToToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // channelsToolStripMenuItem
            // 
            this.channelsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.monoToolStripMenuItem});
            this.channelsToolStripMenuItem.Name = "channelsToolStripMenuItem";
            this.channelsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.channelsToolStripMenuItem.Text = "Channels";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Checked = true;
            this.toolStripMenuItem1.CheckOnClick = true;
            this.toolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Stereo";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // monoToolStripMenuItem
            // 
            this.monoToolStripMenuItem.CheckOnClick = true;
            this.monoToolStripMenuItem.Name = "monoToolStripMenuItem";
            this.monoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.monoToolStripMenuItem.Text = "Mono";
            this.monoToolStripMenuItem.Click += new System.EventHandler(this.monoToolStripMenuItem_Click);
            // 
            // speedToolStripMenuItem
            // 
            this.speedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.speedToolStripMenuItem.Name = "speedToolStripMenuItem";
            this.speedToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.speedToolStripMenuItem.Text = "Speed";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem3.Text = "+0.05";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem4.Text = "+0.2";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem5.Text = "-0.05";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem6.Text = "-0.2";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // jumpForwardsToolStripMenuItem
            // 
            this.jumpForwardsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.secondsToolStripMenuItem,
            this.secondsToolStripMenuItem1,
            this.minuteToolStripMenuItem,
            this.minutesToolStripMenuItem1});
            this.jumpForwardsToolStripMenuItem.Name = "jumpForwardsToolStripMenuItem";
            this.jumpForwardsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.jumpForwardsToolStripMenuItem.Text = "Jump Forwards";
            // 
            // secondsToolStripMenuItem
            // 
            this.secondsToolStripMenuItem.Name = "secondsToolStripMenuItem";
            this.secondsToolStripMenuItem.ShortcutKeyDisplayString = "Right";
            this.secondsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.secondsToolStripMenuItem.Text = "10 Seconds";
            this.secondsToolStripMenuItem.Click += new System.EventHandler(this.secondsToolStripMenuItem_Click);
            // 
            // secondsToolStripMenuItem1
            // 
            this.secondsToolStripMenuItem1.Name = "secondsToolStripMenuItem1";
            this.secondsToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.secondsToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.secondsToolStripMenuItem1.Text = "30 Seconds";
            this.secondsToolStripMenuItem1.Click += new System.EventHandler(this.secondsToolStripMenuItem1_Click);
            // 
            // minuteToolStripMenuItem
            // 
            this.minuteToolStripMenuItem.Name = "minuteToolStripMenuItem";
            this.minuteToolStripMenuItem.ShortcutKeyDisplayString = "Shift+Right";
            this.minuteToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.minuteToolStripMenuItem.Text = "1 Minute";
            this.minuteToolStripMenuItem.Click += new System.EventHandler(this.minuteToolStripMenuItem_Click);
            // 
            // minutesToolStripMenuItem1
            // 
            this.minutesToolStripMenuItem1.Name = "minutesToolStripMenuItem1";
            this.minutesToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Right)));
            this.minutesToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.minutesToolStripMenuItem1.Text = "5 Minutes";
            this.minutesToolStripMenuItem1.Click += new System.EventHandler(this.minutesToolStripMenuItem1_Click);
            // 
            // jumpBackwardsToolStripMenuItem
            // 
            this.jumpBackwardsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.secondsToolStripMenuItem2,
            this.secondsToolStripMenuItem3,
            this.minuteToolStripMenuItem1,
            this.minutesToolStripMenuItem});
            this.jumpBackwardsToolStripMenuItem.Name = "jumpBackwardsToolStripMenuItem";
            this.jumpBackwardsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.jumpBackwardsToolStripMenuItem.Text = "Jump Backwards";
            // 
            // secondsToolStripMenuItem2
            // 
            this.secondsToolStripMenuItem2.Name = "secondsToolStripMenuItem2";
            this.secondsToolStripMenuItem2.ShortcutKeyDisplayString = "Left";
            this.secondsToolStripMenuItem2.Size = new System.Drawing.Size(187, 22);
            this.secondsToolStripMenuItem2.Text = "10 Seconds";
            this.secondsToolStripMenuItem2.Click += new System.EventHandler(this.secondsToolStripMenuItem2_Click);
            // 
            // secondsToolStripMenuItem3
            // 
            this.secondsToolStripMenuItem3.Name = "secondsToolStripMenuItem3";
            this.secondsToolStripMenuItem3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.secondsToolStripMenuItem3.Size = new System.Drawing.Size(187, 22);
            this.secondsToolStripMenuItem3.Text = "30 Seconds";
            this.secondsToolStripMenuItem3.Click += new System.EventHandler(this.secondsToolStripMenuItem3_Click);
            // 
            // minuteToolStripMenuItem1
            // 
            this.minuteToolStripMenuItem1.Name = "minuteToolStripMenuItem1";
            this.minuteToolStripMenuItem1.ShortcutKeyDisplayString = "Shift+Left";
            this.minuteToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.minuteToolStripMenuItem1.Text = "1 Minute";
            this.minuteToolStripMenuItem1.Click += new System.EventHandler(this.minuteToolStripMenuItem1_Click);
            // 
            // minutesToolStripMenuItem
            // 
            this.minutesToolStripMenuItem.Name = "minutesToolStripMenuItem";
            this.minutesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Left)));
            this.minutesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.minutesToolStripMenuItem.Text = "5 Minutes";
            this.minutesToolStripMenuItem.Click += new System.EventHandler(this.minutesToolStripMenuItem_Click);
            // 
            // jumpToToolStripMenuItem
            // 
            this.jumpToToolStripMenuItem.Name = "jumpToToolStripMenuItem";
            this.jumpToToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.jumpToToolStripMenuItem.Text = "Jump To";
            this.jumpToToolStripMenuItem.Click += new System.EventHandler(this.jumpToToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showArtToolStripMenuItem,
            this.showFilesToolStripMenuItem,
            this.showControlsToolStripMenuItem,
            this.toolStripSeparator3,
            this.hideAllToolStripMenuItem,
            this.showAllToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showArtToolStripMenuItem
            // 
            this.showArtToolStripMenuItem.Checked = true;
            this.showArtToolStripMenuItem.CheckOnClick = true;
            this.showArtToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showArtToolStripMenuItem.Name = "showArtToolStripMenuItem";
            this.showArtToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.showArtToolStripMenuItem.Text = "Show Art";
            this.showArtToolStripMenuItem.Click += new System.EventHandler(this.showArtToolStripMenuItem_Click);
            // 
            // showFilesToolStripMenuItem
            // 
            this.showFilesToolStripMenuItem.Checked = true;
            this.showFilesToolStripMenuItem.CheckOnClick = true;
            this.showFilesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showFilesToolStripMenuItem.Name = "showFilesToolStripMenuItem";
            this.showFilesToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.showFilesToolStripMenuItem.Text = "Show Files";
            this.showFilesToolStripMenuItem.Click += new System.EventHandler(this.showFilesToolStripMenuItem_Click);
            // 
            // showControlsToolStripMenuItem
            // 
            this.showControlsToolStripMenuItem.Checked = true;
            this.showControlsToolStripMenuItem.CheckOnClick = true;
            this.showControlsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showControlsToolStripMenuItem.Name = "showControlsToolStripMenuItem";
            this.showControlsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.showControlsToolStripMenuItem.Text = "Show Controls";
            this.showControlsToolStripMenuItem.Click += new System.EventHandler(this.showControlsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(148, 6);
            // 
            // hideAllToolStripMenuItem
            // 
            this.hideAllToolStripMenuItem.Name = "hideAllToolStripMenuItem";
            this.hideAllToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.hideAllToolStripMenuItem.Text = "Hide All";
            this.hideAllToolStripMenuItem.Click += new System.EventHandler(this.hideAllToolStripMenuItem_Click);
            // 
            // showAllToolStripMenuItem
            // 
            this.showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
            this.showAllToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.showAllToolStripMenuItem.Text = "Show All";
            this.showAllToolStripMenuItem.Click += new System.EventHandler(this.showAllToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noHelpToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // noHelpToolStripMenuItem
            // 
            this.noHelpToolStripMenuItem.Name = "noHelpToolStripMenuItem";
            this.noHelpToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.noHelpToolStripMenuItem.Text = "No Help";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chkArtPlaying);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxArt);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fileList);
            this.splitContainer1.Size = new System.Drawing.Size(930, 244);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.splitContainer1_KeyDown);
            this.splitContainer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_MouseDown);
            this.splitContainer1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_MouseMove);
            // 
            // chkArtPlaying
            // 
            this.chkArtPlaying.AutoSize = true;
            this.chkArtPlaying.BackColor = System.Drawing.Color.Transparent;
            this.chkArtPlaying.Checked = true;
            this.chkArtPlaying.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkArtPlaying.Location = new System.Drawing.Point(5, 4);
            this.chkArtPlaying.Name = "chkArtPlaying";
            this.chkArtPlaying.Size = new System.Drawing.Size(60, 17);
            this.chkArtPlaying.TabIndex = 1;
            this.chkArtPlaying.Text = "Playing";
            this.chkArtPlaying.UseVisualStyleBackColor = false;
            this.chkArtPlaying.Visible = false;
            this.chkArtPlaying.CheckedChanged += new System.EventHandler(this.chkArtPlaying_CheckedChanged);
            // 
            // pBoxArt
            // 
            this.pBoxArt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBoxArt.Location = new System.Drawing.Point(0, 0);
            this.pBoxArt.Name = "pBoxArt";
            this.pBoxArt.Size = new System.Drawing.Size(240, 240);
            this.pBoxArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxArt.TabIndex = 0;
            this.pBoxArt.TabStop = false;
            this.pBoxArt.MouseEnter += new System.EventHandler(this.pBoxArt_MouseEnter);
            this.pBoxArt.MouseLeave += new System.EventHandler(this.pBoxArt_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.scrubber1);
            this.panel1.Controls.Add(this.pnlPlayerControls);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 268);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 48);
            this.panel1.TabIndex = 1;
            // 
            // pnlPlayerControls
            // 
            this.pnlPlayerControls.Controls.Add(this.btnPrev);
            this.pnlPlayerControls.Controls.Add(this.panel2);
            this.pnlPlayerControls.Controls.Add(this.btnPausePlay);
            this.pnlPlayerControls.Controls.Add(this.btnNext);
            this.pnlPlayerControls.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPlayerControls.Location = new System.Drawing.Point(0, 0);
            this.pnlPlayerControls.Name = "pnlPlayerControls";
            this.pnlPlayerControls.Size = new System.Drawing.Size(268, 48);
            this.pnlPlayerControls.TabIndex = 4;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(7, 7);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(32, 32);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tBarVol);
            this.panel2.Controls.Add(this.lblVol);
            this.panel2.Location = new System.Drawing.Point(121, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(140, 32);
            this.panel2.TabIndex = 3;
            // 
            // tBarVol
            // 
            this.tBarVol.Location = new System.Drawing.Point(3, 3);
            this.tBarVol.Maximum = 100;
            this.tBarVol.Name = "tBarVol";
            this.tBarVol.Size = new System.Drawing.Size(104, 45);
            this.tBarVol.TabIndex = 1;
            this.tBarVol.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tBarVol.Value = 100;
            this.tBarVol.Scroll += new System.EventHandler(this.tBarVol_Scroll);
            // 
            // lblVol
            // 
            this.lblVol.AutoSize = true;
            this.lblVol.Location = new System.Drawing.Point(104, 8);
            this.lblVol.Name = "lblVol";
            this.lblVol.Size = new System.Drawing.Size(33, 13);
            this.lblVol.TabIndex = 2;
            this.lblVol.Text = "100%";
            // 
            // btnPausePlay
            // 
            this.btnPausePlay.Location = new System.Drawing.Point(45, 7);
            this.btnPausePlay.Name = "btnPausePlay";
            this.btnPausePlay.Size = new System.Drawing.Size(32, 32);
            this.btnPausePlay.TabIndex = 0;
            this.btnPausePlay.Text = "|>";
            this.btnPausePlay.UseVisualStyleBackColor = true;
            this.btnPausePlay.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(83, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(32, 32);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // fileList
            // 
            this.fileList.AllowColumnReorder = true;
            this.fileList.AllowDrop = true;
            this.fileList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.fileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileList.FullRowSelect = true;
            this.fileList.HideSelection = false;
            this.fileList.LabelWrap = false;
            this.fileList.Location = new System.Drawing.Point(0, 0);
            this.fileList.Name = "fileList";
            this.fileList.PlayingID = 0;
            this.fileList.Size = new System.Drawing.Size(678, 240);
            this.fileList.TabIndex = 1;
            this.fileList.UseCompatibleStateImageBehavior = false;
            this.fileList.View = System.Windows.Forms.View.Details;
            this.fileList.SelectedIndexChanged += new System.EventHandler(this.fileList_SelectedIndexChanged);
            this.fileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileList_DragDrop);
            this.fileList.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileList_DragEnter);
            this.fileList.DoubleClick += new System.EventHandler(this.fileList_DoubleClick);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "#";
            this.columnHeader6.Width = 34;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Title";
            this.columnHeader7.Width = 232;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Duration";
            this.columnHeader8.Width = 54;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Book";
            this.columnHeader9.Width = 220;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Location";
            this.columnHeader10.Width = 292;
            // 
            // scrubber1
            // 
            this.scrubber1.CurrentTime = System.TimeSpan.Parse("00:00:00");
            this.scrubber1.CurrentTotalTime = System.TimeSpan.Parse("00:00:00");
            this.scrubber1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrubber1.FileStartTime = System.TimeSpan.Parse("00:00:00");
            this.scrubber1.FileTime = System.TimeSpan.Parse("00:00:00");
            this.scrubber1.Location = new System.Drawing.Point(268, 0);
            this.scrubber1.Name = "scrubber1";
            this.scrubber1.Size = new System.Drawing.Size(662, 48);
            this.scrubber1.TabIndex = 5;
            this.scrubber1.TotalTime = System.TimeSpan.Parse("00:00:00");
            this.scrubber1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrubber1_MouseDown);
            this.scrubber1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrubber1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 316);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ABPlayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxArt)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlPlayerControls.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarVol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem monoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noHelpToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pBoxArt;
        private ABListView fileList;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPausePlay;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.TrackBar tBarVol;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblVol;
        private Scrubber scrubber1;
        private System.Windows.Forms.Panel pnlPlayerControls;
        private System.Windows.Forms.ToolStripMenuItem speedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem jumpForwardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem minuteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem jumpBackwardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem secondsToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem minuteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jumpToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showArtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showControlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.CheckBox chkArtPlaying;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
    }
}

