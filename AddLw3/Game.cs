using AddLw3.Character;
using AddLw3.Equipment;
using AddLw3.Factories;
using System;

namespace AddLw3
{
    public class Game
    {
        private Player _player;
        private Random _random = new Random();
        private int _battleCount = 1;

        public void Start()
        {
            bool playAgain = true;

            while (playAgain)
            {
                CreatePlayer();
                bool gameRunning = true;
                _battleCount = 1;

                while (gameRunning)
                {
                    Console.Clear();
                    Console.WriteLine("Вступить в " + _battleCount + " битву?");
                    Console.WriteLine("Нажмите любую клавишу для начала боя");
                    Console.WriteLine("Для выхода нажмите ESC");

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Escape)
                    {
                        gameRunning = false;
                        playAgain = false;
                        break;
                    }

                    Enemy enemy = EnemyFactory.CreateEnemy();

                    Console.Clear();
                    Console.WriteLine("Ваш персонаж:");
                    Console.WriteLine(_player);
                    Console.WriteLine("\nПротивник:");
                    Console.WriteLine(enemy);
                    Console.WriteLine("\nНажмите любую клавишу для начала боя...");
                    Console.ReadKey();

                    BattleResult result = Battle(enemy);

                    if (result == BattleResult.PlayerWon)
                    {
                        _player.RestoreHealth();
                        _battleCount++;
                    }
                    else if (result == BattleResult.PlayerLost)
                    {
                        gameRunning = false;
                        break;
                    }
                }
            }
        }

        private void CreatePlayer()
        {
            Console.Clear();
            Console.WriteLine("Создание персонажа:");

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name)) name = "Игрок";

            int specialization = ReadSpecialization();
            Armor armor = SelectArmor();
            Weapon weapon = SelectWeapon();

            _player = new Player(name, specialization, armor, weapon);

            Console.Clear();
            Console.WriteLine("Персонаж создан!");
            Console.WriteLine(_player);
        }

        private int ReadSpecialization()
        {
            while (true)
            {
                Console.WriteLine("\nВыберите специализацию:");
                Console.WriteLine("0 - Воин (+25% HP)");
                Console.WriteLine("1 - Маг (+25% защиты)");
                Console.WriteLine("2 - Вор (+25% урона)");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice) && choice >= 0 && choice <= 2)
                    return choice;

                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }

        private Armor SelectArmor()
        {
            while (true)
            {
                Console.WriteLine("\nВыберите броню:");
                for (int i = 0; i < Constants.Armors.Length; i++)
                {
                    var armor = Constants.Armors[i];
                    Console.WriteLine(i + " - " + armor.Name + " (Защита: " + armor.Defense + ", Уворот: " + armor.DodgeChance + "%)");
                }

                string input = Console.ReadLine();
                if (int.TryParse(input, out int index) && index >= 0 && index < Constants.Armors.Length)
                    return Constants.Armors[index];

                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }

        private Weapon SelectWeapon()
        {
            while (true)
            {
                Console.WriteLine("\nВыберите оружие:");
                for (int i = 0; i < Constants.Weapons.Length; i++)
                {
                    var weapon = Constants.Weapons[i];
                    Console.WriteLine(i + " - " + weapon.Name + " (Урон: " + weapon.Damage + ", Крит: " + weapon.CritChance + "%)");
                }

                string input = Console.ReadLine();
                if (int.TryParse(input, out int index) && index >= 0 && index < Constants.Weapons.Length)
                    return Constants.Weapons[index];

                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }

        private BattleResult Battle(Enemy enemy)
        {
            Console.Clear();
            int round = 1;

            while (_player.IsAlive() && enemy.IsAlive())
            {
                Console.WriteLine("Раунд " + round);

                Attack(_player, enemy);
                if (!enemy.IsAlive()) break;

                Attack(enemy, _player);
                if (!_player.IsAlive()) break;

                round++;
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }

            return ShowBattleResult(enemy);
        }

        private void Attack(Person attacker, Person defender)
        {
            if (!defender.IsAlive()) return;

            Console.WriteLine("\n" + attacker.Name + " атакует!");

            int damage = attacker.CalculateDamage();
            int defense = defender.CalculateDefense();

            Console.WriteLine("Атака: " + damage + " урона");
            Console.WriteLine("Защита: " + defense + " защиты");

            bool crit = CheckCritical(attacker.Weapon != null ? attacker.Weapon.CritChance : 0);
            if (crit)
            {
                damage *= 2;
                Console.WriteLine("Критический удар! Урон удвоен.");
                Console.WriteLine("Итоговый урон: " + damage);
            }

            bool dodge = CheckDodge(defender.Armor != null ? defender.Armor.DodgeChance : 0);
            if (dodge)
            {
                Console.WriteLine(defender.Name + " уклонился от атаки!");
                return;
            }

            int damageDealt = damage - defense;
            if (damageDealt < 0) damageDealt = 0;

            Console.WriteLine("Расчет: " + damage + " урона - " + defense + " защиты = " + damageDealt + " урона");
            Console.WriteLine(attacker.Name + " наносит " + defender.Name + " " + damageDealt + " урона");
            defender.TakeDamage(damageDealt);

            Console.WriteLine("У " + defender.Name + " осталось " + defender.CurrentHP + " HP");
        }

        private bool CheckCritical(int critChance)
        {
            return _random.Next(100) < critChance;
        }

        private bool CheckDodge(int dodgeChance)
        {
            return _random.Next(100) < dodgeChance;
        }

        private BattleResult ShowBattleResult(Enemy enemy)
        {
            Console.WriteLine("\nБой окончен!");

            if (_player.IsAlive())
            {
                Console.WriteLine(_player.Name + " победил!");
                Console.ReadKey();
                return BattleResult.PlayerWon;
            }
            else
            {
                Console.WriteLine(enemy.Name + " победил!");
                Console.ReadKey();
                return BattleResult.PlayerLost;
            }
        }
    }

    public enum BattleResult
    {
        PlayerWon,
        PlayerLost
    }
}