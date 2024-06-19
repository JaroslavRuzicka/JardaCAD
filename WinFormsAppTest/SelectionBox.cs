using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardaCAD
{
    internal class SelectionBox
    {
        Canvas canvas = MainWindowControl.getCanvas;
        private PointF currentPosition;
        private Point origin;
        PointF lineTopPoint1 = new PointF(0,0);
        PointF lineTopPoint2 = new PointF(0,0);
        PointF lineLeftPoint1 = new PointF(0,0);
        PointF lineLeftPoint2 = new PointF(0,0);
        PointF lineBottomPoint1 = new PointF(0,0);
        PointF lineBottomPoint2 = new PointF(0,0);
        PointF lineRightPoint1 = new PointF(0,0);
        PointF lineRightPoint2 = new PointF(0,0);



        public Point Origin
        {
            get => origin; 
            set => origin = value;
        }

        private SelectionBoxStateEnum selectionBoxState;


        private enum SelectionBoxStateEnum
        {
            insideSelectionBox,
            passthroughSelectionBox,

        }

        public void DrawSelectionBox(MouseEventArgs e)
        {
            currentPosition = e.Location;
            if(currentPosition.X - origin.X > 0)
            {
                selectionBoxState = SelectionBoxStateEnum.insideSelectionBox;
            }
            else
            {
                selectionBoxState = SelectionBoxStateEnum.passthroughSelectionBox;

            }
            float diffX = currentPosition.X - origin.X;
            float diffY = currentPosition.Y - origin.Y;
            lineTopPoint1 = new PointF(origin.X + diffX, origin.Y);
            lineTopPoint2 = new PointF(origin.X, origin.Y);


            lineLeftPoint1 = new PointF(origin.X, origin.Y + diffY);
            lineLeftPoint2 = new PointF(origin.X, origin.Y);


            lineBottomPoint1 = new PointF(origin.X + diffX, origin.Y + diffY);
            lineBottomPoint2 = new PointF(origin.X, origin.Y + diffY);


            lineRightPoint1 = new PointF(origin.X + diffX, origin.Y + diffY);
            lineRightPoint2 = new PointF(origin.X + diffX, origin.Y);


        }

        public void UpdateSelectionBox(PaintEventArgs e)
        {

            Pen pen = new Pen(Color.Empty, 2);



            if (selectionBoxState == SelectionBoxStateEnum.insideSelectionBox)
            {
                pen = new Pen(Color.Black, 2);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            }else if(selectionBoxState == SelectionBoxStateEnum.passthroughSelectionBox)
            {
                pen = new Pen(Color.Black, 2);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }
            e.Graphics.DrawLine(pen, lineTopPoint1, lineTopPoint2);
            e.Graphics.DrawLine(pen, lineLeftPoint1, lineLeftPoint2);
            e.Graphics.DrawLine(pen, lineBottomPoint1, lineBottomPoint2);
            e.Graphics.DrawLine(pen, lineRightPoint1, lineRightPoint2);



        }

        public void resetSelectionBox()
        {
            lineTopPoint1 = new PointF(0,0);
            lineTopPoint2 = new PointF(0, 0);
            lineLeftPoint1 = new PointF(0, 0);
            lineLeftPoint2 = new PointF(0, 0);
            lineBottomPoint1 = new PointF(0, 0);    
            lineBottomPoint2 = new PointF(0, 0);
            lineRightPoint1 = new PointF(0, 0);
            lineRightPoint2 = new PointF(0, 0);
        }

    }
}
