using System;

namespace lw1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Первое задание: переменные");
            taskOne();
            Console.WriteLine("\n Второе задание: константы Пи и число дней в неделе");
            taskTwo();
            Console.WriteLine("\n Третье задание: арифметические операторы");
            taskThree();
            Console.WriteLine("\n Четвертое задание: сравнение");
            taskFour();
            Console.WriteLine("\n Пятое задание: инкримент и декримент");
            taskFive();
            Console.WriteLine("\n Шестое задание: преобразование строки в инт");
            taskSix();
            Console.WriteLine("\n Седьмое задание: округление с Math*");
            taskSeven();
            Console.WriteLine("\n Восьмое задание: работа с константами");
            taskEight();
        }

        //доп функция для парса строки в число
        static double GetDouble()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double result))
                    return result;
                Console.WriteLine("Ошибка ввода, введите заново.");
            }
        }

        // Определите несколько констант в своем коде (например, число Пи, число дней в неделе) и
        // выведите их значения на экран. Объясните, почему вы используете константы.
        static void taskOne()
        {
            int number;
            double numberWithFloatPoint;
            string myString;
            bool TrueOrFalse;

            number = 0;
            numberWithFloatPoint = 0.1;
            myString = "hello world";
            TrueOrFalse = true;

            Console.WriteLine("Создаем переменные, инициируем их и выносим");
            Console.WriteLine("интегер - целое число: " + number);
            Console.WriteLine("дабл - я привык использовать флоат с с++ - число с плавающей точкой, те дробное: " + numberWithFloatPoint);
            Console.WriteLine("строка - вектор символов: " + myString);
            Console.WriteLine("булева переменная - логическая, да или нет: " + TrueOrFalse);
        }

        //Определите несколько констант в своем коде (например, число Пи, число дней в неделе) и
        //выведите их значения на экран.Объясните, почему вы используете константы.
        static void taskTwo()
        {
            const int WEEK_MAX_DAY = 7;
            const double PI = 3.14159;
            Console.WriteLine("Создаем переменные константные и выносим");
            Console.WriteLine("Число дней в неделе: " + WEEK_MAX_DAY);
            Console.WriteLine("число Пи: " + PI);
        }

        //Напишите программу, которая запрашивает у пользователя два числа, выполняет над ними все
        //возможные арифметические операции(сложение, вычитание, умножение, деление) и выводит
        //результаты на экран.
        static void taskThree()
        {
            Console.WriteLine("первое число: ");
            double a = GetDouble();
            Console.WriteLine("второе число: ");
            double b = GetDouble();

            Console.WriteLine("вычитание: " + (a - b));
            Console.WriteLine("сложение: " + (a + b));
            Console.WriteLine("деление: " + (a / b));
            Console.WriteLine("умножение: " + (a * b));

        }

        //Напишите программу, которая принимает на вход два числа и сравнивает их. Используйте
        //операторы сравнения и выведите, какое число больше, меньше или равны ли они.
        static void taskFour()
        {
            Console.WriteLine("первое число: ");
            double a = GetDouble();
            Console.WriteLine("второе число: ");
            double b = GetDouble();

            if (a > b)
                Console.WriteLine(a + " больше");
            else if (a < b)
                Console.WriteLine(b + " больше");
            else
                Console.WriteLine(a + " и " + b + "равны");
        }

        //Напишите программу, которая объявляет переменную типа int и увеличивает ее значение на 1 с
        //помощью оператора инкремента, а затем уменьшает на 1 с помощью оператора декремента.
        //Выведите результат на экран.
        static void taskFive()
        {
            Console.WriteLine("инкремент и декримент от 0: ");
            int i = 0;
            Console.WriteLine("Инкримент " + (++i) + " \n декримент " + (--i));

        }

        //Создайте программу, которая запрашивает у пользователя число в виде строки. Преобразуйте его
        //в тип int и выведите его квадрат на экран.
        static void taskSix()
        {
            Console.WriteLine("введите интовое число, выведет квадрат");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    Console.WriteLine(result * result); // можно как Math.Pow(number, 2)
                    break;
                }
                Console.WriteLine("Ошибка парсинга, введите целое число заново.");
            }
        }

        // Напишите программу, которая запрашивает у пользователя дробное число, округляет его до
        //ближайшего целого и выводит результат.Используйте методы класса Math для округления.
        static void taskSeven()
        {
            Console.WriteLine("Введите число для округления");
            double number = GetDouble();
            int rounded = (int)Math.Round(number);
            Console.WriteLine("Округленное число: " + rounded);
        }

        //Создайте программу, в которой вы используете определенные константы для расчета площади
        //круга и площади квадрата.Запросите необходимую информацию у пользователя и выведите
        //результаты.
        static void taskEight()
        {
            // объявил повторно Пи,
            // но можно было бы вынести в глобальные
            // и не объявлять по нескольку раз
            const double PI = 3.14159;
            const int SQUARE_CONST = 2;

            Console.WriteLine("Расчет площади круга:");
            Console.Write("Введите радиус круга: ");
            double radius = GetDouble();
            Console.WriteLine("Площаль круга: " + (PI * radius * radius));

            Console.WriteLine("Расчет площади квадрата: ");
            Console.Write("Введите длину стороны квадрата: ");
            double side = GetDouble();
            Console.WriteLine("Площадь квадрата: " + Math.Pow(side, SQUARE_CONST));
        }
    }
}