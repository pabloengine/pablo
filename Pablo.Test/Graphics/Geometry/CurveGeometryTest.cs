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

namespace Pablo.Test.Graphics.Geometry
{
    [TestFixture]
    public class CurveGeometryTest
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(CurveGeometry));

        [Test(Description = "Test serialization and deserialization")]
        public void TestSerialization()
        {
            var curve = new CurveGeometry { Start = new Point(1.5, 2), End = new Point(3, 4.2), Bulge = 1 };

            var writer = new StringWriter();
            _serializer.Serialize(writer, curve);
            var reader = new StringReader(writer.ToString());

            Assert.AreEqual(curve, _serializer.Deserialize(reader));
        }

        // TODO: Test Peak
    }
}
