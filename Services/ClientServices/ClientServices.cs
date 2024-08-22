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
        //customer's money on the bank account
        public decimal BankAccountAmount { get; private set; }

        //Ыet the amount on the client's account
        public void SetBankAccountAmount(decimal amount)
        {
            BankAccountAmount = amount;
        }

        //добавление суммы кредита на счёт клиента
        //Add loan amount to the customer's account
        public void AddLoanAmount(decimal loanAmount)
        {
            BankAccountAmount += loanAmount;
        }
    }
}
