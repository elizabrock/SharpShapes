using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SharpShapes
{
    public class Rectangle : Quadrilateral
    {
        private decimal width;
        public decimal Width {
            get { return this.width;  }
        }

        private decimal height;
        public decimal Height {
            get { return this.height; }
        }

        public Rectangle(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException();
            }
            this.width = width;
            this.height = height;
        }

        public override decimal Area()
        {
            return Height * Width;
        }

        public override void DrawOnto(Canvas ShapeCanvas, int x, int y)
        {
            Polygon myPolygon = GeneratePolygon();
            Point point1 = new Point(x, y);
            Point point2 = new Point(x, y + (double) Height);
            Point point3 = new Point(x + (double) Width, y + (double) Height);
            Point point4 = new Point(x + (double) Width, y);

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
            return 2 * Height + 2 * Width;
        }

        public override void Scale(int percent)
        {
            if (percent <= 0)
            {
                throw new ArgumentException();
            }
            this.width = width * percent / 100;
            this.height = height * percent / 100;
        }
    }
}
