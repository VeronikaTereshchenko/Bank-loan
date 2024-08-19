using System.Globalization;
using CreditInBank.Exceptions;
using CreditInBank.Services.BankServices;
using CreditInBank.Services.ClientServices;

internal class Program
{
    public static void Main(string[] args)
    {
        Bank bank = new Bank(1000);

        //bank client
        Client bankClient = new Client(0);

        bank.LoanRequest(bankClient);
    }
}

//class Bank
//{
//    private decimal bankMoney;
//    private decimal loanAmount;

//    public Bank(decimal bankMoney)
//    {
//        this.bankMoney = bankMoney;
//    }
//    //деньги банка
//    public decimal GetBankMoney()
//    {
//        return bankMoney;
//    }

//    //оформление кредита
//    public void LoanApply(Client client)
//    {
//        decimal bankMoneyBalance = bankMoney - loanAmount;

//        //если в банке МЕНЬШЕ денег чем запрашивается
//        if (bankMoneyBalance < 0)
//            throw new InvalidBankOperationExeption("There are not enough funds in the bank. The amount requested is greater than the bank's available money");

//        bankMoney = bankMoneyBalance;
//        client.AddLoanAmount(loanAmount);

//        //Кредит оформлен. Сумма перечислена на Ваш счёт
//        Console.WriteLine($"The loan has been processed. The amount of {loanAmount} {Currency.rubbles} has been transferred to your account");
//    }

//    public void LoanRequest(Client bankClient)
//    {
//        //пока в банке есть деньги, предлагаем взять кредит
//        while (bankMoney >= 0)
//        {
//            ReadInputLoanValue();
//            LoanApply(bankClient);
//        }
//    }

//    public void ReadInputLoanValue()
//    {
//        //пока клиент не введёт число, просить его ввести новое значение
//        while (true)
//        {
//            //просим пользователя ввести запрашиваемую сумму
//            Console.Write("\n\nSpecify the amount you want to receive from the bank: ");
//            string inputLoan = Console.ReadLine();

//            //определяем стиль числа и региональные параметры
//            NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
//            CultureInfo culture = CultureInfo.CreateSpecificCulture("ru-Ru");

//            //если пользователь ввёл число больше 0, то больше НЕ отправляем запрос пользователю
//            if (decimal.TryParse(inputLoan, style, culture, out loanAmount) && loanAmount > 0)
//                break;

//            //Вы ввели не число. Попробуйте, пожалуйста, снова  
//            Console.WriteLine("Incorrect amount. Please try again");
//        }
//    }

//    public enum Currency
//    {
//        rubbles,
//        dollars,
//        euros
//    }
//}

//class Client
//{
//    private decimal bankAccountAmount;

//    //конструктор
//    public Client(decimal bankAccountAmount)
//    {
//        this.bankAccountAmount = bankAccountAmount;
//    }

//    //возврат суммы на банковском счету клиента
//    public decimal GetBankAccountAmount()
//    {
//        return this.bankAccountAmount;
//    }

//    //добавление суммы кредита на счёт клиента
//    public void AddLoanAmount(decimal loanAmount)
//    {
//        bankAccountAmount += loanAmount;
//    }
//}