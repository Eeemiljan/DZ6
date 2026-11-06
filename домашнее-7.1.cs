using System;

class Building
{
    private static int lastNumber = 0;

    private int number;
    private double height;
    private int floors;
    private int apartments;
    private int entrances;

    private static int GenerateNumber()
    {
        lastNumber++;
        return lastNumber;
    }

    public Building()
    {
        number = GenerateNumber();
    }

    public void SetData(double height, int floors, int apartments, int entrances)
    {
        if (height <= 0 || floors <= 0 || apartments <= 0 || entrances <= 0)
        {
            throw new Exception("Все параметры здания должны быть положительными.");
        }

        this.height = height;
        this.floors = floors;
        this.apartments = apartments;
        this.entrances = entrances;
    }

    public int GetNumber()
    {
        return number;
    }

    public double GetHeight()
    {
        return height;
    }

    public int GetFloors()
    {
        return floors;
    }

    public int GetApartments()
    {
        return apartments;
    }

    public int GetEntrances()
    {
        return entrances;
    }

    public double GetFloorHeight()
    {
        return height / floors;
    }

    public int GetApartmentsPerEntrance()
    {
        return apartments / entrances;
    }

    public int GetApartmentsPerFloor()
    {
        return apartments / entrances / floors;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Домашнее задание 7.1. Описание здания.");
        Console.WriteLine("Данные заданы в коде. Ввод не требуется.");
        Console.WriteLine("Считаем, что этажи одинаковой высоты,");
        Console.WriteLine("а квартиры распределены поровну по подъездам и этажам.");

        try
        {
            Building first = new Building();
            first.SetData(30, 10, 80, 2);

            Building second = new Building();
            second.SetData(36, 12, 144, 3);

            Console.WriteLine();
            Console.WriteLine("Первое здание:");
            Console.WriteLine($"Номер: {first.GetNumber()}");
            Console.WriteLine($"Высота: {first.GetHeight()} м");
            Console.WriteLine($"Этажей: {first.GetFloors()}");
            Console.WriteLine($"Квартир: {first.GetApartments()}");
            Console.WriteLine($"Подъездов: {first.GetEntrances()}");
            Console.WriteLine($"Высота этажа: {first.GetFloorHeight():F2} м");
            Console.WriteLine($"Квартир в подъезде: {first.GetApartmentsPerEntrance()}");
            Console.WriteLine($"Квартир на этаже одного подъезда: {first.GetApartmentsPerFloor()}");

            Console.WriteLine();
            Console.WriteLine("Второе здание:");
            Console.WriteLine($"Номер: {second.GetNumber()}");
            Console.WriteLine($"Высота: {second.GetHeight()} м");
            Console.WriteLine($"Этажей: {second.GetFloors()}");
            Console.WriteLine($"Квартир: {second.GetApartments()}");
            Console.WriteLine($"Подъездов: {second.GetEntrances()}");
            Console.WriteLine($"Высота этажа: {second.GetFloorHeight():F2} м");
            Console.WriteLine($"Квартир в подъезде: {second.GetApartmentsPerEntrance()}");
            Console.WriteLine($"Квартир на этаже одного подъезда: {second.GetApartmentsPerFloor()}");
        }
        catch (Exception error)
        {
            Console.WriteLine($"Ошибка: {error.Message}");
        }
    }
}