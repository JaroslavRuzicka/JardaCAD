﻿namespace JardaCAD
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            titleBar = new Panel();
            buttonMinimazeAp = new Button();
            buttonMaximazeApp = new Button();
            buttonExitApp = new Button();
            miniToolStrip = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton2 = new ToolStripButton();
            toolStripComboBox1 = new ToolStripComboBox();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            dasToolStripMenuItem = new ToolStripMenuItem();
            asdToolStripMenuItem = new ToolStripMenuItem();
            panelControl = new Panel();
            buttonDrawLine = new Button();
            toolStrip1 = new ToolStrip();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            titleBar.SuspendLayout();
            panelControl.SuspendLayout();
            toolStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // titleBar
            // 
            titleBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            titleBar.BackColor = Color.FromArgb(40, 40, 45);
            titleBar.BorderStyle = BorderStyle.FixedSingle;
            titleBar.Controls.Add(buttonMinimazeAp);
            titleBar.Controls.Add(buttonMaximazeApp);
            titleBar.Controls.Add(buttonExitApp);
            titleBar.ForeColor = Color.Coral;
            titleBar.Location = new Point(0, 0);
            titleBar.Margin = new Padding(0);
            titleBar.Name = "titleBar";
            titleBar.Size = new Size(1334, 36);
            titleBar.TabIndex = 1;
            titleBar.MouseDown += titleBar_MouseDown;
            // 
            // buttonMinimazeAp
            // 
            buttonMinimazeAp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonMinimazeAp.BackColor = Color.FromArgb(40, 40, 45);
            buttonMinimazeAp.FlatAppearance.BorderColor = Color.LightSlateGray;
            buttonMinimazeAp.FlatAppearance.BorderSize = 0;
            buttonMinimazeAp.FlatStyle = FlatStyle.Flat;
            buttonMinimazeAp.Font = new Font("Segoe UI", 12F);
            buttonMinimazeAp.ForeColor = SystemColors.ButtonHighlight;
            buttonMinimazeAp.ImageAlign = ContentAlignment.BottomCenter;
            buttonMinimazeAp.Location = new Point(1231, -3);
            buttonMinimazeAp.Name = "buttonMinimazeAp";
            buttonMinimazeAp.Size = new Size(36, 37);
            buttonMinimazeAp.TabIndex = 4;
            buttonMinimazeAp.Text = "-";
            buttonMinimazeAp.UseVisualStyleBackColor = false;
            // 
            // buttonMaximazeApp
            // 
            buttonMaximazeApp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonMaximazeApp.BackColor = Color.FromArgb(40, 40, 45);
            buttonMaximazeApp.FlatAppearance.BorderColor = Color.LightSlateGray;
            buttonMaximazeApp.FlatAppearance.BorderSize = 0;
            buttonMaximazeApp.FlatStyle = FlatStyle.Flat;
            buttonMaximazeApp.Font = new Font("Segoe UI", 12F);
            buttonMaximazeApp.ForeColor = Color.FromArgb(249, 245, 235);
            buttonMaximazeApp.Location = new Point(1264, -3);
            buttonMaximazeApp.Name = "buttonMaximazeApp";
            buttonMaximazeApp.Size = new Size(36, 37);
            buttonMaximazeApp.TabIndex = 3;
            buttonMaximazeApp.Text = "O\r\n";
            buttonMaximazeApp.UseVisualStyleBackColor = false;
            // 
            // buttonExitApp
            // 
            buttonExitApp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonExitApp.BackColor = Color.FromArgb(40, 40, 45);
            buttonExitApp.FlatAppearance.BorderColor = Color.LightSlateGray;
            buttonExitApp.FlatAppearance.BorderSize = 0;
            buttonExitApp.FlatStyle = FlatStyle.Flat;
            buttonExitApp.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            buttonExitApp.ForeColor = Color.FromArgb(249, 245, 235);
            buttonExitApp.Location = new Point(1297, -3);
            buttonExitApp.Name = "buttonExitApp";
            buttonExitApp.Size = new Size(38, 37);
            buttonExitApp.TabIndex = 2;
            buttonExitApp.Text = "X";
            buttonExitApp.UseVisualStyleBackColor = false;
            // 
            // miniToolStrip
            // 
            miniToolStrip.AccessibleName = "New item selection";
            miniToolStrip.AccessibleRole = AccessibleRole.ButtonDropDown;
            miniToolStrip.AutoSize = false;
            miniToolStrip.CanOverflow = false;
            miniToolStrip.Dock = DockStyle.None;
            miniToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            miniToolStrip.Location = new Point(0, 0);
            miniToolStrip.Name = "miniToolStrip";
            miniToolStrip.Size = new Size(1332, 25);
            miniToolStrip.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(23, 22);
            toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 25);
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { dasToolStripMenuItem, asdToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(29, 22);
            toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // dasToolStripMenuItem
            // 
            dasToolStripMenuItem.Name = "dasToolStripMenuItem";
            dasToolStripMenuItem.Size = new Size(92, 22);
            dasToolStripMenuItem.Text = "das";
            // 
            // asdToolStripMenuItem
            // 
            asdToolStripMenuItem.Name = "asdToolStripMenuItem";
            asdToolStripMenuItem.Size = new Size(92, 22);
            asdToolStripMenuItem.Text = "asd";
            // 
            // panelControl
            // 
            panelControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelControl.BackColor = Color.FromArgb(40, 40, 45);
            panelControl.Controls.Add(buttonDrawLine);
            panelControl.Location = new Point(1, 36);
            panelControl.Margin = new Padding(0);
            panelControl.Name = "panelControl";
            panelControl.Size = new Size(1332, 100);
            panelControl.TabIndex = 1;
            // 
            // buttonDrawLine
            // 
            buttonDrawLine.BackgroundImage = (Image)resources.GetObject("buttonDrawLine.BackgroundImage");
            buttonDrawLine.BackgroundImageLayout = ImageLayout.Stretch;
            buttonDrawLine.Cursor = Cursors.Hand;
            buttonDrawLine.FlatAppearance.BorderSize = 0;
            buttonDrawLine.FlatAppearance.MouseOverBackColor = SystemColors.ButtonShadow;
            buttonDrawLine.FlatStyle = FlatStyle.Flat;
            buttonDrawLine.Font = new Font("Segoe UI", 15F);
            buttonDrawLine.ForeColor = SystemColors.ButtonHighlight;
            buttonDrawLine.Location = new Point(10, 0);
            buttonDrawLine.Margin = new Padding(0);
            buttonDrawLine.Name = "buttonDrawLine";
            buttonDrawLine.Size = new Size(75, 100);
            buttonDrawLine.TabIndex = 0;
            buttonDrawLine.Text = "Line";
            buttonDrawLine.TextAlign = ContentAlignment.BottomCenter;
            buttonDrawLine.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripSeparator1, toolStripButton2, toolStripComboBox1, toolStripDropDownButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1332, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Font = new Font("Segoe UI", 12F);
            tabControl1.HotTrack = true;
            tabControl1.Location = new Point(1, 139);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(0, 0);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1335, 639);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1327, 605);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 30);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1327, 605);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = Color.FromArgb(50, 50, 50);
            ClientSize = new Size(1334, 776);
            Controls.Add(tabControl1);
            Controls.Add(panelControl);
            Controls.Add(titleBar);
            DoubleBuffered = true;
            Name = "FormMain";
            SizeGripStyle = SizeGripStyle.Hide;
            Load += FormMain_Load;
            Resize += FormMain_Resize;
            titleBar.ResumeLayout(false);
            panelControl.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button buttonMinimazeAp;
        private Button buttonMaximazeApp;
        public Panel titleBar;
        public Button buttonExitApp;
        private ToolStrip miniToolStrip;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton2;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem dasToolStripMenuItem;
        private ToolStripMenuItem asdToolStripMenuItem;
        private Panel panelControl;
        private ToolStrip toolStrip1;
        private Button buttonDrawLine;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}
