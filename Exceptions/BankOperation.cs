using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditInBank.Exceptions
{
    internal class BankOperation
    {
        public class InvalidBankOperationExeption : InvalidOperationException
        {
            public InvalidBankOperationExeption(string message) : base(message)
            {
            }
        }
    }
}
