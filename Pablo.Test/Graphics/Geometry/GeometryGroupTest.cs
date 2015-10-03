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
    public class GeometryGroupTest
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(GeometryGroup));

        [Test(Description = "Test serialization and deserialization")]
        public void TestSerialization()
        {
            var geometryGroup = new GeometryGroup { Geometries = new Pablo.Graphics.Geometry[]
            {
                new LineGeometry {Start = new Point(0, 1), End = new Point(2,3)}, 
                new EllipseGeometry {Center = new Point(4,5), RadiusX = 1, RadiusY = 2}, 
                new PolygonGeometry {Points = new []{new Point(1,2), new Point(2,2),new Point(3,4),  }}, 
                new CurveGeometry {Start = new Point(1,2), End = new Point(2,3), Bulge = 1}, 
            } };

            var writer = new StringWriter();
            _serializer.Serialize(writer, geometryGroup);
            var reader = new StringReader(writer.ToString());

            Assert.AreEqual(geometryGroup, _serializer.Deserialize(reader));
        }

    }
}
