/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;
using Pablo.Graphics;

namespace Pablo.Test.Graphics.Brush
{
    [TestFixture]
    public class StripePatternBrushTest
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(StripePatternBrush));

        [Test(Description = "Test serialization and deserialization")]
        public void TestSerialization()
        {
            var stripePatternBrush = new StripePatternBrush
            {
                Origin = new Point(1, 2),
                BackgroundColor = Colors.Azure,
                StripeColor = Colors.Black,
                Scale = 2,
                Stripes = new[]
                {
                    new Stripe(1,new Point(2,3), new Point(4,5), 6, 7, 8, 9),
                    new Stripe(11,new Point(12,13), new Point(14,15)),
                    new Stripe(21,new Point(22,23), new Point(24,25), 26, 27, 28),
                    new Stripe(31,new Point(32,33), new Point(34,35), 36, 37, 38, 39, 40),
                },
            };

            var writer = new StringWriter();
            _serializer.Serialize(writer, stripePatternBrush);
            var reader = new StringReader(writer.ToString());

            Assert.AreEqual(stripePatternBrush, _serializer.Deserialize(reader));
        }
    }
}
