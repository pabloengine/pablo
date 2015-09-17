/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */
 
using static Pablo.Colors;
using NUnit.Framework;

namespace Pablo.Test.Graphics.BaseTypes
{
    [TestFixture]
    public class ColorsTest
    {
        [Test(Description = "Must get the color by its name.")]
        public void TestSearching()
        {
            Assert.AreEqual(BlueViolet, GetColor(nameof(BlueViolet)));
            Assert.AreEqual(BlueViolet, GetColor(nameof(BlueViolet).ToLower()));
        }
        
    }
}
