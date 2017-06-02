using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tddbcosaka.Tests
{
    [TestFixture]
    class MoneyTest
    {
        [TestCase(1, true)]
        [TestCase(5, true)]
        [TestCase(10, true)]
        [TestCase(50, true)]
        [TestCase(100, true)]
        [TestCase(500, true)]
        [TestCase(1000, true)]
        [TestCase(5000, true)]
        [TestCase(10000, true)]
        [TestCase(3, false)]
        public void IsValidMoney(int value, bool expected)
        {
            Assert.AreEqual(expected, Money.IsValid(value));
        }
        [TestCase(-1)]
        [TestCase(3)]
        public void IsInValidMoney(int value)
        {
            Assert.Catch<ArgumentException>(() => Money.Of(value));
        }
    }
}
