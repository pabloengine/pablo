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
    public class EllipseGeometryTest
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(EllipseGeometry));

        [Test(Description = "Test serialization and deserialization")]
        public void TestSerialization()
        {
            var ellipse = new EllipseGeometry { Center = new Point(1.1, 3), RadiusX = 1, RadiusY = 4 };

            var writer = new StringWriter();
            _serializer.Serialize(writer, ellipse);
            var reader = new StringReader(writer.ToString());

            Assert.AreEqual(ellipse, _serializer.Deserialize(reader));
        }

    }
}
