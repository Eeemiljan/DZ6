using System;

enum BankAccountType
{
    Current,
    Savings
}

class BankAccount
{
    private static int lastNumber = 1000;

    private int number;
    private decimal balance;
    private BankAccountType type;

    private static int GenerateNumber()
    {
        lastNumber++;
        return lastNumber;
    }

    public BankAccount()
    {
        number = GenerateNumber();
    }

    public void SetData(decimal balance, BankAccountType type)
    {
        this.balance = balance;
        this.type = type;
    }

    public int GetNumber()
    {
        return number;
    }

    public decimal GetBalance()
    {
        return balance;
    }

    public BankAccountType GetAccountType()
    {
        return type;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Упражнение 7.2. Уникальные номера банковских счетов.");
        Console.WriteLine("Данные заданы в коде. Ввод не требуется.");

        BankAccount first = new BankAccount();
        first.SetData(15000m, BankAccountType.Current);

        BankAccount second = new BankAccount();
        second.SetData(25000m, BankAccountType.Savings);

        Console.WriteLine("Первый счёт:");
        Console.WriteLine($"Номер: {first.GetNumber()}");
        Console.WriteLine($"Баланс: {first.GetBalance():F2}");
        Console.WriteLine($"Тип: {first.GetAccountType()}");

        Console.WriteLine();

        Console.WriteLine("Второй счёт:");
        Console.WriteLine($"Номер: {second.GetNumber()}");
        Console.WriteLine($"Баланс: {second.GetBalance():F2}");
        Console.WriteLine($"Тип: {second.GetAccountType()}");

        Console.WriteLine("Current — текущий, Savings — сберегательный.");
    }
}