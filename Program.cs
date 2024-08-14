using CreditInBank.Exceptions;
using System.Globalization;
using static CreditInBank.Exceptions.BankOperation;


internal class Program
{
    public static void Main(string[] args)
    {
        //bank
        Bank bank = new Bank() { BankMoney = 1000, ConsoleInteraction = new ConsoleInteraction() };

        //bank client
        Person bankClient = new Person();

        bank.LoanRequest(bankClient);
    }
}

//обработка входных данных с консоли
class ConsoleInteraction
{
    public decimal loan;

    public void ReadInputLoanValue()
    {
        string inputLoan;

        //пока клиент не введёт число, просить его ввести новое значение
        while (true)
        {
            //просим пользователя ввести запрашиваемую сумму
            Console.Write("\n\nSpecify the amount you want to receive from the bank: ");
            inputLoan = Console.ReadLine();

            //определяем стиль числа и региональные параметры
            NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("ru-Ru");

            //если пользователь ввёл число больше 0, то больше НЕ отправляем запрос пользователю
            if (decimal.TryParse(inputLoan, style, culture, out loan) && loan > 0)
                break;

            //Вы ввели не число. Попробуйте, пожалуйста, снова  
            Console.WriteLine("Incorrect amount. Please try again");
        }
    }
}

class Bank
{
    //деньги банка
    public decimal BankMoney { get; set; }
    public ConsoleInteraction ConsoleInteraction { get; set; }

    //оформление кредита
    public void LoanApply(Person client)
    {
        decimal bankMoneyBalance = BankMoney - ConsoleInteraction.loan;

        //если в банке МЕНЬШЕ денег чем запрашивается
        if (bankMoneyBalance < 0)
            throw new InvalidBankOperationExeption("There are not enough funds in the bank. The amount requested is greater than the bank's available money");

        BankMoney = bankMoneyBalance;
        client.BankAccountAmount += ConsoleInteraction.loan;

        //Кредит оформлен. Сумма перечислена на Ваш счёт
        Console.WriteLine($"The loan has been processed. The amount of {ConsoleInteraction.loan} {Currency.rubbles} has been transferred to your account");
    }

    public void LoanRequest(Person bankClient)
    {
        while (BankMoney >= 0)
        {
            ConsoleInteraction.ReadInputLoanValue();
            LoanApply(bankClient);
        }
    }

    public enum Currency
    {
        rubbles,
        dollars,
        euros
    }
}

class Person
{
    //сумма на банковском счету
    public decimal BankAccountAmount { get; set; }
}