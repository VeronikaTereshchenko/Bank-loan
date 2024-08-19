using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditInBank.Services.ClientServices
{
    public class Client
    {
        //сумма денег у клиента на банковском счету
        private decimal bankAccountAmount;

        public Client(decimal bankAccountAmount)
        {
            this.bankAccountAmount = bankAccountAmount;
        }

        //добавление суммы кредита на счёт клиента
        public void AddLoanAmount(decimal loanAmount)
        {
            bankAccountAmount += loanAmount;
        }
    }
}
