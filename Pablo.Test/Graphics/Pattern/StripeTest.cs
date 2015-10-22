/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using NUnit.Framework;
using Pablo.Graphics;

namespace Pablo.Test.Graphics.Pattern
{
    [TestFixture]
    public class StripeTest
    {

        [Test(Description = "Test serialization and deserialization")]
        public void TestSerialization()
        {
            var stripe = new Stripe(1, new Point(2, 3), new Point(4, 5), 2, 4, 6);
            var strideString = stripe.ToString();
            var newStride = Stripe.Parse(strideString);

            Assert.AreEqual(stripe, newStride);
        }

    }
}
