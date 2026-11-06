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
        if (balance < 0)
        {
            Console.WriteLine("Начальный баланс не может быть отрицательным.");
            return;
        }

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

    public bool Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        balance = balance + amount;
        return true;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > balance)
        {
            return false;
        }

        balance = balance - amount;
        return true;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Упражнение 7.3. Пополнение и снятие денег.");
        Console.WriteLine("Суммы заданы в коде. Ввод не требуется.");

        BankAccount account = new BankAccount();
        account.SetData(15000m, BankAccountType.Current);

        Console.WriteLine($"Номер счёта: {account.GetNumber()}");
        Console.WriteLine($"Тип счёта: {account.GetAccountType()}");
        Console.WriteLine("Current — текущий, Savings — сберегательный.");
        Console.WriteLine($"Начальный баланс: {account.GetBalance():F2}");

        Console.WriteLine();
        Console.WriteLine("Пополнение на 5000:");

        if (account.Deposit(5000m))
        {
            Console.WriteLine("Пополнение выполнено.");
        }
        else
        {
            Console.WriteLine("Сумма пополнения должна быть положительной.");
        }

        Console.WriteLine($"Баланс: {account.GetBalance():F2}");

        Console.WriteLine();
        Console.WriteLine("Снятие 3000:");

        if (account.Withdraw(3000m))
        {
            Console.WriteLine("Снятие выполнено.");
        }
        else
        {
            Console.WriteLine("Недостаточно денег или сумма неверная.");
        }

        Console.WriteLine($"Баланс: {account.GetBalance():F2}");

        Console.WriteLine();
        Console.WriteLine("Попытка снять 20000:");

        if (account.Withdraw(20000m))
        {
            Console.WriteLine("Снятие выполнено.");
        }
        else
        {
            Console.WriteLine("Недостаточно денег или сумма неверная.");
        }

        Console.WriteLine($"Баланс: {account.GetBalance():F2}");
    }
}