namespace JardaCAD
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
            panelControl = new Panel();
            buttonTesting = new Button();
            buttonDrawLine = new Button();
            panel1 = new Panel();
            comboBoxScale = new ComboBox();
            titleBar.SuspendLayout();
            panelControl.SuspendLayout();
            panel1.SuspendLayout();
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
            titleBar.Size = new Size(1574, 36);
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
            buttonMinimazeAp.Location = new Point(1471, -3);
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
            buttonMaximazeApp.Location = new Point(1504, -3);
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
            buttonExitApp.Location = new Point(1537, -3);
            buttonExitApp.Name = "buttonExitApp";
            buttonExitApp.Size = new Size(38, 37);
            buttonExitApp.TabIndex = 2;
            buttonExitApp.Text = "X";
            buttonExitApp.UseVisualStyleBackColor = false;
            // 
            // panelControl
            // 
            panelControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelControl.BackColor = Color.FromArgb(40, 40, 45);
            panelControl.Controls.Add(buttonTesting);
            panelControl.Controls.Add(buttonDrawLine);
            panelControl.Location = new Point(1, 36);
            panelControl.Margin = new Padding(0);
            panelControl.Name = "panelControl";
            panelControl.Size = new Size(1572, 100);
            panelControl.TabIndex = 1;
            // 
            // buttonTesting
            // 
            buttonTesting.Location = new Point(150, 33);
            buttonTesting.Name = "buttonTesting";
            buttonTesting.Size = new Size(75, 23);
            buttonTesting.TabIndex = 1;
            buttonTesting.Text = "Testing Button";
            buttonTesting.UseVisualStyleBackColor = true;
            buttonTesting.Click += testingButton_Click;
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
            buttonDrawLine.Click += DrawLineButton_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(40, 40, 45);
            panel1.Controls.Add(comboBoxScale);
            panel1.Location = new Point(0, 847);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1574, 25);
            panel1.TabIndex = 2;
            // 
            // comboBoxScale
            // 
            comboBoxScale.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            comboBoxScale.BackColor = Color.FromArgb(40, 40, 45);
            comboBoxScale.FlatStyle = FlatStyle.Flat;
            comboBoxScale.ForeColor = SystemColors.Info;
            comboBoxScale.FormattingEnabled = true;
            comboBoxScale.ImeMode = ImeMode.NoControl;
            comboBoxScale.Items.AddRange(new object[] { "1", "2", "5", "10", "20", "25", "50", "100", "250", "500", "1000" });
            comboBoxScale.Location = new Point(1516, 3);
            comboBoxScale.Name = "comboBoxScale";
            comboBoxScale.Size = new Size(60, 23);
            comboBoxScale.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = Color.FromArgb(50, 50, 50);
            ClientSize = new Size(1574, 872);
            Controls.Add(panel1);
            Controls.Add(panelControl);
            Controls.Add(titleBar);
            DoubleBuffered = true;
            Name = "FormMain";
            SizeGripStyle = SizeGripStyle.Hide;
            Load += FormMain_Load;
            Resize += FormMain_Resize;
            titleBar.ResumeLayout(false);
            panelControl.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button buttonMinimazeAp;
        private Button buttonMaximazeApp;
        public Panel titleBar;
        public Button buttonExitApp;
        private Panel panelControl;
        private Button buttonDrawLine;
        private Panel panel1;
        private ComboBox comboBoxScale;
        private Button buttonTesting;
    }
}
