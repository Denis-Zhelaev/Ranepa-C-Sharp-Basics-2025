namespace AddLw3.Equipment
{
    public class Weapon
    {
        public string Name { get; private set; }
        public int Damage { get; private set; }
        public int CritChance { get; private set; }

        public Weapon(string name, int damage, int critChance)
        {
            Name = name;
            Damage = damage;
            CritChance = critChance;
        }
    }

    public class Armor
    {
        public string Name { get; private set; }
        public int Defense { get; private set; }
        public int DodgeChance { get; private set; }

        public Armor(string name, int defense, int dodgeChance)
        {
            Name = name;
            Defense = defense;
            DodgeChance = dodgeChance;
        }
    }
}