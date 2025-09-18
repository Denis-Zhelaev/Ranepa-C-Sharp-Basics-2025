using System;

namespace AddLw1
{

    //Практическая задача 1 от 17.09.25
    //Симулятор боя с боссом
    //Описание:
    //Создайте пошаговый симулятор боя между игроком и боссом.
    //У игрока есть 100 HP и 3 типа атак:
    //обычная (15-25 урона),
    //сильная(30-40 урона, можно использовать раз в 3 хода),
    //лечение(восстанавливает 20-30 HP, можно использовать 3 раза за бой).
    //Босс имеет 150 HP и атакует случайным уроном от 10 до 30.
    //Бой идет по ходам до победы одной из сторон.


    //Решение:
    //Создал один класс Character,
    //не стал усложнять архитектуру,
    //Босс реализует только один метод
    class Character
    {
        public Character(int hp, int healsLeft)
        {
            HP = hp;
            IsAlive = true;
            HealsLeft = healsLeft;
            HeavyAttackCooldown = 0;
        }

        public bool IsAlive { get; set; }
          
        public int HealsLeft { get; set; }
        
        public int HeavyAttackCooldown { get; set; } 

        public int HP { get; set; }
        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                HP = 0;
                IsAlive = false;
            }
        }

        public void Heal(int amount)
        {
            HP += amount;
            HealsLeft--;
        }
    }

    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            Character player = new Character(100, 3);
            Character boss = new Character(150, 0);

            Console.WriteLine("Описание: Создайте пошаговый симулятор боя между игроком и боссом." +
                "\nУ игрока есть 100 HP и 3 типа атак: \n  " +
                "\nобычная (15-25 урона),\n " +
                "\nсильная (30-40 урона, можно использовать раз в 3 хода), " +
                "\nлечение (восстанавливает 20-30 HP, можно использовать 3 раза за бой). " +
                "\nБосс имеет 150 HP и атакует случайным уроном от 10 до 30." +
                "\nБой идет по ходам до победы одной из сторон.");

            while (player.IsAlive && boss.IsAlive)
            {
                Console.WriteLine("ваш хп " + player.HP + " Хп Босса " + boss.HP + "\n");
                Console.WriteLine(" 1 обычная (15-25 урона)" +
                    "\n 2 сильная (30-40 урона, можно использовать раз в 3 хода)," +
                    "\n 3 лечение (восстанавливает 20-30 HP, можно использовать 3 раза за бой). ");
                
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Неверный ввод. Выберите 1, 2 или 3:");
                }

                switch (choice)
                {
                    case 1: 
                        boss.TakeDamage(random.Next(15, 26));
                        break;

                    case 2:
                        if (player.HeavyAttackCooldown == 0)
                        {
                            boss.TakeDamage(random.Next(30, 41));
                            player.HeavyAttackCooldown = 3;
                        }
                        else
                        {
                            Console.WriteLine("111");
                            boss.TakeDamage(random.Next(15, 26));
                        }
                        break;

                    case 3: 
                        if (player.HealsLeft > 0)
                        {
                            player.Heal(random.Next(20, 31));
                        }
                        else
                        {
                            boss.TakeDamage(random.Next(15, 26));
                        }
                        break;
                }

                if (!boss.IsAlive)
                {
                    Console.WriteLine("\nПобеда");
                    break;
                }

                if (player.HeavyAttackCooldown > 0)
                    player.HeavyAttackCooldown--;

                player.TakeDamage(random.Next(10, 31));

                if (player.IsAlive == false)
                {
                    Console.WriteLine("\nПроигрыш");
                    break;
                }
            }
        }
    }
}