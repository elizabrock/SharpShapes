using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpShapes;
using System.Windows.Media;

namespace TestSharpShapes
{
    [TestClass]
    public class UnitTestTrapezoids
    {
        [TestMethod]
        public void TestTrapezoidConstructorSetsProperties()
        {
            Trapezoid trapezoid = new Trapezoid(8, 2, 4);
            Assert.AreEqual(8, trapezoid.LongBase);
            Assert.AreEqual(2, trapezoid.ShortBase);
            Assert.AreEqual(4, trapezoid.Height);
        }

        [TestMethod]
        public void TestTrapezoidConstructorSetsProperties2()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 2);
            Assert.AreEqual(20, trapezoid.LongBase);
            Assert.AreEqual(15, trapezoid.ShortBase);
            Assert.AreEqual(2, trapezoid.Height);
        }

        [TestMethod]
        public void TestTrapezoidConstructorCalculatesAngles1()
        {
            Trapezoid trapezoid = new Trapezoid(8, 4, 2);
            Assert.AreEqual(45, trapezoid.AcuteAngle);
            Assert.AreEqual(135, trapezoid.ObtuseAngle);
        }

        [TestMethod]
        public void TestTrapezoidConstructorCalculatesAngles2()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 2);
            Assert.AreEqual((decimal) 38.66, trapezoid.AcuteAngle);
            Assert.AreEqual((decimal) 141.34, trapezoid.ObtuseAngle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TrapezoidConstructorSanityChecksBaseLengths()
        {
            new Trapezoid(15, 20, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TrapezoidConstructorSanityChecksLongBaseLength()
        {
            new Trapezoid(0, 20, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TrapezoidTrapezoidCantBeRectangle()
        {
            new Trapezoid(20, 20, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TrapezoidConstructorSanityChecksShortBaseLength()
        {
            new Trapezoid(15, 0, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TrapezoidConstructorSanityChecksHeight()
        {
            new Trapezoid(15, 20, 0);
        }

        [TestMethod]
        public void TestScaleTrapezoid200Percent()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 10);
            trapezoid.Scale(200);
            Assert.AreEqual(40, trapezoid.LongBase);
            Assert.AreEqual(30, trapezoid.ShortBase);
            Assert.AreEqual(20, trapezoid.Height);
            Assert.AreEqual((decimal)75.96, trapezoid.AcuteAngle);
            Assert.AreEqual((decimal)104.04, trapezoid.ObtuseAngle);
        }

        [TestMethod]
        public void TestScaleTrapezoid100Percent()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 10);
            trapezoid.Scale(100);
            Assert.AreEqual(20, trapezoid.LongBase);
            Assert.AreEqual(15, trapezoid.ShortBase);
            Assert.AreEqual(10, trapezoid.Height);
            Assert.AreEqual((decimal)75.96, trapezoid.AcuteAngle);
            Assert.AreEqual((decimal)104.04, trapezoid.ObtuseAngle);
        }

        [TestMethod]
        public void TestScaleTrapezoid150Percent()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 10);
            trapezoid.Scale(150);
            Assert.AreEqual(30, trapezoid.LongBase);
            Assert.AreEqual((decimal)22.5, trapezoid.ShortBase);
            Assert.AreEqual(15, trapezoid.Height);
            Assert.AreEqual((decimal)75.96, trapezoid.AcuteAngle);
            Assert.AreEqual((decimal)104.04, trapezoid.ObtuseAngle);
        }

        [TestMethod]
        public void TestScaleTrapezoid37Percent()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 10);
            trapezoid.Scale(37);
            Assert.AreEqual((decimal)7.4, trapezoid.LongBase);
            Assert.AreEqual((decimal)5.55, trapezoid.ShortBase);
            Assert.AreEqual((decimal)3.7, trapezoid.Height);
            Assert.AreEqual((decimal)75.96, trapezoid.AcuteAngle);
            Assert.AreEqual((decimal)104.04, trapezoid.ObtuseAngle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TrapezoidScaleTo0Percent()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 10);
            trapezoid.Scale(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TrapezoidScaleToNegativePercent()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 10);
            trapezoid.Scale(-10);
        }

        [TestMethod]
        public void TestTrapezoidArea()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 10);
            Assert.AreEqual(175, trapezoid.Area());
        }

        [TestMethod]
        public void TestTrapezoidArea2()
        {
            Trapezoid trapezoid = new Trapezoid(8, 4, 2);
            Assert.AreEqual(12, trapezoid.Area());
        }

        [TestMethod]
        public void TestTrapezoidPerimeter()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 10);
            Assert.AreEqual((decimal)55.62, trapezoid.Perimeter());
        }

        [TestMethod]
        public void TestTrapezoidPerimeter2()
        {
            Trapezoid trapezoid = new Trapezoid(8, 2, 4);
            Assert.AreEqual(20, trapezoid.Perimeter());
        }

        [TestMethod]
        public void TestTrapezoidSidesCount()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 2);
            Assert.AreEqual(4, trapezoid.SidesCount);
        }

        [TestMethod]
        public void TestDefaultTrapezoidColors()
        {
            Trapezoid shape = new Trapezoid(20, 15, 2);
            Assert.AreEqual(Colors.Bisque, shape.FillColor);
            Assert.AreEqual(Colors.Tomato, shape.BorderColor);
        }
    }
}
