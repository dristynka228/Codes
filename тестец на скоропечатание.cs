using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

public class User
{
    public string Name { get; set; }
    public int CharactersPerMinute { get; set; }
    public int CharactersPerSecond { get; set; }
}

public static class Scoreboard
{
    private static List<User> users = new List<User>();

    public static void AddUser(User user)
    {
        users.Add(user);
    }

    public static void Display()
    {
        Console.WriteLine("Таблица рекордов:");
        Console.WriteLine("Имя\tСимволов в минуту\tСимволов в секунду");
        foreach (var user in users.OrderByDescending(u => u.CharactersPerMinute))
        {
            Console.WriteLine($"{user.Name}\t{user.CharactersPerMinute}\t\t\t{user.CharactersPerSecond}");
        }
    }

    public static void SaveToFile(string fileName)
    {
        using (StreamWriter file = File.CreateText(fileName))
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.Serialize(file, users);
        }
    }

    public static void LoadFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            using (StreamReader file = File.OpenText(fileName))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                users = (List<User>)serializer.Deserialize(file, typeof(List<User>));
            }
        }
    }
}

public class TypingTest
{
    private string text;
    private int currentIndex;
    private DateTime startTime;
    private Timer timer;

    public TypingTest(string text)
    {
        this.text = text;
    }

    public void Start()
    {
        Console.WriteLine("Введи имя: ");
        string name = Console.ReadLine();

        User user = new User { Name = name };

        Console.WriteLine("Текст для набора:");
        Console.WriteLine(text);

        Console.WriteLine("Нажми Enter, чтобы начать набирать текст");
        Console.ReadLine();

        currentIndex = 0;
        startTime = DateTime.Now;

        timer = new Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            if (key.KeyChar != '\r') 
            {
                Console.ForegroundColor = text[currentIndex] == key.KeyChar ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write(key.KeyChar);
                currentIndex++;
            }
        } while (currentIndex < text.Length);

        Console.WriteLine();
        Console.ResetColor();

        timer.Dispose();

        user.CharactersPerMinute = (int)(text.Length / (DateTime.Now - startTime).TotalMinutes);
        user.CharactersPerSecond = (int)(text.Length / (DateTime.Now - startTime).TotalSeconds);

        Scoreboard.AddUser(user);
        Scoreboard.Display();
    }

    private void TimerCallback(object state)
    {
        TimeSpan elapsedTime = DateTime.Now - startTime;
        Console.SetCursorPosition(Console.WindowWidth - 8, 0);
        Console.Write($"{(int)elapsedTime.TotalSeconds:D2}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Scoreboard.LoadFromFile("scoreboard.json");

        string text = "Цель игрока — продвигаться по игровой трофейной дороге, участвовать в боях с другими игроками, а также открывать и улучшать новых игровых персонажей с уникальными способностями и характеристиками.\r\n\r\nГеймплей игры сосредоточен на том, чтобы в одиночку, командой из двоих человек или в кооперативе из троих или пяти человек победить команду других игроков, или противника под руководством ИИ, в разнообразных игровых режимах. Игроки могут выбрать персонажей, каждый из которых имеет свои навыки и суперспособность. Персонажей можно получить во внутриигровом магазине за кредиты, а гаджеты, звёздные силы и снаряжение — купив за монеты.";

        TypingTest typingTest = new TypingTest(text);
        typingTest.Start();

        Scoreboard.SaveToFile("scoreboard.json");

        Console.WriteLine("Нажми Enter, чтобы выйти");
        Console.ReadLine();
    }
}
