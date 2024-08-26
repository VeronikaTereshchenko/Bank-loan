using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditInBank.Exceptions;
using CreditInBank.Services.ClientServices;

namespace CreditInBank.Services.BankServices
{
    public class Bank
    {
        public decimal BankMoney { get; set; }
        //сумма кредита, которую указывает пользователь
        //Amount of credit that the user specifies
        private decimal loanAmount;

        //оформление кредита
        //Credit processing
        public void LoanApply(Client client)
        {
            var bankMoneyBalance = BankMoney - loanAmount;

            //если в банке МЕНЬШЕ денег чем запрашивается
            //If bank has less money than rewquested
            try
            {
                if (bankMoneyBalance < 0)
                    throw new InvalidBankOperationExeption("There are not enough funds in the bank. The amount requested is greater than the bank's available money");

                BankMoney = bankMoneyBalance;
                //начисляем клаенту сумму кредита
                //Credit amount accurued to the customer
                client.AddLoanAmount(loanAmount);
                //Кредит оформлен. Сумма перечислена на Ваш счёт
                //The loan is processed/ The amount is transfered to the client's account
                Console.WriteLine($"The loan has been processed. The amount of {loanAmount} {Currency.rubbles} has been transferred to your account");
            }
            catch(InvalidBankOperationExeption ex)
            {
                //В банке недостаточно средств
                //There are not enough funds in the bank
                Console.WriteLine("В банке недостаточно средств");
            }
        }

        //просим ввести сумму кредита и вызываем операцию рассмотрения выдачи кредита
        //Ask to enter the loan amount and call the method of loan disbursement consideration
        public void LoanRequest(Client bankClient)
        {
            //пока в банке есть деньги, предлагаем взять кредит
            //While the bank has money we suggest take out a loan
            while (BankMoney >= 0)
            {
                ReadInputLoanValue();
                LoanApply(bankClient);
            }
        }

        //получение от пользователя суммы кредита
        //Recieve the loan amount from the client
        public void ReadInputLoanValue()
        {
            //пока клиент не введёт число, просить его ввести новое значение
            //until the client has entered a number, ask client to enter a new number
            while (true)
            {
                //просим пользователя ввести запрашиваемую сумму
                //Ask client to enter a new number
                Console.Write("\n\nSpecify the amount you want to receive from the bank: ");
                var inputLoan = Console.ReadLine();

                //определяем стиль числа и региональные параметры
                //Define number style and regional parameters
                var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
                var culture = CultureInfo.CreateSpecificCulture("ru-Ru");

                //если пользователь ввёл число больше 0, то больше НЕ отправляем запрос пользователю
                //If the client has entered a number > 0, then do NOT send the request to the user again
                if (decimal.TryParse(inputLoan, style, culture, out loanAmount) && loanAmount > 0)
                    break;
 
                Console.WriteLine("Incorrect amount. Please try again");
            }
        }

        //валюты
        //currency
        public enum Currency
        {
            rubbles,
            dollars,
            euros
        }
    }
}
