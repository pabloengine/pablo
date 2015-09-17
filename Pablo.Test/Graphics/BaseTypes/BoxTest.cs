/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;
using System.Linq;
using NUnit.Framework;
using Pablo.Graphics;

namespace Pablo.Test.Graphics.BaseTypes
{
    [TestFixture]
    public class BoxTest
    {
        [Test(Description = "Must create instances of Box according to the documentation.")]
        public void TestConstruction()
        {
            var box1 = new Box(new Point(1, 2), new Point(5, 4));
            Assert.AreEqual(box1.Height, 2);
            Assert.AreEqual(box1.Width, 4);

            var box2 = new Box(new Point(1, 2), 5, 6);
            Assert.AreEqual(box2.Height, 6);
            Assert.AreEqual(box2.Width, 5);

            var box3 = new Box(0, 2, 3, 1);
            Assert.AreEqual(box3.BottomLeft, new Point(0, 1));
            Assert.AreEqual(box3.BottomRight, new Point(3, 1));
            Assert.AreEqual(box3.TopLeft, new Point(0, 2));
            Assert.AreEqual(box3.TopRight, new Point(3, 2));
            Assert.AreEqual(box3.Center, new Point(1.5, 1.5));

            if (!box3.Points.SequenceEqual(new[]
                {
                    box3.TopLeft,
                    box3.TopRight,
                    box3.BottomRight,
                    box3.BottomLeft
                }))
                Assert.Fail();
        }

        [Test(Description = "Must parse and serialize in a consistent manner.")]
        public void TestParsing()
        {
            const string boxString = "1.3,4.2,2.5,3.9";
            var box = Box.Parse(boxString);
            Assert.AreEqual(box, new Box(1.3, 4.2, 2.5, 3.9));
            Assert.AreEqual(boxString, box.ToString());
        }

        [Test(Description = "The invariants must not be violated and should throw if they are.")]
        public void TestInvariant()
        {
            Assert.Throws<ArgumentException>(() => new Box(1, 2, 3, 4));
            Assert.Throws<ArgumentException>(() => Box.Parse("1, 2, 3, 4"));
            Assert.Throws<ArgumentException>(() => new Box(4, 5, 3, 4));
            Assert.Throws<ArgumentException>(() => Box.Parse("4, 5, 3, 4"));
            Assert.Throws<ArgumentException>(() => new Box(new Point(0,0), -3, 4));
            Assert.Throws<ArgumentException>(() => new Box(new Point(0, 0), 3, -4));
            Assert.Throws<ArgumentException>(() => new Box(new Point(0, 0), new Point(-1, -1)));
            Assert.Throws<ArgumentException>(() => new Box(new Point(0, 1), new Point(1, 0)));
        }
    }
}
