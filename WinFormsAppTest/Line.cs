using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.CodeDom.Compiler;

namespace JardaCAD
{
    internal static class Line
    {
        private static List<List<Point>> LineList = new ();

        private static Point point1 = new Point(0, 0);
        public static Point point2 = new Point(0, 0);
        private static Canvas canvas = MainWindowControl.getCanvas;

        private static LineStateEnum lineState = LineStateEnum.buttonClick;
        public static LineStateEnum LineState
        {
            get => lineState;
            set
            {
                lineState = value;
            }
        }


        public enum LineStateEnum
        {
            buttonClick,
            canvasClick,
        }


        public static void DrawLine(MouseEventArgs e)
        {

            if (lineState == LineStateEnum.buttonClick)
            {
                point1 = e.Location;
                lineState = LineStateEnum.canvasClick;
            }
            else if (lineState == LineStateEnum.canvasClick)
            {
                point2 = e.Location;
                lineState = LineStateEnum.buttonClick;
                canvas.CanvasState = Canvas.CanvasStateEnum.selection; 
                canvas.MainCanvas.Invalidate();


                //here add a scale value
                List<Point> temp = new List<Point>{ point1, point2 };
                LineList.Add(temp);
            };
                
        }

        public static void UpdateLines(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            Pen pen = new Pen(Color.Black, 2);


            //for (int i = 0; i < LineList.Count; i++)
            //{
            //    e.Graphics.DrawLines(pen, LineList[0]);
            //}
            //e.Graphics.DrawLine(pen, curDrawnLine[0], curDrawnLine[1]);
            e.Graphics.DrawLine(pen, point1, point2);
            try
            {
                //here add a scale value
                foreach (List<Point> point in LineList) 
                { 
                    e.Graphics.DrawLine(pen, point[0], point[1]);

                }

            }
            catch
            {

            }

            e.Dispose();

        }


    }
}
