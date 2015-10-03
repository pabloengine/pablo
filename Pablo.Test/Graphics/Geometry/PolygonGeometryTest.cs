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
    public class PolygonGeometryTest
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(PolygonGeometry));

        [Test(Description = "Test serialization and deserialization")]
        public void TestSerialization()
        {
            var polygon = new PolygonGeometry { Points = new []{new Point(1.5, 2), new Point(3, 4.2), new Point(4.5, 6.4), } };

            var writer = new StringWriter();
            _serializer.Serialize(writer, polygon);
            var reader = new StringReader(writer.ToString());

            Assert.AreEqual(polygon, _serializer.Deserialize(reader));
        }

    }
}
