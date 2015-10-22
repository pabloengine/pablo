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
    public class SolidColorBrushTest
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(SolidColorBrush));

        [Test(Description = "Test serialization and deserialization")]
        public void TestSerialization()
        {
            var solidColorBrush = new SolidColorBrush { Color = Colors.Aqua };

            var writer = new StringWriter();
            _serializer.Serialize(writer, solidColorBrush);
            var reader = new StringReader(writer.ToString());

            Assert.AreEqual(solidColorBrush, _serializer.Deserialize(reader));
        }
    }
}
