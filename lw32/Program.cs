using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lw4_1
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Задача 1: Список студентов");
            taskOne();

            Console.WriteLine("\nЗадача 2: Словарь переводов");
            taskTwo();

            Console.WriteLine("\nЗадача 3: Стек и обратный порядок");
            taskThree();

            Console.WriteLine("\nЗадача 4: Очередь для обслуживания клиентов");
            taskFour();

            Console.WriteLine("\nЗадача 5: Набор уникальных чисел");
            taskFive();

            Console.WriteLine("\nЗадача 6: Ведение счетов");
            taskSix();

            Console.WriteLine("\nЗадача 7: Поиск дубликатов в списке");
            taskSeven();

            Console.WriteLine("\nЗадача 8: Словарь частоты слов");
            taskEight();

            Console.WriteLine("\nЗадача 9: Объединение списков с уникальными значениями");
            taskNine();

            Console.WriteLine("\nЗадача 10: Найти максимальное и минимальное значение");
            taskTen();

            Console.WriteLine("\nЗадача 11: Подсчет чисел, превышающих заданное значение");
            taskEleven();
        }

        //Доп метод для рандомного списка из чисел
        static List<int> generateRandomList(int sizeOfList)
        {
            Random random = new Random();
            List<int> list = new List<int>(sizeOfList);
            for (int i = 0; i < sizeOfList; i++)
            {
                list.Add(random.Next(0, 10));
            }
            return list;
        }

        //Напишите программу, которая создаёт список студентов и позволяет добавлять,
        //удалять и выводить их имена.
        static void taskOne()
        {
            List<string> students = new List<string>();

            while (true)
            {
                Console.WriteLine("\n1. Добавить студента" +
                    "\n2. Удалить студента" +
                    "\n3. Вывести всех студентов" +
                    "\n4. Выход" +
                    "\nВыберите действие: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Некорректный ввод. Введите число от 1 до 4.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите имя студента: ");
                        students.Add(Console.ReadLine());
                        Console.WriteLine("Студент добавлен.");
                        break;
                    case 2:
                        Console.Write("Введите имя студента для удаления: ");
                        if (students.Remove(Console.ReadLine()))
                            Console.WriteLine("Студент удален.");
                        else
                            Console.WriteLine("Студент не найден.");
                        break;
                    case 3:
                        Console.WriteLine("Список студентов:");
                        students.ForEach(Console.WriteLine);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте заново");
                        break;
                }
            }
        }

        //Создайте программу, которая использует словарь для хранения английских слов
        //и их переводов на русский.Позвольте пользователю запрашивать перевод слова.
        static void taskTwo()
        {
            Dictionary<string, string> translations = new Dictionary<string, string>
            {
                {"hello", "привет"},
                {"world", "мир"},
                {"student", "студент"},
                {"algorithm", "алгоритм"}
            };

            while (true)
            {
                Console.WriteLine("\n1. Добавить перевод" +
                    "\n2. Найти перевод" +
                    "\n3. Выход" +
                    "\nВыберите действие: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Некорректный ввод. Введите число от 1 до 3.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите английское слово: ");
                        string english = Console.ReadLine();
                        Console.Write("Введите русское слово: ");
                        translations[english.ToLower()] = Console.ReadLine();
                        Console.WriteLine("Перевод добавлен.");
                        break;
                    case 2:
                        Console.Write("Введите английское слово: ");
                        if (translations.TryGetValue(Console.ReadLine().ToLower(), out string translation))
                        {
                            Console.WriteLine("Перевод: " + translation);
                        }
                        else
                        {
                            Console.WriteLine("Перевод не найден.");
                        }
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте заново");
                        break;
                }
            }
        }

        //Напишите программу, которая использует стек для ввода строк
        //и печатает их в обратном порядке.
        static void taskThree()
        {
            Stack<string> stack = new Stack<string>();
            Console.WriteLine("Введите строки (для выхода введите exit):");

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "exit") break;
                stack.Push(input);
            }

            Console.WriteLine("Строки в обратном порядке:");
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }

        //Создайте программу, которая использует очередь для регистрации клиентов в магазине.
        //Каждый шаг цикла клиент удаляется из очереди.
        //Необходимо вывести обновленную очередь в консоль.
        static void taskFour()
        {
            Queue<string> clients = new Queue<string>();
            clients.Enqueue("1 клиент");
            clients.Enqueue("2 клиент");
            clients.Enqueue("3 клиент");

            Console.WriteLine("Начальная очередь клиентов:");
            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }

            while (clients.Count > 0)
            {
                Console.ReadKey(true);
                Console.WriteLine("\nОбслужен клиент: " + clients.Dequeue());

                Console.WriteLine("Текущая очередь:");
                if (clients.Count > 0)
                {
                    foreach (var client in clients)
                    {
                        Console.WriteLine(client);
                    }
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                }
                else
                {
                    Console.WriteLine("Очередь пуста!");
                }
            }

            Console.WriteLine("Все клиенты обслужены!");
        }

        //Напишите программу, которая использует набор (хэш сет)
        //для хранения уникальных чисел,
        //введенных пользователем.
        //Цикл на 10 вводов пользователя.
        //Выводите все уникальные числа после завершения ввода.
        static void taskFive()
        {
            HashSet<int> uniqueNumbers = new HashSet<int>();
            Console.WriteLine("Введите 10 чисел:");

            for (int i = 0; i < 10; i++)
            {
                Console.Write("Введите число " + i + ": ");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    uniqueNumbers.Add(number);
                }    
                else
                {
                    Console.WriteLine("Некорректный ввод, попробуйте ещё раз");
                    i--;
                }
            }

            Console.WriteLine("Уникальные числа: ");
            foreach (var num in uniqueNumbers)
            {
                Console.WriteLine(num);
            }    
        }


        //Создайте программу, используя словарь,
        //для ведения учета счетов(например, расходов).
        //Каждой категории расходов присваивается сумма.
        //Позвольте пользователю добавлять, удалять и
        //отображать расходы по категориям.
        static void taskSix()
        {
            Dictionary<string, decimal> expenses = new Dictionary<string, decimal>();

            while (true)
            {
                Console.WriteLine("\n1. Добавить расход" +
                    "\n2. Удалить категорию" +
                    "\n3. Показать все расходы" +
                    "\n4. Выход" +
                    "\nВыберите действие: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Некорректный ввод. Введите число от 1 до 4.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите категорию: ");
                        string category = Console.ReadLine();
                        Console.Write("Введите сумму: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                        {
                            if (expenses.ContainsKey(category))
                            {
                                expenses[category] += amount;
                            }
                            else
                            {
                                expenses[category] = amount;
                            }
                            Console.WriteLine("Расход добавлен.");
                        }
                        else
                        {
                            Console.WriteLine("Неверная сумма.");
                        }
                        break;
                    case 2:
                        Console.Write("Введите категорию для удаления: ");
                        if (expenses.Remove(Console.ReadLine()))
                        {
                            Console.WriteLine("Категория удалена.");
                        }
                        else
                        {
                            Console.WriteLine("Категория не найдена.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Расходы по категориям:");
                        foreach (var expense in expenses)
                        {
                            Console.WriteLine(expense.Key + ": " + expense.Value.ToString("C"));
                        }
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте заново");
                        break;
                }
            }
        }

        //Напишите программу,
        //которая создает список чисел и определяет,
        //есть ли в нем дубликаты.
        //Используйте HashSet для хранения уникальных чисел.
        static void taskSeven()
        {
            List<int> numbers = generateRandomList(10);
            Console.WriteLine("Список чисел: " + string.Join(", ", numbers));

            HashSet<int> uniqueSet = new HashSet<int>();
            HashSet<int> duplicates = new HashSet<int>();

            foreach (var num in numbers)
            {
                if (!uniqueSet.Add(num))
                {
                    duplicates.Add(num);
                }
            }

            if (duplicates.Count > 0)
            {
                Console.WriteLine("Найдены дубликаты: " + string.Join(", ", duplicates));
            }
            else
            {
                Console.WriteLine("Дубликатов не найдено.");
            }
        }

        //Напишите программу,
        //которая принимает текст и подсчитывает частоту каждого слова,
        //используя словарь.
        static void taskEight()
        {
            Console.WriteLine("Введите текст:");
            string[] words = Console.ReadLine().Split(new[] { ' ', '.', ',', '!', '?', ';', ':', '-' },
                                      StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string cleanedWord = word.ToLower();
                if (wordFrequency.ContainsKey(cleanedWord))
                {
                    wordFrequency[cleanedWord]++;
                }
                else
                {
                    wordFrequency[cleanedWord] = 1;
                }
            }

            Console.WriteLine("Частота слов:");
            foreach (var pair in wordFrequency)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }
        }

        //Создайте два списка целых чисел и объедините их,
        //сохранив только уникальные значения.
        static void taskNine()
        {
            //добавил ассинхронщину чтобы списки разными получались,
            //иначе одинаковые,
            //если у вас всё ещё одинаковые  - увеличьте задержку
            Console.WriteLine("Генерируем списки, небольшая задержка для генерации отличных списков...");
            List<int> list1 = generateRandomList(10);
            System.Threading.Thread.Sleep(5); 
            List<int> list2 = generateRandomList(10);

            Console.WriteLine("Первый список: " + string.Join(", ", list1));
            Console.WriteLine("Второй список: " + string.Join(", ", list2));

            HashSet<int> uniqueNumbers = new HashSet<int>(list1);
            uniqueNumbers.UnionWith(list2);

            Console.WriteLine("Объединенный список с уникальными значениями: " + string.Join(", ", uniqueNumbers));
        }

        //Создайте список целых чисел и
        //найдите максимальное и минимальное значения в этом списке.
        static void taskTen()
        {
            List<int> numbers = generateRandomList(10);
            Console.WriteLine("Список чисел: " + string.Join(", ", numbers));
            Console.WriteLine("Минимальное значение: " + numbers.Min());
            Console.WriteLine("Максимальное значение: " + numbers.Max());
        }

        //Напишите программу,
        //которая создает список целых чисел и считает,
        //сколько чисел в этом списке превышают заданное значение,
        //введенное пользователем.
        static void taskEleven()
        {
            List<int> numbers = generateRandomList(10);
            Console.WriteLine("Список чисел: " + string.Join(", ", numbers));

            Console.Write("Введите значение: ");
            if (int.TryParse(Console.ReadLine(), out int threshold))
            {
                Console.WriteLine("Чисел больше " + threshold + " : " + numbers.Count(num => num > threshold));
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Попробуйте заново");
            }
        }
    }
}