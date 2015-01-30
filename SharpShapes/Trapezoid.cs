using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SharpShapes
{
    public class Trapezoid : Quadrilateral
    {
        public decimal LongBase { get; private set; }
        public decimal ShortBase { get; private set; }
        public decimal Height { get; private set; }
        public decimal ObtuseAngle { get; private set; }
        public decimal AcuteAngle { get; private set; }

        public Trapezoid(int longBase, int shortBase, int height)
        {
            if (height <= 0 || shortBase <= 0 || longBase <= 0 || shortBase >= longBase)
            {
                throw new ArgumentException();
            }
            this.LongBase = longBase;
            this.ShortBase = shortBase;
            this.Height = height;

            this.AcuteAngle = Decimal.Round((decimal) (Math.Atan((double)(height / WingLength())) * (180.0 / Math.PI)), 2);

            this.ObtuseAngle = 180 - AcuteAngle;
        }

        private decimal WingLength()
        {
            return (LongBase - ShortBase) / 2;
        }

        public override void Scale(int percent)
        {
            if (percent <= 0)
            {
                throw new ArgumentException();
            }
            this.LongBase = LongBase * percent / 100;
            this.ShortBase = ShortBase * percent / 100;
            this.Height = Height * percent / 100;
        }

        public override decimal Area()
        {
            return (LongBase + ShortBase) / 2 * Height;
        }

        public override void DrawOnto(Canvas ShapeCanvas, int x, int y)
        {
            Polygon myPolygon = GeneratePolygon();
            Point point1 = new Point(x, y);
            Point point2 = new Point(x + (double)ShortBase, y);
            Point point3 = new Point(x + (double)((LongBase + ShortBase) / 2), y + (double)Height);
            Point point4 = new Point(x - (double)((LongBase - ShortBase) / 2), y + (double)Height);

            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(point1);
            myPointCollection.Add(point2);
            myPointCollection.Add(point3);
            myPointCollection.Add(point4);

            myPolygon.Points = myPointCollection;
            ShapeCanvas.Children.Add(myPolygon);
        }

        public override decimal Perimeter()
        {
            double squares = (double)(WingLength() * WingLength() + Height * Height);
            decimal legLength = Decimal.Round((decimal)Math.Sqrt(squares), 2);
            return LongBase + ShortBase + 2 * legLength;
        }
    }
}
