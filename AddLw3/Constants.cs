using AddLw3.Equipment;

namespace AddLw3
{
    public static class Constants
    {
        public static readonly string[] EnemyNames =
        {
            "Гоблин", "Орк", "Скелет", "Зомби", "Демон",
            "Вампир", "Огр", "Призрак", "Лич", "Дракон"
        };

        public static readonly Weapon[] Weapons =
        {
            new Weapon("Кинжал", 20, 15),
            new Weapon("Алебарда", 40, 5),
            new Weapon("Меч", 30, 15),
            new Weapon("Топор", 35, 8),
            new Weapon("Палка", 1, 99)
        };

        public static readonly Armor[] Armors =
        {
            new Armor("Доспехи", 15, 5),
            new Armor("Кольчуга", 10, 8),
            new Armor("Одежда", 3, 12),
            new Armor("Кожанный доспех", 8, 10),
            new Armor("Трусы", 1, 50)
        };
    }
}