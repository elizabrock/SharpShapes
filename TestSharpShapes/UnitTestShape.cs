using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpShapes;
using System.Windows.Controls;
using System.Windows.Media;

namespace TestSharpShapes
{
    [TestClass]
    public class UnitTestShape
    {
        public class MyShape : Shape
        {
            public override int SidesCount
            { 
                get { throw new NotImplementedException(); } 
            }

            public override void Scale(int percent)
            {
                throw new NotImplementedException();
            }

            public override decimal Perimeter()
            {
                throw new NotImplementedException();
            }

            public override decimal Area()
            {
                throw new NotImplementedException();
            }

            public override void DrawOnto(Canvas ShapeCanvas, int x, int y)
            {
                throw new NotImplementedException();
            }
        }

        [TestMethod]
        public void TestSettingBorderColor()
        {
            Shape shape = new MyShape();
            shape.BorderColor = Colors.AliceBlue;
            Assert.AreEqual(Colors.AliceBlue, shape.BorderColor);
        }

        [TestMethod]
        public void TestDefaultBorderColor()
        {
            Shape shape = new MyShape();
            Assert.AreEqual(Colors.Tomato, shape.BorderColor);
        }

        [TestMethod]
        public void TestSettingFillColor()
        {
            Shape shape = new MyShape();
            shape.FillColor = Colors.AliceBlue;
            Assert.AreEqual(Colors.AliceBlue, shape.FillColor);
        }

        [TestMethod]
        public void TestDefaultFillColor()
        {
            Shape shape = new MyShape();
            Assert.AreEqual(Colors.Bisque, shape.FillColor);
        }
    }
}
