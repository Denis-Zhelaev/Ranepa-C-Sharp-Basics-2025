using AddLw3.Equipment;
using AddLw3.Character;
using System;

namespace AddLw3.Factories
{
    public static class EnemyFactory
    {
        private static Random _random = new Random();
        private static int _enemyCount = 0;

        public static Enemy CreateEnemy()
        {
            _enemyCount++;

            int level;
            if (_enemyCount <= 2)
            {
                level = _random.Next(1, 6);
            }
            else if (_enemyCount <= 4)
            {
                level = _random.Next(5, 11);
            }
            else
            {
                level = _random.Next(10, 16);
            }

            string name = Constants.EnemyNames[_random.Next(Constants.EnemyNames.Length)];
            Weapon weapon = Constants.Weapons[_random.Next(Constants.Weapons.Length)];
            Armor armor = Constants.Armors[_random.Next(Constants.Armors.Length)];

            return new Enemy(name, level, armor, weapon);
        }

        public static void Reset()
        {
            _enemyCount = 0;
        }
    }
}