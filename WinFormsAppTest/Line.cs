using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace JardaCAD
{
    internal class Line
    {
        private PointF point1;
        
        public PointF Point1
        {
            get => point1;
            set => point1 = value;
        }

        private PointF point2;
        public PointF Point2
        {
            get => point2;
            set => point2 = value;
        }


    }
}
