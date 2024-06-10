using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JardaCAD
{
    internal class Canvas
    {

        public TableLayoutPanel MainCanvas;


        public Canvas()
        {
            MainCanvas = new TableLayoutPanel();

            SetDoubleBuffer(this.MainCanvas, true);

            //Canvas.Dock = DockStyle.Bottom;
            this.MainCanvas.Height = 150;
            this.MainCanvas.Width = 150;
            this.MainCanvas.BackColor = Color.BlanchedAlmond;
            this.MainCanvas.Name = "Canvas";
            this.MainCanvas.Location = new Point(0, 200);
            this.MainCanvas.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.MainCanvas.Dock = DockStyle.Bottom;
            this.MainCanvas.Paint += panelCanvas_Paint;
            this.MainCanvas.MouseMove += panelCanvas_MouseMove;
            this.MainCanvas.MouseClick += panelCanvas_MouseClick;
            this.MainCanvas.Paint += new PaintEventHandler(panelCanvas_Paint);
            

        }
        public void setHeight(int height)
        {
            this.MainCanvas.Height = height;
        }
        private void panelCanvas_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {

            Drawing.DrawLinePoint(e);
        }



        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Drawing.point1 = e.Location;
            MainCanvas.Invalidate();
        }

        //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //e.Graphics.SmoothingMode = Syste .Drawing.Drawing2D.SmoothingMode.AntiAlias;


        static void SetDoubleBuffer(Control ctrl, bool DoubleBuffered)
        {
            try
            {
                typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, ctrl, new object[] { DoubleBuffered });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
