using System;
using System.Collections.Generic;
using System.Threading;

namespace AddLw2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1: Генерация награды после боя");
            TaskOne();

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
            
            Console.WriteLine("\nЗадача 2: Прокачка персонажа");
            TaskTwo();

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);

            Console.WriteLine("\nЗадача 3: Инвентарь с ограничением по весу");
            TaskThree();
        }

        //ЗАДАЧА 1
        // Описание:После победы игрок получает случайный набор предметов.Симулируем 5 побед игрока и 5 получений награды.
        // Реализуйте методы:
        // GenerateLoot(params string[] possibleLoot) – случайно выбирает предметы.
        // ShowLoot(List<string> loot) – выводит список полученных предметов.
        static void TaskOne()
        {
            string[] possibleItems = { "Золото", "Зелье здоровья", "Меч", "Щит", "Ключ", "Свиток", "Кольцо" };

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Победа номер: " + i);
                Console.WriteLine("Введена задержка для разных наград, ожидайте....");
                Thread.Sleep(200); //задержка для разных наград
                List<string> loot = GenerateLoot(possibleItems);

                ShowLoot(loot);
            }
        }

        static List<string> GenerateLoot(params string[] possibleLoot)
        {
            Random random = new Random();

            int lootCount = random.Next(1, 4);

            List<string> obtainedLoot = new List<string>();

            for (int i = 0; i < lootCount; i++)
            {
                int randomIndex = random.Next(possibleLoot.Length);
                obtainedLoot.Add(possibleLoot[randomIndex]);
            }

            return obtainedLoot;
        }
        static void ShowLoot(List<string> loot)
        {
            Console.WriteLine("Полученные предметы:");
            foreach (string item in loot)
            {
                Console.WriteLine(" - " + item);
            }
        }


        //ЗАДАЧА 2
        // Описание:Игрок может повышать характеристики. Реализуйте:
        // LevelUp(ref int health, ref int attack) – увеличивает здоровье и атаку.
        // Перегруженный LevelUp(ref int health, ref int attack, int bonus) – увеличивает характеристики с бонусом.
        static void TaskTwo()
        {
            int health = 100;
            int attack = 10;

            Console.WriteLine("Начальные характеристики: Здоровье = " + health + ", Атака = " + attack);

            LevelUp(ref health, ref attack);
            Console.WriteLine("После первого уровня: Здоровье = " + health + ", Атака = " + attack);

            LevelUp(ref health, ref attack, 5);
            Console.WriteLine("После вторго уровня, + бонус: Здоровье = " + health + ", Атака = " + attack);

            LevelUp(ref health, ref attack, 10);
            Console.WriteLine("После третьего уровня, + бонус: Здоровье = " + health + ", Атака = " + attack);
        }
        static void LevelUp(ref int health, ref int attack)
        {
            health = (int)(health * 1.2);
            attack = (int)(attack * 1.15);
        }
        static void LevelUp(ref int health, ref int attack, int bonus)
        {
            health = (int)(health * 1.2) + bonus;
            attack = (int)(attack * 1.15) + bonus;
        }

        //ЗАДАЧА 3
        // Описание:У игрока есть инвентарь, в котором можно хранить предметы.
        // Каждый предмет имеет вес.Общий вес не должен превышать лимит.
        // Нужно реализовать методы:
        // попытка добавить предмет в инвентарь
        // Вывод всех предметов в консоль

        //работу с инвентарём вынес в отдельный класс
        static void TaskThree()
        {
            Inventory playerInventory = new Inventory(50);
            Console.WriteLine("Попытка добавить предметы в инвентарь:");
            var itemsToAdd = new (string name, int weight)[]
            {
                ("Меч", 15),
                ("Щит", 20),
                ("Зелье", 2),
                ("Лук", 10),
                ("Кольчуга", 25),
                ("Книга", 5)
            };

            foreach (var item in itemsToAdd)
            {
                bool success = playerInventory.TryAddItem(item.name, item.weight);

                if (success)
                {
                    Console.WriteLine(item.name + " вместилось");

                }
                else
                {
                    Console.WriteLine(item.name + " не вместилось");
                }
            }

            Console.WriteLine("\nСодержимое инвентаря:");
            playerInventory.ShowItems();
        }
    }
    //доп класс для работы с инвентарём
    public class Inventory
    {
        private int _maxWeight;
        private int _currentWeight;
        private Dictionary<string, int> _items;

        public Inventory(int maxWeight)
        {
            _maxWeight = maxWeight;
            _currentWeight = 0;
            _items = new Dictionary<string, int>();
        }

        //попытка поместить вещь в инвентарь
        public bool TryAddItem(string itemName, int weight)
        {
            if (_currentWeight + weight <= _maxWeight)
            {
                _items[itemName] = weight;

                _currentWeight += weight;

                return true; 
            }

            return false; 
        }

        //вывод в консоль вещей
        public void ShowItems()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("Инвентарь пуст!");
                return;
            }

            Console.WriteLine("Текущий вес: " + _currentWeight + " / " + _maxWeight);
            Console.WriteLine("Предметы в инвентаре:");

            foreach (var item in _items)
            {
                Console.WriteLine("- " + item.Key + ", вес: " + item.Value);
            }
        }
    }
}