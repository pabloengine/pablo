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
            var root = new HierarchicalObjectImp();

            root.Foo = 10;
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

            static HierarchicalObjectImp()
            {
                // register the Foo property
                FooProperty = RegisterProperty(typeof(HierarchicalObjectImp), "Foo", typeof(int), true);
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
        }

        #endregion
    }


}
