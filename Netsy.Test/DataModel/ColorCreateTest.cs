﻿//-----------------------------------------------------------------------
// <copyright file="ColorCreateTest.cs" company="AFS">
//  This source code is part of Netsy http://github.com/AnthonySteele/Netsy/
//  and is made available under the terms of the Microsoft Public License (Ms-PL)
//  http://www.opensource.org/licenses/ms-pl.html
// </copyright>
//----------------------------------------------------------------------- 

namespace Netsy.Test.DataModel
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Netsy.DataModel;

    /// <summary>
    /// Test creating Color objects in Hsv and Rgb
    /// </summary>
    [TestClass]
    public class ColorCreateTest
    {
        /// <summary>
        /// Test creation of a HSV color from numbers
        /// </summary>
        [TestMethod]
        public void HsvColorNumericCreateTest()
        {
            HsvColor color = new HsvColor(34, 45, 67);
            Assert.IsNotNull(color);
            Assert.AreEqual(34, color.Hue);
            Assert.AreEqual(45, color.Saturation);
            Assert.AreEqual(67, color.Value);
        }

        /// <summary>
        /// Test creation of a HSV color from a string
        /// </summary>
        [TestMethod]
        public void HsvColorStringCreateTest()
        {
            HsvColor color = new HsvColor("34;45;67");
            Assert.IsNotNull(color);
            Assert.AreEqual(34, color.Hue);
            Assert.AreEqual(45, color.Saturation);
            Assert.AreEqual(67, color.Value);
        }

        /// <summary>
        /// Test creation of a RGB color from numbers
        /// </summary>
        [TestMethod]
        public void RgbColorNumericCreateTest()
        {
            RgbColor color = new RgbColor(34, 45, 67);
            Assert.IsNotNull(color);
            Assert.AreEqual(34, color.Red);
            Assert.AreEqual(45, color.Green);
            Assert.AreEqual(67, color.Blue);
        }

        /// <summary>
        /// Test creation of a RGB color from a string
        /// </summary>
        [TestMethod]
        public void RGBColorStringCreateTest()
        {
            RgbColor color = new RgbColor("123456");
            Assert.IsNotNull(color);
            Assert.AreEqual(18, color.Red);
            Assert.AreEqual(52, color.Green);
            Assert.AreEqual(86, color.Blue);
        }

        /// <summary>
        /// Test ToString with white
        /// </summary>
        [TestMethod]
        public void ToStringWhiteTest()
        {
            RgbColor color = new RgbColor(0, 0, 0);
            string result = color.ToString();

            Assert.AreEqual("000000", result);
        }

        /// <summary>
        /// Test ToString with white
        /// </summary>
        [TestMethod]
        public void ToStringBlackTest()
        {
            RgbColor color = new RgbColor(255, 255, 255);
            string result = color.ToString();

            Assert.AreEqual("FFFFFF", result);
        }

        /// <summary>
        /// Test ToString with red
        /// </summary>
        [TestMethod]
        public void ToStringRedTest()
        {
            RgbColor color = new RgbColor(255, 0, 0);
            string result = color.ToString();

            Assert.AreEqual("FF0000", result);
        }

        /// <summary>
        /// Test ToString with blue
        /// </summary>
        [TestMethod]
        public void ToStringBlueTest()
        {
            RgbColor color = new RgbColor(0, 0, 255);
            string result = color.ToString();

            Assert.AreEqual("0000FF", result);
        }

        /// <summary>
        /// Test ToString with green
        /// </summary>
        [TestMethod]
        public void ToStringGreenTest()
        {
            RgbColor color = new RgbColor(0, 255, 0);
            string result = color.ToString();

            Assert.AreEqual("00FF00", result);
        }
    }
}
