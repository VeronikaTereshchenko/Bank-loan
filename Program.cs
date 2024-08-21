using System.Globalization;
using CreditInBank.Exceptions;
using CreditInBank.Services.BankServices;
using CreditInBank.Services.ClientServices;

internal class Program
{
    public static void Main(string[] args)
    {
        Bank bank = new Bank() { BankMoney = 1000 };
        Client bankClient = new Client(0);
        
        //рассмотрение заявки на кредит
        bank.LoanRequest(bankClient);
    }
}
