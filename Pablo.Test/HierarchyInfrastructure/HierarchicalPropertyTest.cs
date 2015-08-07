/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;
using NUnit.Framework;
using Pablo;

namespace HierarchyInfrastructure
{
    [TestFixture]
    public class HierarchicalPropertyTest
    {
        [Test(Description = "Must throw Argument Exception")]
        public void TestConstructor()
        {
            Assert.Throws<ArgumentNullException>(() => new HierarchicalProperty(null, "name", GetType(), false, null, null, null));
            Assert.Throws<ArgumentNullException>(() => new HierarchicalProperty(GetType(), null, GetType(), false, null, null, null));
            Assert.Throws<ArgumentNullException>(() => new HierarchicalProperty(GetType(), "name", null, false, null, null, null));
            Assert.Throws<ArgumentException>(() => new HierarchicalProperty(GetType(), "   ", GetType(), false, null, null, null));
            Assert.Throws<ArgumentException>(() => new HierarchicalProperty(GetType(), " ", GetType(), false, null, null, null));
            Assert.Throws<ArgumentException>(() => new HierarchicalProperty(GetType(), "", GetType(), false, null, null, null));
        }

        [Test(Description = "The default property must act as expected.")]
        public void TestDefault()
        {
            // Automatic default
            var goodProperty = new HierarchicalProperty(GetType(), "Foo", typeof(bool), false, null, null, null);
            Assert.DoesNotThrow(() => goodProperty.Default.GetType());

            // Provided factory
            goodProperty = new HierarchicalProperty(GetType(), "Foo", typeof(bool), false, null, () => true, null);
            Assert.IsTrue((bool)goodProperty.Default);

            // Faulty factory (null return for value type)
            var mustFail = new HierarchicalProperty(GetType(), "Foo", typeof(bool), false, null, () => null, null);
            Assert.Throws<PropertyException>(() => mustFail.Default.GetType());


            // Faulty factory (the factory throws exception)
            mustFail = new HierarchicalProperty(GetType(), "Foo", typeof(bool), false, null, () => {
                throw null;
            }, null);
            Assert.Throws<PropertyException>(() => mustFail.Default.GetType());


            // Faulty factory (returns the wront type)
            mustFail = new HierarchicalProperty(GetType(), "Foo", typeof(double), false, null, () => 1, null);
            Assert.Throws<PropertyException>(() => mustFail.Default.GetType());
        }

        [Test(Description = "The cloner must act as expected.")]
        public void TestCloner()
        {
            // The clone is the object itself (very efficient if the type is immutable)
            var goodProperty = new HierarchicalProperty(GetType(), "Foo", typeof(object), false, null, null, o => o);
            var obj = new object();
            Assert.AreSame(obj, goodProperty.Clone(obj));

            // Must clone automatically
            goodProperty = new HierarchicalProperty(GetType(), "Foo", typeof(double), false, null, null, null);
            Assert.AreEqual(14.0, (double)goodProperty.Clone(14.0));

            // Must return null
            goodProperty = new HierarchicalProperty(GetType(), "Foo", typeof(object), false, null, null, null);
            Assert.IsNull(goodProperty.Clone(null));

            // Must fail from type mismatch
            var mustFail = new HierarchicalProperty(GetType(), "Foo", typeof(double), false, null, null, o => (int)(double)o);
            Assert.Throws<ArgumentException>(() => mustFail.Clone(1)); // Wrong argument type
            Assert.Throws<PropertyException>(() => mustFail.Clone(1.0)); // Wrong type returned by the cloner
        }


        [Test(Description = "The parser must act as expected.")]
        public void TestParser()
        {
            // string returns itself
            var goodProperty = new HierarchicalProperty(GetType(), "Foo", typeof(string), false, null, null, null);
            var str = 1.ToString();
            Assert.AreSame(str, goodProperty.Parse(str));

            // Must parse automatically
            goodProperty = new HierarchicalProperty(GetType(), "Foo", typeof(double), false, null, null, null);
            Assert.AreEqual(14.0, (double)goodProperty.Parse("14.0"));

            // Must parse nullable types automatically too.
            goodProperty = new HierarchicalProperty(GetType(), "Foo", typeof(DateTime?), false, null, null, null);
            var now = DateTime.Now;
            Assert.AreEqual(Convert.ToDateTime(now.ToString()), (DateTime)goodProperty.Parse(now.ToString()));

            // Must throw on null
            goodProperty = new HierarchicalProperty(GetType(), "Foo", typeof(object), false, null, null, null);
            Assert.Throws<ArgumentNullException>(() => goodProperty.Parse(null));

            // Must fail from type mismatch
            var mustFail = new HierarchicalProperty(GetType(), "Foo", typeof(double), false, s => int.Parse(s), null, null);
            Assert.Throws<PropertyException>(() => mustFail.Parse("1")); // Wrong type returned by the cloner
        }
    }
}
