using System;
using System.Collections.Generic;

class Piano
{
  
    private static int[] firstOctave = new int[] { 200, 300, 400 };
    private static int[] secondOctave = new int[] { 500, 600, 700 };
    private static int[] thirdOctave = new int[] { 800, 900, 1000 };

    private static int currentOctave = 1; 

    static void Main()
    {
        Console.WriteLine("Добро пожаловать в пианинку");
        Console.WriteLine("Для переключения октав используй клавиши F1, F2, F3 ");

        while (true)
        {
            
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                   
                    case ConsoleKey.F1:
                        ChangeOctave(1);
                        break;
                    
                    case ConsoleKey.F2:
                        ChangeOctave(2);
                        break;
                    
                    case ConsoleKey.F3:
                        ChangeOctave(3);
                        break;
                    
                    case ConsoleKey.A:
                        PlaySound(0);
                        break;
                    case ConsoleKey.S:
                        PlaySound(1);
                        break;
                    case ConsoleKey.D:
                        PlaySound(2);
                        break;
                    case ConsoleKey.F:
                        PlaySound(3);
                        break;
                    case ConsoleKey.G:
                        PlaySound(4);
                        break;
                    case ConsoleKey.H:
                        PlaySound(5);
                        break;
                    
                    case ConsoleKey.Escape:
                        return; 
                }
            }
        }
    }

    
    static void ChangeOctave(int octave)
    {
        
        if (octave >= 1 && octave <= 3)
        {
            Console.WriteLine($"Ты изменил октавку на {octave}!");
            currentOctave = octave;
        }
        else
        {
            Console.WriteLine("Такой октавы нет");
        }
    }

    static void PlaySound(int noteIndex)
    {
        
        int[] currentOctaveSounds;
        switch (currentOctave)
        {
            case 1:
                currentOctaveSounds = firstOctave;
                break;
            case 2:
                currentOctaveSounds = secondOctave;
                break;
            case 3:
                currentOctaveSounds = thirdOctave;
                break;
            default:
                Console.WriteLine("Такой октавы нет");
                return;
        }

        if (noteIndex >= 0 && noteIndex < currentOctaveSounds.Length)
        {
            int frequency = currentOctaveSounds[noteIndex];
            Console.WriteLine($"Воспроизведен звук ноты {noteIndex + 1} с частотой {frequency} Гц");

        }
        else
        {
            Console.WriteLine("Такой ноты нет");
        }
    }
}
