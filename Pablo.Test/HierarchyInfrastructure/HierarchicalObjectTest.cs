/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Pablo.Test.HierarchyInfrastructure
{
    [TestFixture]
    public class HierarchicalObjectTest
    {

        [Test(Description = "Values must propagate downward.")]
        public void PropagationTest()
        {
            var root = new HierarchicalObjectImp();
            var child = new HierarchicalObjectImp();
            var descendant = new HierarchicalObjectImp();
            child.HierarchyParent = root;
            descendant.HierarchyParent = child;

            root.Foo = 10;
            Assert.AreEqual(10, descendant.Foo);

        }

        [Test(Description = "Values must be cloned properly.")]
        public void CloneTest()
        {
            var root = new HierarchicalObjectImp { Foo = 10 };

            Assert.AreEqual(10, ((HierarchicalObjectImp)root.Clone()).Foo);
        }


        [Test(Description = "Hierarchy root must be the root of the tree.")]
        public void RootTest()
        {
            var root = new HierarchicalObjectImp();
            var child = new HierarchicalObjectImp();
            var descendant = new HierarchicalObjectImp();
            child.HierarchyParent = root;
            descendant.HierarchyParent = child;

            Assert.AreSame(root, descendant.HierarchyRoot);
        }

        [Test(Description = "Values own by the object itself are distinguishable from the inherited ones.")]
        public void ValueQueryTest()
        {
            var root = new HierarchicalObjectImp();
            var child = new HierarchicalObjectImp();
            var descendant = new HierarchicalObjectImp();
            child.HierarchyParent = root;
            descendant.HierarchyParent = child;

            root.Foo = 10;

            Assert.IsTrue(descendant.HasValue(HierarchicalObjectImp.FooProperty));
            Assert.IsTrue(root.HasOwnValue(HierarchicalObjectImp.FooProperty));
            Assert.IsFalse(descendant.HasOwnValue(HierarchicalObjectImp.FooProperty));
        }

        [Test(Description = "The binder must properly return the value from the context")]
        public void BindingTest()
        {
            var c = new { X = 1, Y = new { Z = new[] { 1, 2, 3 } }, T = new Dictionary<string, int> {["Four"] = 4 } };
            var root = new HierarchicalObjectImp { DataContext = c };
            var child = new HierarchicalObjectImp {HierarchyParent = root};
            var descendant = new HierarchicalObjectImp {HierarchyParent = child};

            root.SetBinding(HierarchicalObjectImp.BarProperty, ".");
            Assert.AreEqual(root.Bar, c);

            root.SetBinding(HierarchicalObjectImp.FooProperty, "X");
            Assert.AreEqual(root.Foo, 1);

            root.SetBinding(HierarchicalObjectImp.FooProperty, "Y.Z[2]");
            Assert.AreEqual(root.Foo, 3);

            root.SetBinding(HierarchicalObjectImp.FooProperty, "T[\"Four\"]");
            Assert.AreEqual(root.Foo, 4);

            child.SetBinding(HierarchicalObjectImp.FooProperty, "Y.Z[1]");
            Assert.AreEqual(child.Foo, 2);

            // test inheritance
            root.DataContext = new {Foo = 11, Bar = 22, Baz = 33};
            child.SetBinding(HierarchicalObjectImp.FooProperty, "Bar");
            Assert.AreEqual(child.Foo, 22);

            descendant.SetBinding(HierarchicalObjectImp.FooProperty, "Foo");
            Assert.AreEqual(descendant.Foo, 11);

            // Test own data context
            descendant.DataContext = new {B = 7};

            root.SetBinding(HierarchicalObjectImp.FooProperty, "Baz");
            Assert.AreEqual(root.Foo, 33);

            descendant.SetBinding(HierarchicalObjectImp.FooProperty, "B");
            Assert.AreEqual(descendant.Foo, 7);
        }

        [Test(Description = "The binder must properly throw the appropriate exception on invalid expressions")]
        public void BindingErrorTest()
        {
            var c = new { X = 1, Y = "foo", T = new Dictionary<string, int> {["Four"] = 4 } };
            var root = new HierarchicalObjectImp { DataContext = c };
            object trash;

            Assert.Throws<ArgumentNullException>(() => root.SetBinding(HierarchicalObjectImp.BarProperty, null));
            Assert.Throws<ArgumentException>(() => root.SetBinding(HierarchicalObjectImp.BarProperty, ""));

            root.SetBinding(HierarchicalObjectImp.FooProperty, "X'");
            Assert.Throws<BindingExceprtion>(() => trash = root.Foo);

            root.SetBinding(HierarchicalObjectImp.FooProperty, "Y.Z['2]");
            Assert.Throws<BindingExceprtion>(() => trash = root.Foo);

            root.SetBinding(HierarchicalObjectImp.FooProperty, "T[Four\"]");
            Assert.Throws<BindingExceprtion>(() => trash = root.Foo);

            root.SetBinding(HierarchicalObjectImp.FooProperty, "Y");
            Assert.Throws<BindingTypeMismatchExceprtion>(() => trash = root.Foo);
            
        }

        [Test(Description = "The binder must properly throw the appropriate exception on invalid expressions")]
        public void BindingDataContextTest()
        {
            var c = new {Y = new { Z = new[] { 1, 2, 3 } }};
            var root = new HierarchicalObjectImp { DataContext = c };
            var child = new HierarchicalObjectImp { HierarchyParent = root };
            var descendant = new HierarchicalObjectImp { HierarchyParent = child };
            
            child.SetBinding(HierarchicalObject.DataContextProperty, "Y");
            Assert.AreEqual(child.DataContext, c.Y);

            descendant.SetBinding(HierarchicalObject.DataContextProperty, "Z[2]");
            Assert.AreEqual(descendant.DataContext, 3);


            c = new { Y = new { Z = new[] { 11, 22, 33 } } };
            root.DataContext = c;
            Assert.AreEqual(descendant.DataContext, 33);
        }

        [Test(Description = "The binder must ignore missing properties and throw on syntax errors")]
        public void LooseBindingTest()
        {
            var c = new { Y = new { Z = new[] { 1, 2, 3 } } };
            var root = new HierarchicalObjectImp { DataContext = c };
    
            // This will also ignore syntax errors
            root.SetBinding(HierarchicalObjectImp.FooProperty, "X'", true);
            Assert.AreEqual(root.Foo, 0);

            root.SetBinding(HierarchicalObjectImp.FooProperty, "X", true);
            Assert.AreEqual(root.Foo, 0);

            root.SetBinding(HierarchicalObjectImp.BarProperty, "T", true);
            Assert.AreEqual(root.Bar, null);
        }

        #region Mock Implementations

        /// <summary>
        /// A simple implementation to test the behavior.
        /// </summary>
        class HierarchicalObjectImp : HierarchicalObject
        {
            /// <summary>
            /// The representative of the Foo property
            /// </summary>
            public static readonly HierarchicalProperty FooProperty;

            /// <summary>
            /// The representative of the Bar property
            /// </summary>
            public static readonly HierarchicalProperty BarProperty;

            static HierarchicalObjectImp()
            {
                // register the Foo property
                FooProperty = RegisterProperty(typeof(HierarchicalObjectImp), nameof(Foo), typeof(int), true);
                // register the Bar property
                BarProperty = RegisterProperty(typeof(HierarchicalObjectImp), nameof(Bar), typeof(object), true);
            }

            /// <summary>
            /// Gets or sets the foo.
            /// </summary>
            /// <remarks>
            /// A wrapper for the underlying managed property.
            /// </remarks>
            /// <value>The foo.</value>
            public int Foo
            {
                get { return (int)GetValue(FooProperty); }
                set { SetValue(FooProperty, value); }
            }

            /// <summary>
            /// Gets or sets the foo.
            /// </summary>
            /// <remarks>
            /// A wrapper for the underlying managed property.
            /// </remarks>
            /// <value>The foo.</value>
            public object Bar
            {
                get { return GetValue(BarProperty); }
                set { SetValue(BarProperty, value); }
            }
        }

        #endregion
    }


}
