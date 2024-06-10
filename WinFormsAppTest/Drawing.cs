using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace JardaCAD
{
    internal class Drawing
    {
        public static Point point1 = new Point (0, 0);
        public static Point point2 = new Point(699, 388);
        
        public static Point test1 = new Point(0, 100);
        public static Point test2 = new Point(2000, 100);

        public static Rectangle mouseBoxRectangle;
        

        public static void DrawLinePoint(PaintEventArgs e)
        {

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            Pen pen = new Pen(Color.Black, 2);


            // Create points that define line.
            //Point point1 = new Point(0, 10);
            //Point point2 = new Point(500, 100);

            // Draw line to screen.
            e.Graphics.DrawLine(pen, point1, point2);
            e.Graphics.DrawLine(pen, test1, test2);
            //Set the SmoothingMode property to smooth the line.
            //e.Dispose();



        }

        public static void DrawMouseBox(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


            Pen blackPen = new Pen(Color.Red, 2);


            e.Graphics.DrawLine(blackPen, test1, test2);
            //e.Graphics.DrawRectangle(blackPen, mouseBoxRectangle);
        }


    }
}
