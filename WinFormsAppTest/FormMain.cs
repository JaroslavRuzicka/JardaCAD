using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace JardaCAD
{
    public partial class FormMain : Form
    {
        Canvas canvas = MainWindowControl.getCanvas;

        public FormMain()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None; // no borders
            this.DoubleBuffered = true;

            this.SetStyle(ControlStyles.ResizeRedraw, true); // this is to avoid visual artifacts
            this.Padding = new Padding(MainWindowControl.BorderSize);
            //this.BackColor = Color.FromArgb(98, 102, 244);

        }

        #region Window Behavior

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void titleBar_MouseDown(object sender, EventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0083;
            if (message.Msg == WM_SYSCOMMAND && message.WParam.ToInt32() == 1)
            {
                return;
            }

            base.WndProc(ref message);

            if (message.Msg == 0x84) // WM_NCHITTEST
            {
                var cursor = this.PointToClient(Cursor.Position);

                if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightSlateGray, Top);
            e.Graphics.FillRectangle(Brushes.LightSlateGray, Left);
            e.Graphics.FillRectangle(Brushes.LightSlateGray, Right);
            e.Graphics.FillRectangle(Brushes.LightSlateGray, Bottom);
        }

        private const int
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17;

        new Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, MainWindowControl.BorderWidth); } }
        new Rectangle Left { get { return new Rectangle(0, 0, MainWindowControl.BorderWidth, this.ClientSize.Height); } }
        new Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - MainWindowControl.BorderWidth, this.ClientSize.Width, MainWindowControl.BorderWidth); } }
        new Rectangle Right { get { return new Rectangle(this.ClientSize.Width - MainWindowControl.BorderWidth, 0, MainWindowControl.BorderWidth, this.ClientSize.Height); } }

        static Rectangle TopLeft { get { return new Rectangle(0, 0, MainWindowControl.BorderWidth, MainWindowControl.BorderWidth); } }
        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - MainWindowControl.BorderWidth, 0, MainWindowControl.BorderWidth, MainWindowControl.BorderWidth); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - MainWindowControl.BorderWidth, MainWindowControl.BorderWidth, MainWindowControl.BorderWidth); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - MainWindowControl.BorderWidth, this.ClientSize.Height - MainWindowControl.BorderWidth, MainWindowControl.BorderWidth, MainWindowControl.BorderWidth); } }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            int topBarheight = titleBar.Height + panelControl.Height;
            canvas.setHeight(Height - topBarheight);
            MainWindowControl.AdjustForm();

        }

        #endregion

        private void FormMain_Load(object sender, EventArgs e)
        {
            buttonExitApp.MouseClick += MainWindowControl.Mouse_Click_Exit;
            buttonMaximazeApp.MouseClick += MainWindowControl.Mouse_Click_Maximaze;
            buttonMinimazeAp.MouseClick += MainWindowControl.Mouse_Click_Minimize;

            Program.mainForm.Controls.Add(canvas.MainCanvas);
            comboBoxScale.SelectedIndex = 0;
        }

        private void DrawLineButton_Click(object sender, EventArgs e)
        {
            canvas.CanvasState = Canvas.CanvasStateEnum.drawLine;
        }

        private void testingButton_Click(object sender, EventArgs e)
        {

            SelectionBox.ResetSelection();
            canvas.MainCanvas.Invalidate();
            
        }

        private void comboBoxScale_SelectedValueChanged(object sender, EventArgs e)
        {
            float value = float.Parse(comboBoxScale.Text);
            canvas.SetCanvasScale(value);
            canvas.MainCanvas.Invalidate();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("a");
            if (e.KeyCode == Keys.Escape)
            {
                SelectionBox.ResetSelection();
            }
        }

        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("a");

        }
    }
}