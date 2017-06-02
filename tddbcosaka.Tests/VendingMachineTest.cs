using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tddbcosaka.Tests
{
    [TestFixture]
    public class VendingMachineTest
    {
        [Test]
        public void ShouldShowAmountInit()
        {
            var v = new VendingMachine();
            Assert.AreEqual(0, v.ShowAmount());
        }
        [TestCaseSource("MoneyTestCases")]
        public void ShouldShowAmount(Money money, int expected)
        {
            var v = new VendingMachine();
            v.Insert(money);
            Assert.AreEqual(expected, v.ShowAmount());
        }

        [TestCaseSource("MultiMoneyTestCases")]
        public void ShouldShowAmount(List<Money> money, int expected)
        {
            var v = new VendingMachine();
            foreach(var m in money)
            {
                v.Insert(m);
            }
            Assert.AreEqual(expected, v.ShowAmount());
        }

        [TestCaseSource("ReceivableMoneyTestCases")]
        public void ReceivableMoney(Money money, bool expected)
        {
            var v = new VendingMachine();
            Assert.AreEqual(expected, v.IsReceivable(money));
        }
        static object[] ReceivableMoneyTestCases = {
            new object[] { Money.Of(1), false },
            new object[] { Money.Of(5), false },
            new object[] { Money.Of(10), true },
            new object[] { Money.Of(50), true },
            new object[] { Money.Of(100), true },
            new object[] { Money.Of(500), true },
            new object[] { Money.Of(1000), true },
            new object[] { Money.Of(5000), false },
            new object[] { Money.Of(10000), false },
        };
        static object[] MoneyTestCases = {
            new object[] { Money.Of(1), 0 },
            new object[] { Money.Of(5), 0 },
            new object[] { Money.Of(10), 10 },
            new object[] { Money.Of(50), 50 },
            new object[] { Money.Of(100), 100 },
            new object[] { Money.Of(500), 500 },
            new object[] { Money.Of(1000), 1000 },
            new object[] { Money.Of(5000), 0 },
            new object[] { Money.Of(10000), 0 },
        };

        static object[] MultiMoneyTestCases = {
            new object[] { new List<Money>{ Money.Of(10), Money.Of(10), Money.Of(100) }, 120 },
            new object[] { new List<Money>{ Money.Of(10), Money.Of(10), Money.Of(1) }, 20 },
        };


        [TestCaseSource("MultiMoney")]
        public void ShouldAmountIs0WhenPaybacked(List<Money> money)
        {
            var v = new VendingMachine();
            foreach(var m in money)
            {
                v.Insert(m);
            }
            v.Payback();
            Assert.AreEqual(0, v.ShowAmount());
        }

        static object[] MultiMoney = {
            new object[] { new List<Money>{ Money.Of(10), Money.Of(10), Money.Of(100) } },
            new object[] { new List<Money>{ Money.Of(10), Money.Of(10), Money.Of(1) } },
        };

        [TestCaseSource("MultiMoney")]
        public void ShouldReturnAllMoneyWhenPaybacked(List<Money> money)
        {
            var v = new VendingMachine();
            foreach (var m in money)
            {
                v.Insert(m);
            }
            v.Payback();
            Assert.AreEqual(money.Sum(m => m.value), v.ShowChangeBox());
        }

    }
}
