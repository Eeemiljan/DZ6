using System;
using System.Collections.Generic;

abstract class TaskItem
{
    private string title = "Без названия";
    private int priority = 1;
    private DateTime deadline = DateTime.Today;
    private bool completed = false;

    public string Title
    {
        get
        {
            return title;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Название задачи не должно быть пустым.");
            }

            title = value;
        }
    }

    public int Priority
    {
        get
        {
            return priority;
        }

        set
        {
            if (value < 1 || value > 3)
            {
                throw new Exception("Приоритет должен быть от 1 до 3.");
            }

            priority = value;
        }
    }

    public DateTime Deadline
    {
        get
        {
            return deadline;
        }

        set
        {
            deadline = value.Date;
        }
    }

    public bool IsCompleted
    {
        get
        {
            return completed;
        }
    }

    public virtual void Complete()
    {
        completed = true;
    }

    public virtual void Postpone(int days)
    {
        if (days <= 0)
        {
            Console.WriteLine("Количество дней должно быть положительным.");
            return;
        }

        deadline = deadline.AddDays(days);
    }

    public virtual void IncreasePriority()
    {
        if (priority < 3)
        {
            priority++;
        }
        else
        {
            Console.WriteLine("У задачи уже максимальный приоритет.");
        }
    }

    public virtual string GetTaskType()
    {
        return "Задача";
    }

    public virtual void Show()
    {
        Console.WriteLine($"Тип: {GetTaskType()}");
        Console.WriteLine($"Заголовок: {Title}");
        Console.WriteLine($"Приоритет: {Priority}");
        Console.WriteLine($"Дедлайн: {Deadline:dd.MM.yyyy}");

        if (IsCompleted)
        {
            Console.WriteLine("Состояние: выполнена");
        }
        else
        {
            Console.WriteLine("Состояние: не выполнена");
        }

        Console.WriteLine();
    }
}

class WorkTask : TaskItem
{
    public WorkTask()
    {
        Title = "Рабочая задача";
        Priority = 1;
        Deadline = DateTime.Today;
    }

    public WorkTask(string title, int priority, DateTime deadline)
    {
        Title = title;
        Priority = priority;
        Deadline = deadline;
    }

    public override void Complete()
    {
        base.Complete();
        Console.WriteLine("Рабочая задача выполнена.");
    }

    public override void Postpone(int days)
    {
        base.Postpone(days);
    }

    public override void IncreasePriority()
    {
        base.IncreasePriority();
    }

    public override string GetTaskType()
    {
        return "Работа";
    }

    public override void Show()
    {
        base.Show();
    }
}

class StudyTask : TaskItem
{
    public StudyTask()
    {
        Title = "Учебная задача";
        Priority = 1;
        Deadline = DateTime.Today;
    }

    public StudyTask(string title, int priority, DateTime deadline)
    {
        Title = title;
        Priority = priority;
        Deadline = deadline;
    }

    public override void Complete()
    {
        base.Complete();
        Console.WriteLine("Учебная задача выполнена.");
    }

    public override void Postpone(int days)
    {
        base.Postpone(days);
    }

    public override void IncreasePriority()
    {
        base.IncreasePriority();
    }

    public override string GetTaskType()
    {
        return "Учёба";
    }

    public override void Show()
    {
        base.Show();
    }
}

class PersonalTask : TaskItem
{
    public PersonalTask()
    {
        Title = "Личная задача";
        Priority = 1;
        Deadline = DateTime.Today;
    }

    public PersonalTask(string title, int priority, DateTime deadline)
    {
        Title = title;
        Priority = priority;
        Deadline = deadline;
    }

    public override void Complete()
    {
        base.Complete();
        Console.WriteLine("Личная задача выполнена.");
    }

    public override void Postpone(int days)
    {
        base.Postpone(days);
    }

    public override void IncreasePriority()
    {
        base.IncreasePriority();
    }

    public override string GetTaskType()
    {
        return "Личное";
    }

    public override void Show()
    {
        base.Show();
    }
}

