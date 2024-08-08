//деньги в банке
using System.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        double bankMoney = 10000.0;
        //остаток денег в банке после предоставления кредита клиенту
        double bankMoneyBalance = 0.0;
        double personMoney = 0.0;
        //кредит или заём
        double loan = 0;
        Console.Write("Укажите сумму, которые хотите получить от банка: ");
        string inputLoan = Console.ReadLine();

        if (!double.TryParse(inputLoan, out loan))
        {
            Console.WriteLine("Вы ввели не число. Попробуйте, пожалуйста, снова");
            Main(new string[0]);
            return;
        }


        try
        {
            bankMoneyBalance = bankMoney - loan;

            if (bankMoneyBalance < 0)
                throw new Exception("В банке недостаточно средств");
            else if (bankMoneyBalance == 0)
                throw new Exception("Банк не может предоставить кредит");
            else
            {
                bankMoneyBalance = bankMoney - loan;
                personMoney += loan;
                Console.WriteLine($"Кредит оформлен. Сумма в размере {loan} перечислена на Ваш счёт");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            //закрыть ресурс
        }
    }
}