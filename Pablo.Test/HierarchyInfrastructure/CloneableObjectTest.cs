using NUnit.Framework;
using Pablo;
using System;
using NUnit.Framework.Constraints;

namespace HierarchyInfrastructure
{
    [TestFixture]
    public class CloneableObjectTest
    {
        GoodCloneableObject _goodGuy;
        BadCloneableObject _badGuy;
        LiarCloneableObject _theLawyer;

        [SetUp]
        public void Setup()
        {
            _goodGuy = new GoodCloneableObject();
            _badGuy = new BadCloneableObject(13);
            _theLawyer = new LiarCloneableObject(999);
        }

        [TestCase(Description = "Must make a new instance of GoodCloneableObject and check the property.")]
        public void TestGoodClonable()
        {
            var goodGuy2 = (GoodCloneableObject)_goodGuy.Clone();
            Assert.AreEqual(_goodGuy.SomeProperty, goodGuy2.SomeProperty);
        }

        [TestCase(Description = "Must Throw CloneException that holds a reference to our _badGuy and hold it's type.")]
        public void TestBadClonable()
        {
            try
            {
                _badGuy.Clone();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOf<CloneException>(e);
                Assert.AreSame(((CloneException)e).TargetObject, _badGuy);
                Assert.AreSame(((CloneException)e).TargetType, _badGuy.GetType());
                return;
            }
            Assert.Fail("The Exception must be thrown since its an unexpected case!");
        }

        [TestCase(Description = "Must Throw CloneException that holds a reference to our Lawyer and hold it's type.")]
        public void TestliarClonable()
        {
            try
            {
                _theLawyer.Clone();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOf<CloneException>(e);
                Assert.AreSame(((CloneException)e).TargetObject, _theLawyer);
                Assert.AreSame(((CloneException)e).TargetType, _theLawyer.GetType());
                return;
            }
            Assert.Fail("The Exception must be thrown since its an unexpected case!");
        }

        /// <summary>
        /// A nicely implemented <see cref="CloneableObject"/>.
        /// </summary>
        class GoodCloneableObject: CloneableObject
        {
            public int SomeProperty{ get; set; }

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
    }
}