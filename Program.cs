//деньги в банке
using System.Data;

internal class Program
{
    public static void RequestNumberInput(out string inputLoan)
    {
        //Укажите сумму, которую хотите получить от банка
        Console.Write("Specify the amount you want to receive from the bank: ");
        inputLoan = Console.ReadLine();
        //если пользователь указал запятую вместо точки в числе
        inputLoan.Replace(",", ".");
    }
    private static void ReadInputLoanValue(ref double loan)
    {
        string inputLoan;
        
        //пока клиент не введёт число, просить его ввести новое значение
        while (true)
        {
            //просим пользователя ввести запрашиваемую сумму
            RequestNumberInput(out inputLoan);

            //Если пользователь ввёл число,
            //то выходим из цикла
            if (double.TryParse(inputLoan, out loan))
                break;

            //Вы ввели не число. Попробуйте, пожалуйста, снова  
            Console.WriteLine("\n\nIncorrect amount. Please try again");
        }
    } 

    private static void Main(string[] args)
    {
        //деньги банка
        double bankMoney = 10000;
        //остаток денег в банке после предоставления кредита клиенту
        double bankMoneyBalance = 0;
        //деньги на счету клиента
        double personMoney = 0;
        //кредит или заём
        double loan = 0;

        if (bankMoney <= 0)
        {
            //В настоящий момент банк не поддерживает оформление кредитов. Приносим свои извинения
            Console.WriteLine("At the moment the bank does not support the processing of loans. We apologise");
        }
        else
        {
            ReadInputLoanValue(ref loan);

            if (loan == 0)
            {
                //на указанную суму кредит не предоставляется
                Console.WriteLine($"No credit will be granted for {loan} {Currency.rubbles}\n\n");
                ReadInputLoanValue(ref loan);
            }

            try
            {
                bankMoneyBalance = bankMoney - loan;

                if (bankMoneyBalance <= 0)
                    //Недостаточно средств в банке
                    throw new InvalidBankOperationExeption("There are not enough funds in the bank", "code line 67. The amount requested is greater than the bank's available money");
                else
                {
                    bankMoneyBalance = bankMoney - loan;
                    personMoney += loan;
                    //Кредит оформлен. Сумма перечислена на Ваш счёт
                    Console.WriteLine($"The loan has been processed. The amount of {loan} {Currency.rubbles} has been transferred to your account");
                }
            }
            catch (InvalidBankOperationExeption ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ExeptionDiscription);
            }
        }
    }
}

public class InvalidBankOperationExeption : InvalidOperationException
{
    public string ExeptionDiscription { get; private set; }

    public InvalidBankOperationExeption(string message, string discription) : base(message) 
    {
        ExeptionDiscription = discription;
    }
}

//Валюта
public enum Currency
{
    rubbles,
    dollar,
    euro
}
