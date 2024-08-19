using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditInBank.Services.ClientServices
{
    public class Client
    {
        private decimal bankAccountAmount;

        //конструктор
        public Client(decimal bankAccountAmount)
        {
            this.bankAccountAmount = bankAccountAmount;
        }

        //возврат суммы на банковском счету клиента
        public decimal GetBankAccountAmount()
        {
            return bankAccountAmount;
        }

        //добавление суммы кредита на счёт клиента
        public void AddLoanAmount(decimal loanAmount)
        {
            bankAccountAmount += loanAmount;
        }
    }
}
