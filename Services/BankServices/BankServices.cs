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
        //деньги, принадлежащие банку
        private decimal bankMoney;
        //сумма кредита, которую указывает пользователь
        private decimal loanAmount;

        public Bank(decimal bankMoney)
        {
            this.bankMoney = bankMoney;
        }

        //получить значение банковских денег
        public decimal GetBankMoney()
        {
            return bankMoney;
        }

        //оформление кредита
        public void LoanApply(Client client)
        {
            var bankMoneyBalance = bankMoney - loanAmount;

            //если в банке МЕНЬШЕ денег чем запрашивается
            if (bankMoneyBalance < 0)
                throw new InvalidBankOperationExeption("There are not enough funds in the bank. The amount requested is greater than the bank's available money");

            bankMoney = bankMoneyBalance;
            client.AddLoanAmount(loanAmount);

            //Кредит оформлен. Сумма перечислена на Ваш счёт
            Console.WriteLine($"The loan has been processed. The amount of {loanAmount} {Currency.rubbles} has been transferred to your account");
        }

        //просим ввести сумму кредита и вызываем операцию рассмотрения выдачи кредита
        public void LoanRequest(Client bankClient)
        {
            //пока в банке есть деньги, предлагаем взять кредит
            while (bankMoney >= 0)
            {
                ReadInputLoanValue();
                LoanApply(bankClient);
            }
        }

        //получение от пользователя суммы кредита
        public void ReadInputLoanValue()
        {
            //пока клиент не введёт число, просить его ввести новое значение
            while (true)
            {
                //просим пользователя ввести запрашиваемую сумму
                Console.Write("\n\nSpecify the amount you want to receive from the bank: ");
                string inputLoan = Console.ReadLine();

                //определяем стиль числа и региональные параметры
                NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
                CultureInfo culture = CultureInfo.CreateSpecificCulture("ru-Ru");

                //если пользователь ввёл число больше 0, то больше НЕ отправляем запрос пользователю
                if (decimal.TryParse(inputLoan, style, culture, out loanAmount) && loanAmount > 0)
                    break;

                //Вы ввели не число. Попробуйте, пожалуйста, снова  
                Console.WriteLine("Incorrect amount. Please try again");
            }
        }

        //валюты
        public enum Currency
        {
            rubbles,
            dollars,
            euros
        }
    }
}
