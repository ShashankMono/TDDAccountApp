using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTesting.Exceptions
{
    internal class AmountInvalidException:Exception
    {
        public AmountInvalidException(string message) : base(message) { }
    }
}
