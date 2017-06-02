using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tddbcosaka.Tests
{
    public class Money
    {
        public int value;
        private Money(int value)
        {
            this.value = value;
        }
        public static Money Of(int value)
        {
            if(IsValid(value) == false)
            {
                throw new ArgumentException("おかねじゃないよ");
            }
            return new Money(value);
        }

        public static bool IsValid(int value)
        {
            return value == 1 ||
                value == 5 ||
                value == 10 ||
                value == 50 ||
                value == 100 ||
                value == 500 ||
                value == 1000 ||
                value == 5000 ||
                value == 10000;
        }
    }
}
