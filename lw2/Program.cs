using System;

namespace lw2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Определить чётное или нет");
            taskOne();

            Console.WriteLine("\nЗадача 2: Вывод максимального из трех чисел");
            taskTwo();

            Console.WriteLine("\nЗадача 3: Выбор вариантов через switch");
            taskThree();

            Console.WriteLine("\nЗадача 4: Сумма чисел от 1 до N");
            taskFour();

            Console.WriteLine("\nЗадача 5: найти факториал числа");
            taskFive();

            Console.WriteLine("\nЗадача 6: вывести числа Фибоначчи");
            taskSix();

            Console.WriteLine("\nЗадача 7: Проверка палиндрома");
            taskSeven();

            Console.WriteLine("\nЗадача 8: Поиск максимального числа из 5 представленных");
            taskEight();

            Console.WriteLine("\nЗадача 9: Вывести таблицу умножения");
            taskNine();

            Console.WriteLine("\nЗадача 10: Угадать случайное число");
            taskTen();
        }

        //доп функция для парса строки в число
        static int GetInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                    return result;
                Console.WriteLine("Ошибка ввода, введите заново.");
            }
        }

        //Напишите программу, которая запрашивает у пользователя целое число и выводит, является ли
        //оно четным или нечетным.Используйте условие if.
        static void taskOne()
        {
            Console.WriteLine("Введите целое число:");
            int number = GetInt();
            string result = (number % 2 == 0) ? "четное" : "нечетное";
            Console.WriteLine(result);
        }

        //Напишите программу, которая запрашивает у пользователя три числа и определяет,
        //какое из них максимальное, используя условие if.
        static void taskTwo()
        {
            Console.WriteLine("Введите первое число:");
            double num1 = GetInt();

            Console.WriteLine("Введите второе число:");
            double num2 = GetInt();

            Console.WriteLine("Введите третье число:");
            double num3 = GetInt();

            double max = num1;

            if (num2 > max)
                max = num2;

            if (num3 > max)
                max = num3;

            Console.WriteLine("Максимальное число - " + max);
        }

        //Напишите программу, которая запрашивает у пользователя номер фрукта(от 1 до 5) и выводит его
        //название с помощью оператора switch:
        //1 - Яблоко
        //2 - Банан
        //3 - Апельсин
        //4 - Груша
        //5 - Виноград
        //Если номер вне диапазона, выведите сообщение об ошибке.
        static void taskThree()
        {
            Console.WriteLine("Выберите фрукт (введите номер от 1 до 5):");
            Console.WriteLine("1 - Яблоко");
            Console.WriteLine("2 - Банан");
            Console.WriteLine("3 - Апельсин");
            Console.WriteLine("4 - Груша");
            Console.WriteLine("5 - Виноград");

            int choice = GetInt();

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Яблоко");
                    break;
                case 2:
                    Console.WriteLine("Банан");
                    break;
                case 3:
                    Console.WriteLine("Апельсин");
                    break;
                case 4:
                    Console.WriteLine("Груша");
                    break;
                case 5:
                    Console.WriteLine("Виноград");
                    break;
                default:
                    Console.WriteLine("Ошибка: введите число от 1 до 5");
                    break;
            }
        }

        //Напишите программу, которая запрашивает у пользователя целое число N и вычисляет сумму всех
        //чисел от 1 до N с помощью цикла for.
        static void taskFour()
        {
            Console.WriteLine("Введите целое число N:");
            int n = GetInt();

            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }

            Console.WriteLine("Сумма чисел равна: " + sum);
        }

        //Напишите программу для вычисления факториала числа N(N!) с использованием цикла while.
        //Сделайте так, чтобы программа запрашивала N и продолжала запрашивать, пока пользователь не
        //введет отрицательное число.
        static void taskFive()
        {
            while (true)
            {
                Console.WriteLine("Введите число для факториала: ");
                int n = GetInt();

                if (n < 0)
                {
                    break;
                }

                long factorial = 1;
                int i = 1;
                while (i <= n)
                {
                    factorial *= i;
                    i++;
                }
                Console.WriteLine("Факториал: " + factorial);
                Console.WriteLine("Для прекращения работы введите отрицательное число");
            }
        }

        //Напишите программу, которая выводит первые N чисел Фибоначчи(N - вводится пользователем) с
        //использованием цикла for.
        static void taskSix()
        {
            Console.WriteLine("Введите количество чисел Фибонначи:");
            int n = GetInt();

            if (n <= 0)
            {
                Console.WriteLine("Неверное число");
                return;
            }

            Console.WriteLine("Первые " + n + " чисел: ");

            if (n >= 1) Console.Write("0 ");
            if (n >= 2) Console.Write("1 ");

            long prev1 = 0, prev2 = 1;
            for (int i = 3; i <= n; i++)
            {
                long next = prev1 + prev2;
                Console.Write($"{next} ");
                prev1 = prev2;
                prev2 = next;
            }
            Console.WriteLine();
        }

        //Напишите программу, которая запрашивает у пользователя строку и проверяет, является ли она
        //палиндромом(читается одинаково слева направо и справа налево). Для проверки используйте
        //условие if и цикл foreach.
        static void taskSeven()
        {
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Пустая строка");
                return;
            }

            string cleanedString = input.Replace(" ", "").ToLower();
            string reversedString = "";

            foreach (char c in cleanedString)
            {
                reversedString = c + reversedString;
            }

            if (cleanedString == reversedString)
                Console.WriteLine("Палиндром");
            else
                Console.WriteLine("Не палиндром");
        }

        //Напишите программу, которая принимает 5 чисел от пользователя и находит максимальное,
        //используя цикл while.
        static void taskEight()
        {
            int[] numbers = new int[5];

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Введите число " + (i+1) + " : ");
                numbers[i] = GetInt();
            }

            Array.Sort(numbers);
            int max = numbers[4]; //ну или numbers.Length - 1

            Console.WriteLine("Максимальное число: " + max);
        }

        //Напишите программу, которая выводит таблицу умножения от 1 до 10 для заданного
        //пользователем числа с помощью цикла for.
        static void taskNine()
        {
            Console.WriteLine("Введите число:");
            int number = GetInt();

            if (number <= 0 || number > 10)
            {
                Console.WriteLine("Число должно быть в диапазоне от 1 до 10");
                return;
            }

            Console.WriteLine("\n");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(number + " * " + i + " = " + (number * i));
            }
        }

        //Напишите игру, в которой программа случайным образом выбирает число от 1 до 100, а
        //пользователь пытается его угадать.Программа должна сообщать, выше или ниже загаданное
        //число, используя цикл while. Игра продолжается, пока число не будет угадано.
        static void taskTen()
        {
            Random random = new Random();
            int secretNumber = random.Next(1, 101);
            int guess = 0;

            Console.WriteLine("Число загадано.");

            while (guess != secretNumber)
            {
                Console.Write("Ваша попытка: ");
                guess = GetInt();

                if (guess < secretNumber)
                    Console.WriteLine("Загаданное число больше");
                else if (guess > secretNumber)
                    Console.WriteLine("Загаданное число меньше");
                else
                    Console.WriteLine("Вы угадали!");
            }
        }
    }
}