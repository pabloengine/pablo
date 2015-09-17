/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */
 
using NUnit.Framework;
using Pablo.Graphics;

namespace Pablo.Test.Graphics.BaseTypes
{
    [TestFixture]
    public class ColorTest
    {
        [Test(Description = "Color must be inversed correctly.")]
        public void TestInverse()
        {
            var color = new Color(1,127,255);
            Assert.AreEqual(Color.Invert(color), new Color(254, 128, 0));
        }

        [Test(Description = "Must parse and serialize in a consistent manner.")]
        public void TestParsing()
        {
            const string colorString1 = "#0f0";
            const string colorString2 = "#80ff00";
            const string colorString3 = "128,32,8";
            const string colorString4 = "128,32,255,128";

            const string colorString5 = "Pink";
            const string colorString6 = "blue";

            Assert.AreEqual(Color.Parse(colorString1), new Color(0,255,0));
            Assert.AreEqual(Color.Parse(colorString2), new Color(128, 255, 0));
            Assert.AreEqual(Color.Parse(colorString3), new Color(128, 32, 8));
            Assert.AreEqual(Color.Parse(colorString4), new Color(128, 32, 255, 128));

            Assert.AreEqual(Color.Parse(colorString5), Colors.Pink);
            Assert.AreEqual(Color.Parse(colorString6), Colors.Blue);

            Assert.AreEqual(Color.Parse(colorString4).ToString(), colorString4);
        }
        
    }
}
