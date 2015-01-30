using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpShapes;
using System.Windows.Media;

namespace TestSharpShapes
{
    [TestClass]
    public class UnitTestRectangles
    {
        [TestMethod]
        public void TestRectangleConstructor()
        {
            Rectangle rectangle = new Rectangle(40, 50);
            Assert.AreEqual(40, rectangle.Width);
            Assert.AreEqual(50, rectangle.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRectangleConstructorSanityChecksWidth()
        {
            Rectangle rectangle = new Rectangle(0, 50);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRectangleConstructorSanityChecksWidthPositivity()
        {
            Rectangle rectangle = new Rectangle(-1, 50);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRectangleConstructorSanityChecksHeight()
        {
            Rectangle rectangle = new Rectangle(50, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRectangleConstructorSanityChecksHeightPositivity()
        {
            Rectangle rectangle = new Rectangle(50, -1);
        }

        [TestMethod]
        public void TestScaleRectangle200Percent()
        {
            Rectangle rectangle = new Rectangle(10, 15);
            rectangle.Scale(200);
            Assert.AreEqual(20, rectangle.Width);
            Assert.AreEqual(30, rectangle.Height);
        }

        [TestMethod]
        public void TestScaleRectangle150Percent()
        {
            Rectangle rectangle = new Rectangle(10, 15);
            rectangle.Scale(150);
            Assert.AreEqual(15, rectangle.Width);
            Assert.AreEqual((decimal) 22.5, rectangle.Height);
        }

        [TestMethod]
        public void TestScaleRectangle100Percent()
        {
            Rectangle rectangle = new Rectangle(10, 15);
            rectangle.Scale(100);
            Assert.AreEqual(10, rectangle.Width);
            Assert.AreEqual(15, rectangle.Height);
        }

        [TestMethod]
        public void TestScaleRectangle37Percent()
        {
            Rectangle rectangle = new Rectangle(10, 15);
            rectangle.Scale(37);
            Assert.AreEqual((decimal) 3.7, rectangle.Width);
            Assert.AreEqual((decimal) 5.55, rectangle.Height);
        }

        [TestMethod]
        public void TestScaleRectangleUpAndDown()
        {
            Rectangle rectangle = new Rectangle(10, 15);
            rectangle.Scale(50);
            rectangle.Scale(200);
            Assert.AreEqual(10, rectangle.Width);
            Assert.AreEqual(15, rectangle.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestScaleRectangleTo0Percent()
        {
            Rectangle rectangle = new Rectangle(10, 15);
            rectangle.Scale(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestScaleRectangleToNegativePercent()
        {
            Rectangle rectangle = new Rectangle(10, 15);
            rectangle.Scale(-5);
        }

        [TestMethod]
        public void TestSidesCount()
        {
            Rectangle rectangle = new Rectangle(1, 5);
            Assert.AreEqual(4, rectangle.SidesCount);
        }

        [TestMethod]
        public void TestRectangleArea()
        {
            Rectangle rectangle = new Rectangle(1, 5);
            Assert.AreEqual(5, rectangle.Area());
        }

        [TestMethod]
        public void TestBiggerRectangleArea()
        {
            Rectangle rectangle = new Rectangle(10, 100);
            Assert.AreEqual(1000, rectangle.Area());
        }

        [TestMethod]
        public void TestRectanglePerimeter()
        {
            Rectangle rectangle = new Rectangle(1, 5);
            Assert.AreEqual(12, rectangle.Perimeter());
        }

        [TestMethod]
        public void TestBiggerRectanglePerimeter()
        {
            Rectangle rectangle = new Rectangle(10, 100);
            Assert.AreEqual(220, rectangle.Perimeter());
        }

        [TestMethod]
        public void TestDefaultColors()
        {
            Rectangle shape = new Rectangle(10, 15);
            Assert.AreEqual(Colors.Bisque, shape.FillColor);
            Assert.AreEqual(Colors.Tomato, shape.BorderColor);
        }
    }
}
