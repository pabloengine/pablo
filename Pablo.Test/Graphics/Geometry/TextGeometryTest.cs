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
    public class TextGeometryTest
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(TextGeometry));

        [Test(Description = "Test serialization and deserialization")]
        public void TestSerialization()
        {
            var text = new TextGeometry
            {
                FontFamily = "Consolas",
                FontStyle = FontStyle.Normal,
                FontWeight = FontWeight.Bold,
                FontDecoration = FontDecoration.Underlined,
                BaseLineLeft = new Point(2,3),
                Content = "Hello!",
                FontHeight = 5,
                Rotation = 90,
            };

            var writer = new StringWriter();
            _serializer.Serialize(writer, text);
            var reader = new StringReader(writer.ToString());

            Assert.AreEqual(text, _serializer.Deserialize(reader));
        }

        // TODO: Test other operations
    }
}
