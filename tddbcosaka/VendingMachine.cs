using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tddbcosaka.Tests;

namespace tddbcosaka
{
    public class VendingMachine
    {
        private List<Money> amount = new List<Money>();
        private List<Money> changeBox = new List<Money>();
        public int ShowAmount()
        {
            return amount.Sum(m => m.value);
        }

        public void Insert(Money money)
        {
            if(IsReceivable(money))
            {
                amount.Add(money);
            }
            else
            {
                changeBox.Add(money);
            }
        }
        public bool IsReceivable(Money money)
        {
            return money.value == 10 ||
                money.value == 50 ||
                money.value == 100 ||
                money.value == 500 ||
                money.value == 1000;
        }

        public void Payback()
        {
            changeBox.AddRange(amount);
            amount.Clear();
        }

        public int ShowChangeBox()
        {
            return changeBox.Sum(m => m.value);
        }
    }
}
