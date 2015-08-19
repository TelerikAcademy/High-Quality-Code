namespace SolidAndOtherPrinciples.Tests
{
    using System;

    using NUnit.Framework;

    using SOLID_and_Other_Principles._3._Liskov_Substitution.VirtualCallInConstructor;

    [TestFixture]
    public class VirtualCallInConstructorTests
    {
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void DemonstrateVirtualCallInConstructor()
        {
            var baseClassImpl = new BaseClassImpl();
        }
    }
}
