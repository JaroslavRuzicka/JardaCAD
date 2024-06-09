using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace JardaCAD
{
    internal class Drawing
    {
        public static Point point1 = new Point (0, 0);
        public static Point point2 = new Point(20, 300);
        
        public static Point test1 = new Point(230, 290);
        public static Point test2 = new Point(230, 290);

        public static Rectangle mouseBoxRectangle;
        

        public static void DrawLinePoint(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);

            // Create points that define line.
            //Point point1 = new Point(0, 10);
            //Point point2 = new Point(500, 100);

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, point1, point2);
        }

        public static void DrawMouseBox(PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.White, 3);

            e.Graphics.DrawLine(blackPen, test1, test2);
            //e.Graphics.DrawRectangle(blackPen, mouseBoxRectangle);
        }
    }
}
