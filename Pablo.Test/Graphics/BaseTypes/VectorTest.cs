/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using NUnit.Framework;
using static System.Math;
using static Pablo.Graphics.Vector;

namespace Pablo.Test.Graphics.BaseTypes
{
    [TestFixture]
    public class VectorTest
    {
        [Test(Description = "The Z rotation algorithms should be correct")]
        [TestCase("1,0,2", 0, "1,0,2", false)]
        [TestCase("1,0,2", 90, "0,1,2", false)]
        [TestCase("1,0,2", 180, "-1,0,2", false)]
        [TestCase("1,0,2", 270, "0,-1,2", false)]
        [TestCase("1,0,2", 360, "1,0,2", false)]
        [TestCase("1.4142135623731,0,2", 45, "1,1,2", false)]
        [TestCase("1,0,2", 0, "1,0,2", true)]
        [TestCase("1,0,2", PI / 2, "0,1,2", true)]
        [TestCase("1,0,2", PI, "-1,0,2", true)]
        [TestCase("1,0,2", PI * 3 / 2, "0,-1,2", true)]
        [TestCase("1,0,2", 2 * PI, "1,0,2", true)]
        [TestCase("1.4142135623731,0,2", PI / 4, "1,1,2", true)]
        public void TestZRotate(string source, double deg, string target, bool isRad)
        {
            Assert.True(isRad
                ? Near(Parse(target), RotateZRadian(Parse(source), deg))
                : Near(Parse(target), RotateZDegree(Parse(source), deg)));
        }

        // TODO: Test arithmetic operations and parsing of vector.
    }
}