class Program
{
    static void ShowAll(List<TaskItem> tasks)
    {
        Console.WriteLine("Все задачи:");
        Console.WriteLine();

        foreach (TaskItem task in tasks)
        {
            task.Show();
        }
    }

    static void GroupByType(List<TaskItem> tasks)
    {
        string[] types = { "Работа", "Учёба", "Личное" };

        Console.WriteLine("Задачи по типам:");

        foreach (string type in types)
        {
            Console.WriteLine($"===== {type} =====");

            foreach (TaskItem task in tasks)
            {
                if (task.GetTaskType() == type)
                {
                    task.Show();
                }
            }
        }
    }

    static void ShowOverdue(List<TaskItem> tasks)
    {
        Console.WriteLine("Просроченные невыполненные задачи:");
        Console.WriteLine();

        bool found = false;

        foreach (TaskItem task in tasks)
        {
            if (!task.IsCompleted && task.Deadline < DateTime.Today)
            {
                task.Show();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Просроченных задач нет.");
            Console.WriteLine();
        }
    }

    static void ShowSummary(List<TaskItem> tasks)
    {
        int completedCount = 0;

        foreach (TaskItem task in tasks)
        {
            if (task.IsCompleted)
            {
                completedCount++;
            }
        }

        Console.WriteLine($"Всего задач: {tasks.Count}");
        Console.WriteLine($"Выполнено: {completedCount}");
        Console.WriteLine($"Осталось: {tasks.Count - completedCount}");
    }

    static void Main()
    {
        Console.WriteLine("Проект 6. Тема 9. Типы задач в списке дел.");
        Console.WriteLine("Работа, учёба и личные дела имеют общие данные и действия.");
        Console.WriteLine("Приоритет: 1 — низкий, 2 — средний, 3 — высокий.");
        Console.WriteLine("Просроченной считаем невыполненную задачу со сроком раньше сегодня.");
        Console.WriteLine("Данные заданы в коде. Ввод не требуется.");
        Console.WriteLine();

        try
        {
            WorkTask work1 = new WorkTask();
            work1.Title = "Подготовить отчёт";
            work1.Deadline = DateTime.Today.AddDays(-3);

            WorkTask work2 = new WorkTask(
                "Отправить документы",
                2,
                DateTime.Today.AddDays(3));

            StudyTask study1 = new StudyTask();
            study1.Title = "Решить задачи по C#";
            study1.Deadline = DateTime.Today.AddDays(-1);

            StudyTask study2 = new StudyTask(
                "Подготовиться к зачёту",
                2,
                DateTime.Today.AddDays(7));

            PersonalTask personal1 = new PersonalTask();
            personal1.Title = "Купить продукты";
            personal1.Deadline = DateTime.Today.AddDays(-2);

            PersonalTask personal2 = new PersonalTask(
                "Записаться на тренировку",
                1,
                DateTime.Today.AddDays(2));

            List<TaskItem> tasks = new List<TaskItem>();

            tasks.Add(work1);
            tasks.Add(work2);
            tasks.Add(study1);
            tasks.Add(study2);
            tasks.Add(personal1);
            tasks.Add(personal2);

            ShowAll(tasks);
            ShowOverdue(tasks);

            Console.WriteLine("Демонстрация изменения задач:");
            Console.WriteLine();

            Console.WriteLine("Переносим подготовку отчёта на 4 дня вперёд.");
            work1.Postpone(4);
            work1.IncreasePriority();
            work1.Show();

            Console.WriteLine("Повышаем приоритет решения задач по C#.");
            study1.IncreasePriority();
            Console.WriteLine("Отмечаем учебную задачу как выполненную.");
            study1.Complete();
            study1.Show();

            Console.WriteLine("Повышаем приоритет покупки продуктов.");
            personal1.IncreasePriority();
            personal1.Show();

            GroupByType(tasks);
            ShowOverdue(tasks);
            ShowSummary(tasks);
        }
        catch (Exception error)
        {
            Console.WriteLine($"Ошибка: {error.Message}");
        }
    }
}