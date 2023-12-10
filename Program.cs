using System;
using System.Collections.Generic;
using System.Threading;

public enum MapBorders
{
    MaxRight = 40,
    MaxBottom = 20
}

public class SnakeGame
{
    private List<(int, int)> snake;
    private Tuple<int, int> food;
    private bool isGameOver;

    public SnakeGame()
    {
        snake = new List<(int, int)>
        {
            (10, 10),
            (10, 11),
            (10, 12)
        };
        food = GenerateFoodLocation();
        isGameOver = false;
    }

    private Tuple<int, int> GenerateFoodLocation()
    {
        Random rnd = new Random();
        int x = rnd.Next(1, (int)MapBorders.MaxRight - 1);
        int y = rnd.Next(1, (int)MapBorders.MaxBottom - 1);

        return new Tuple<int, int>(x, y);
    }

    private void DrawMap()
    {
        Console.Clear();
        for (int i = 0; i <= (int)MapBorders.MaxBottom; i++)
        {
            for (int j = 0; j <= (int)MapBorders.MaxRight; j++)
            {
                if (i == 0 || i == (int)MapBorders.MaxBottom || j == 0 || j == (int)MapBorders.MaxRight)
                    Console.Write("^");
                else if (snake.Contains((j, i)))
                    Console.Write("O");
                else if (food.Item1 == j && food.Item2 == i)
                    Console.Write("@");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    private void MoveSnake(ConsoleKey key)
    {
        var head = snake[0];
        int newX = head.Item1;
        int newY = head.Item2;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                newY--;
                break;
            case ConsoleKey.DownArrow:
                newY++;
                break;
            case ConsoleKey.LeftArrow:
                newX--;
                break;
            case ConsoleKey.RightArrow:
                newX++;
                break;
        }

        snake.Insert(0, (newX, newY));

        if (newX == food.Item1 && newY == food.Item2)
        {
            food = GenerateFoodLocation();
        }
        else
        {
            snake.RemoveAt(snake.Count - 1);
        }

        DrawMap();
    }

    public void StartGame()
    {
        Thread inputThread = new Thread(() =>
        {
            while (!isGameOver)
            {
                var key = Console.ReadKey().Key;
                MoveSnake(key);
            }
        });

        inputThread.Start();

        while (!isGameOver)
        {
            DrawMap();
            Thread.Sleep(100);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        SnakeGame game = new SnakeGame();
        game.StartGame();
    }
}
