using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingPlan
{
    static class IntegerExtensions
    {
        public static AccountType AccountType(this int number)
        {
            return (AccountType)Enum.ToObject(typeof(AccountType), number);
        }
    }
}
