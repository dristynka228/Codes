using System;
using System.Collections.Generic;

public class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string AdditionalInfo { get; set; }
}

public class DailyPlanner
{
    private List<Note> notes;
    private int currentIndex;

    public DailyPlanner()
    {
        notes = new List<Note>
        {
            new Note
            {
                Title = "Заметочка 1",
                Description = "Поиграть в геншинимпакт",
                Date = new DateTime(2023, 5, 6),
                AdditionalInfo = "Надо накопить миллион круток и задонатить миллион рублей"
            },
            new Note
            {
                Title = "Заметочка 2",
                Description = "Сходить на пары",
                Date = new DateTime(2023, 5, 8),
                AdditionalInfo = "Прийти на пары, чтобы ничего не делать как обычно"
            },
            new Note
            {
                Title = "Заметочка 3",
                Description = "Сходить на пары",
                Date = new DateTime(2023, 5, 13),
                AdditionalInfo = "Опять прийти на пары, по желанию. Сделать миллиард практических"
            },
            new Note
            {
                Title = "Заметочка 4",
                Description = "Сделать практическую",
                Date = new DateTime(2023, 5, 18),
                AdditionalInfo = "Сделать практическую на С# по созданию ежедневничка"
            },
            new Note
            {
                Title = "Заметочка 5",
                Description = "Отчислиться",
                Date = new DateTime(2023, 5, 27),
                AdditionalInfo = "Зачем вообще нужно обучение в МПТ, лучше сразу отчислиться и на помойку"
            },

        };

        currentIndex = 0;
    }

    public void Run()
    {
        Console.WriteLine("Ежедневничек");

        while (true)
        {
            Console.Clear();
            PrintMenu();
            HandleInput();
        }
    }

    private void PrintMenu()
    {
        Console.WriteLine("Меню:");
        Console.WriteLine();

        for (int i = 0; i < notes.Count; i++)
        {
            string title = notes[i].Title;

            if (i == currentIndex)
                title = $"> {title} <";

            Console.WriteLine(title);
        }
    }

    private void PrintNoteInfo(Note note)
    {
        Console.Clear();
        Console.WriteLine("Вся информация о заметочке:");
        Console.WriteLine();
        Console.WriteLine($"Название: {note.Title}");
        Console.WriteLine($"Описание: {note.Description}");
        Console.WriteLine($"Дата: {note.Date.ToShortDateString()}");
        Console.WriteLine($"Дополнительная информация: {note.AdditionalInfo}");
        Console.WriteLine();
        Console.WriteLine("Тыкни Enter для продолжения...");
        Console.ReadLine();
    }

    private void HandleInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();

        if (keyInfo.Key == ConsoleKey.RightArrow)
        {
            currentIndex = (currentIndex + 1) % notes.Count; 
        }
        else if (keyInfo.Key == ConsoleKey.LeftArrow)
        {
            currentIndex = (currentIndex + notes.Count - 1) % notes.Count; 
        }
        else if (keyInfo.Key == ConsoleKey.Enter)
        {
            PrintNoteInfo(notes[currentIndex]); 
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        DailyPlanner dailyPlanner = new DailyPlanner();
        dailyPlanner.Run();
    }
}
