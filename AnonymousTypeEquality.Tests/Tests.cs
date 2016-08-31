using System;
using AnonymousTypeEquality.OtherNamespace;
using NUnit.Framework;
using OtherClasses;

namespace AnonymousTypeEquality.Tests {

    [TestFixture]
    public class Tests {
        [Test]
        public void BothInline() {
            var a = new { name = "test", value = 123 };
            var b = new { name = "test", value = 123 };
            Assert.That(Object.Equals(a,b)); // passes
        }

        [Test]
        public void FromLocalMethod() {
            var a = new { name = "test", value = 123 };
            var b = MakeObject("test", 123);
            Assert.That(Object.Equals(a, b)); // passes
        }

        [Test]
        public void FromOtherNamespace() {
            var a = new { name = "test", value = 123 };
            var b = OtherNamespaceClass.MakeObject("test", 123);
            Assert.That(Object.Equals(a, b)); // passes
        }


        [Test]
        public void FromOtherClass() {
            var a = new { name = "test", value = 123 };
            var b = OtherClass.MakeObject("test", 123);

            /* This is the test that fails, and I cannot work out why */
            Assert.That(Object.Equals(a, b));
        }

        private object MakeObject(string name, int value) {
            return new { name, value };
        }
    }
}
