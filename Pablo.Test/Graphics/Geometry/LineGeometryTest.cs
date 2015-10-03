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
    public class LineGeometryTest
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(LineGeometry));

        [Test(Description = "Test serialization and deserialization")]
        public void TestSerialization()
        {
            var line = new LineGeometry { Start = new Point(5.3, 9), End = new Point(7, 8.2)};

            var writer = new StringWriter();
            _serializer.Serialize(writer, line);
            var reader = new StringReader(writer.ToString());

            Assert.AreEqual(line, _serializer.Deserialize(reader));
        }

    }
}
