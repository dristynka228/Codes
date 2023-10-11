using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Piano
{
    private static int[][] octaves = new int[][]
    {
        new int[] { 262, 294, 330, 349, 392, 440, 494 }, 
        new int[] { 523, 587, 659, 698, 784, 880, 988 }, 
        new int[] { 1047, 1175, 1319, 1397, 1568, 1760, 1976 } 
        
    };

    private int currentOctave = 0;

    private void PlaySound(int frequency)
    {
        Console.Beep(frequency, 300); 
    }

    private int[] GetCurrentOctave()
    {
        return octaves[currentOctave]; 
    }

    private void ChangeOctave(int octave)
    {
        if (octave >= 0 && octave < octaves.Length)
        {
            currentOctave = octave; 
            Console.WriteLine("Октавка изменена на " + (currentOctave + 1));
        }
        else
        {
            Console.WriteLine("Такой октавки тут нет, давай другую");
        }
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Текущая октавка: " + (currentOctave + 1));

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key >= ConsoleKey.F1 && key <= ConsoleKey.F12)
            {
                int octave = key - ConsoleKey.F1; 
                ChangeOctave(octave);
            }

            else if (key == ConsoleKey.A || key == ConsoleKey.W || key == ConsoleKey.S ||
                key == ConsoleKey.E || key == ConsoleKey.D || key == ConsoleKey.F || key == ConsoleKey.T ||
                key == ConsoleKey.G || key == ConsoleKey.Y || key == ConsoleKey.H || key == ConsoleKey.U ||
                key == ConsoleKey.J || key == ConsoleKey.K)
            {
                int[] currentOctave = GetCurrentOctave();

                int noteIndex = 0;

                switch (key)
                {
                    case ConsoleKey.A:
                        noteIndex = 0;
                        break;
                    case ConsoleKey.W:
                        noteIndex = 1;
                        break;
                    case ConsoleKey.S:
                        noteIndex = 2;
                        break;
                    case ConsoleKey.E:
                        noteIndex = 3;
                        break;
                    case ConsoleKey.D:
                        noteIndex = 4;
                        break;
                    case ConsoleKey.F:
                        noteIndex = 5;
                        break;
                    case ConsoleKey.T:
                        noteIndex = 6;
                        break;
                    case ConsoleKey.G:
                        noteIndex = 7;
                        break;
                    case ConsoleKey.Y:
                        noteIndex = 8;
                        break;
                    case ConsoleKey.H:
                        noteIndex = 9;
                        break;
                    case ConsoleKey.U:
                        noteIndex = 10;
                        break;
                    case ConsoleKey.J:
                        noteIndex = 11;
                        break;
                    case ConsoleKey.K:
                        noteIndex = 12;
                        break;
                }

                PlaySound(currentOctave[noteIndex]);
            }
            else if (key == ConsoleKey.Escape)
            {
                break; 
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Piano piano = new Piano();
        piano.Run();
    }
}