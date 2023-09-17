using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Калькулятор");

        while (true)
        {
            Console.WriteLine("Выбери операцию:");
            Console.WriteLine("1. Сложение");
            Console.WriteLine("2. Вычитание");
            Console.WriteLine("3. Умножение");
            Console.WriteLine("4. Деление");
            Console.WriteLine("5. Возведение в степень");
            Console.WriteLine("6. Нахождение корня");
            Console.WriteLine("7. Нахождение процента");
            Console.WriteLine("0. Выход");

            string choice = Console.ReadLine();

            if (choice == "0")
            {
                Console.WriteLine("");
                break;
            }

            if (IsOperation(choice))
            {
                double num1, num2;
                double result = 0;
               
                {
                   
                    num1 = GetUserInput();
                    num2 = GetUserInput(); 
                }

                switch (choice)
                {
                    case "1":
                        result = num1 + num2;
                        break;
                    case "2":
                        result = num1 - num2;
                        break;
                    case "3":
                        result = num1 * num2;
                        break;
                    case "4":
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                            Console.WriteLine("Ошибка: Деление на ноль!");
                        break;
                    case "5":
                        result = Math.Pow(num1 , num2);
                        break;
                    case "6":
                        result = Math.Sqrt(num1);
                        break;
                    case "7":
                        result = num1 * 0.01; 
                        break;                        

                }

                Console.WriteLine("Результат: " + result);
            }
            else
            {
                Console.WriteLine("Ввел что-то не то, давай по новой");
            }
        }
    }

    static bool IsOperation(string choice)
    {
        string[] validChoices = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
        return Array.IndexOf(validChoices, choice) >= 0;
    }

    static double GetUserInput()
    {
        double input;
        while (!double.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Сказано, от 0 до 8, ничего другого");
        }
        return input;
    }
}
