using System;

namespace lw3_1
{
    internal class Program
    {
        const int minValue = 0; const int maxValue = 100; //для рандома

        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1: Сумма элементов массива");
            taskOne();

            Console.WriteLine("\n Задача 2: Поиск максимального и минимального значения");
            taskTwo();

            Console.WriteLine("\n Задача 3: Реверс массива");
            taskThree();

            Console.WriteLine("\n Задача 4: Объединение массивов");
            taskFour();

            Console.WriteLine("\n Задача 5: Фильтрация элементов");
            taskFive();
        }

        // доп метод для создания рандомного массива
        static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minValue, maxValue);
            }
            return array;
        }

        //Напишите программу,
        //которая создает массив из 10 целых чисел и выводит на экран их сумму.
        static void taskOne()
        {
            int[] array = GenerateRandomArray(10);
            Console.WriteLine("Рандомный массив: " + string.Join(", ", array));

            int sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }

            Console.WriteLine("Сумма: " + sum);
        }

        //Создайте массив из 20 чисел и реализуйте метод,
        //который находит и возвращает максимальное и
        //минимальное значение в массиве.
        static void taskTwo()
        {
            int[] array = GenerateRandomArray(20);
            Console.WriteLine("Рандомный массив: " + string.Join(", ", array));

            // Сортировка и получение min/max
            Array.Sort(array);
            int min = array[0];
            int max = array[array.Length - 1];

            Console.WriteLine("Минимум: " + min);
            Console.WriteLine("Максимум: " + max);
        }

        //Напишите программу,
        //которая создает массив из 10 целых чисел
        //и выводит его в обратном порядке.
        static void taskThree()
        {
            int[] array = GenerateRandomArray(10);
            Console.WriteLine("Рандомный массив: " + string.Join(", ", array));
            Array.Reverse(array);
            Console.WriteLine("Обратный массив: " + string.Join(", ", array));
        }

        //Создайте из двух массивов из 5 целых чисел, один массив из 10 чисел.
        static void taskFour()
        {
            int[] array1 = GenerateRandomArray(5);
            int[] array2 = GenerateRandomArray(5);

            Console.WriteLine("Рандомный массив 1: " + string.Join(", ", array1));
            Console.WriteLine("Рандомный массив 2: " + string.Join(", ", array2));

            // Объединение массивов
            int[] combinedArray = new int[array1.Length + array2.Length];
            array1.CopyTo(combinedArray, 0);
            array2.CopyTo(combinedArray, array1.Length);

            Console.WriteLine("Объединенный массив: " + string.Join(", ", combinedArray));
        }

        //Напишите программу,
        //которая создает массив целых чисел и отдельно выводит только четные
        //числа в новом массиве.
        static void taskFive()
        {
            int[] array = GenerateRandomArray(15);
            Console.WriteLine("Рандомный массив: " + string.Join(", ", array));

            //под задачу лучше подходит вектор,
            //могли бы все четные сразу в него пихать,
            //а не городить вот это
            int evenCount = 0;
            foreach (int num in array)
            {
                if (num % 2 == 0) evenCount++;
            }

            int[] evenArray = new int[evenCount];
            int index = 0;
            foreach (int num in array)
            {
                if (num % 2 == 0)
                {
                    evenArray[index] = num;
                    index++;
                }
            }

            Console.WriteLine("Массив с чётными: " + string.Join(", ", evenArray));
        }
    }
}