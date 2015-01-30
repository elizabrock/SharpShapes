using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpShapes;
using System.Windows.Media;

namespace TestSharpShapes
{
    [TestClass]
    public class UnitTestSquares
    {
        [TestMethod]
        public void TestSquareConstructor()
        {
            Square square = new Square(40);
            Assert.AreEqual(40, square.Height);
            Assert.AreEqual(40, square.Width);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSquareConstructorChecksSidePositivity()
        {
            new Square(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSquareConstructorChecksSideIsntZero()
        {
            new Square(0);
        }

        [TestMethod]
        public void TestScaleSquare200Percent()
        {
            Square square = new Square(10);
            square.Scale(200);
            Assert.AreEqual(20, square.Height);
            Assert.AreEqual(20, square.Width);
        }

        [TestMethod]
        public void TestScaleSquare150Percent()
        {
            Square square = new Square(10);
            square.Scale(150);
            Assert.AreEqual(15, square.Height);
            Assert.AreEqual(15, square.Width);
        }

        [TestMethod]
        public void TestScaleSquare100Percent()
        {
            Square square = new Square(10);
            square.Scale(100);
            Assert.AreEqual(10, square.Height);
            Assert.AreEqual(10, square.Width);
        }

        [TestMethod]
        public void TestScaleSquare37Percent()
        {
            Square square = new Square(15);
            square.Scale(37);
            Assert.AreEqual((decimal) 5.55, square.Height);
            Assert.AreEqual((decimal) 5.55, square.Width);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestScaleSquareTo0Percent()
        {
            Square square = new Square(15);
            square.Scale(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestScaleSquareToNegativePercent()
        {
            Square square = new Square(15);
            square.Scale(-10);
        }

        [TestMethod]
        public void TestSquareSides()
        {
            Square square = new Square(15);
            Assert.AreEqual(4, square.SidesCount);
        }

        [TestMethod]
        public void TestSquareArea()
        {
            Square square = new Square(15);
            Assert.AreEqual(225, square.Area());
        }


        [TestMethod]
        public void TestBiggerSquareArea()
        {
            Square square = new Square(10);
            Assert.AreEqual(100, square.Area());
        }

        [TestMethod]
        public void TestSquarePerimeter()
        {
            Square square = new Square(15);
            Assert.AreEqual(60, square.Perimeter());
        }

        [TestMethod]
        public void TestBiggerSquarePerimeter()
        {
            Square square = new Square(10);
            Assert.AreEqual(40, square.Perimeter());
        }

        [TestMethod]
        public void TestDefaultColors()
        {
            Square shape = new Square(15);
            Assert.AreEqual(Colors.Bisque, shape.FillColor);
            Assert.AreEqual(Colors.Tomato, shape.BorderColor);
        }
    }
}
