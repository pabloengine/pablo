/* 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. 
 * 
 * Copyright (c) 2015, MPL Ali Taheri Moghaddar ali.taheri.m@gmail.com
 */

using NUnit.Framework;
using Pablo;
using System;

namespace HierarchyInfrastructure
{
    [TestFixture]
    public class CloneableObjectTest
    {
        [Test(Description = "Must make a new instance of GoodCloneableObject with matching field values.")]
        public void TestGoodCloneable()
        {
            var goodguy = new GoodCloneableObject();
            var goodGuy2 = (GoodCloneableObject)goodguy.Clone();
            Assert.AreEqual(goodguy.SomeProperty, goodGuy2.SomeProperty);
        }

        [Test(Description = "Must Throw CloneException that holds a reference to our badGuy and hold it's type.")]
        public void TestBadCloneable()
        {
            var badGuy = new BadCloneableObject(13);

            try
            {
                badGuy.Clone();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOf<CloneException>(e);
                Assert.AreSame(((CloneException)e).TargetObject, badGuy);
                Assert.AreSame(((CloneException)e).TargetType, badGuy.GetType());
                return;
            }
            Assert.Fail("The Exception must be thrown since its an unexpected case!");
        }

        [Test(Description = "Must Throw CloneException that holds a reference to our theLawyer and hold it's type.")]
        public void TestliarCloneable()
        {
            var theLawyer = new LiarCloneableObject(13);

            try
            {
                theLawyer.Clone();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOf<CloneException>(e);
                Assert.AreSame(((CloneException)e).TargetObject, theLawyer);
                Assert.AreSame(((CloneException)e).TargetType, theLawyer.GetType());
                return;
            }
            Assert.Fail("The Exception must be thrown since its an unexpected case!");
        }

        [Test(Description = "Must return a referenceEqual object if read only, and a new object otherwise.")]
        public void TestReadOnlyCloneable()
        {
            var cloneable = new GoodCloneableObject();

            Assert.AreNotSame(cloneable, cloneable.Clone());
            cloneable.IsReadOnly = true;
            Assert.AreSame(cloneable, cloneable.Clone());
            var mutableClone = (GoodCloneableObject)cloneable.MutableClone();
            Assert.AreNotSame(cloneable, mutableClone);
            Assert.DoesNotThrow(() => {
                mutableClone.SomeProperty = 7;
            });
        }

        [Test(Description = "Must throw exception if changed while read only.")]
        public void TestReadOnlyMutationCloneable()
        {
            var cloneable = new GoodCloneableObject();

            cloneable.IsReadOnly = true;

            Assert.Throws<InvalidOperationException>(() => {
                cloneable.IsReadOnly = false;
            }); // deja-vu...

            // This behavior is defined within the test, it's a simple reminder that this behavior
            // must be implemented on all Cloneables.
            Assert.Throws<InvalidOperationException>(() => {
                cloneable.SomeProperty = 1;
            });
        }

        #region Mock Implementations

        /// <summary>
        /// A nicely implemented <see cref="CloneableObject"/>.
        /// </summary>
        class GoodCloneableObject: CloneableObject
        {
            int _someProperty;

            public int SomeProperty
            {
                get
                {
                    return _someProperty;
                }
                set
                {
                    // Check for mutability on every mutating function.
                    if (IsReadOnly)
                        throw new InvalidOperationException("Read only objects cannot be mutated.");
                    _someProperty = value;
                }
            }

            public GoodCloneableObject()
            {
                SomeProperty = 7;
            }

            protected override void CloneOverride(CloneableObject clonableObject)
            {
                // It is a good practice to call the parent's CloneOverride in case
                // some properties must be set there.
                base.CloneOverride(clonableObject); 
                ((GoodCloneableObject)clonableObject).SomeProperty = SomeProperty;
            }
        }

        /// <summary>
        /// A badly implemented <see cref="CloneableObject"/>.
        /// </summary>
        class BadCloneableObject: CloneableObject
        {
            // No mutibility check: silent failure!
            public int SomeProperty{ get; set; }

            public BadCloneableObject(int badProperty) // No default constructor + no CreateInstanceOverride override
            {
                SomeProperty = badProperty;
            }

            protected override void CloneOverride(CloneableObject clonableObject)
            {
                // Not calling the base implementation version = bad.
                ((GoodCloneableObject)clonableObject).SomeProperty = SomeProperty;
            }
        }

        /// <summary>
        /// A liar Implementation of <see cref="CloneableObject"/>.
        /// </summary>
        class LiarCloneableObject: CloneableObject
        {
            // No mutibility check: silent failure!
            public int SomeProperty{ get; set; }

            public LiarCloneableObject(int badProperty)
            {
                SomeProperty = badProperty;
            }

            protected override void CloneOverride(CloneableObject clonableObject)
            {
                ((GoodCloneableObject)clonableObject).SomeProperty = SomeProperty;
            }

            protected override CloneableObject CreateInstanceOverride()
            {
                return new GoodCloneableObject(); // A "Lie" that results from careless copy-pastes.
            }
        }

        #endregion

    }
}
