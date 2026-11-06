using System;

enum BankAccountType
{
    Current,
    Savings
}

class BankAccount
{
    private string number = "";
    private decimal balance;
    private BankAccountType type;

    public void SetData(string number, decimal balance, BankAccountType type)
    {
        this.number = number;
        this.balance = balance;
        this.type = type;
    }

    public string GetNumber()
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
        Console.WriteLine("Упражнение 7.1. Банковский счёт с закрытыми полями.");
        Console.WriteLine("Данные заданы в коде. Ввод не требуется.");

        BankAccount account = new BankAccount();

        account.SetData("123456789", 15000m, BankAccountType.Current);

        Console.WriteLine($"Номер счёта: {account.GetNumber()}");
        Console.WriteLine($"Баланс: {account.GetBalance():F2}");
        Console.WriteLine($"Тип счёта: {account.GetAccountType()}");
        Console.WriteLine("Current — текущий, Savings — сберегательный.");
    }
}