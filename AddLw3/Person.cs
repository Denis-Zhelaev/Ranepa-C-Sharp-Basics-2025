using AddLw3.Equipment;

namespace AddLw3.Character
{
    public abstract class Person
    {
        public string Name { get; protected set; }
        public int MaxHP { get; protected set; }
        public int MinHP { get; protected set; }
        public int CurrentHP { get; protected set; }
        public Armor Armor { get; protected set; }
        public Weapon Weapon { get; protected set; }

        protected double HpBonus { get; set; }
        protected double DamageBonus { get; set; }
        protected double DefenseBonus { get; set; }

        protected Person(string name, int maxHP, int minHP, Armor armor, Weapon weapon)
        {
            Name = name;
            MaxHP = maxHP;
            MinHP = minHP;
            CurrentHP = maxHP;
            Armor = armor;
            Weapon = weapon;

            HpBonus = 1.0;
            DamageBonus = 1.0;
            DefenseBonus = 1.0;
        }

        public virtual void TakeDamage(int damage)
        {
            CurrentHP -= damage;
            if (CurrentHP < MinHP) CurrentHP = MinHP;
        }

        public virtual void RestoreHealth()
        {
            CurrentHP = MaxHP;
        }

        public virtual int CalculateDamage()
        {
            int baseDamage = Weapon != null ? Weapon.Damage : 1;
            return (int)(baseDamage * DamageBonus);
        }

        public virtual int CalculateDefense()
        {
            int baseDefense = Armor != null ? Armor.Defense : 10;
            return (int)(baseDefense * DefenseBonus);
        }

        public bool IsAlive()
        {
            return CurrentHP > MinHP;
        }

        public override string ToString()
        {
            return Name + ": HP " + CurrentHP + "/" + MaxHP +
                   ", Броня: " + Armor.Name + " (" + Armor.Defense + " защита, " + Armor.DodgeChance + "% уворот)" +
                   ", Оружие: " + Weapon.Name + " (" + Weapon.Damage + " урон, " + Weapon.CritChance + "% крит)";
        }
    }

    public class Player : Person
    {
        public int Specialization { get; private set; }

        public Player(string name, int specialization, Armor armor, Weapon weapon)
            : base(name, 100, 0, armor, weapon)
        {
            Specialization = specialization;
            ApplySpecializationBonus();
        }

        private void ApplySpecializationBonus()
        {
            switch (Specialization)
            {
                case 0: // Воин
                    HpBonus = 2;
                    break;
                case 1: // Маг
                    DefenseBonus = 2;
                    break;
                case 2: // Вор
                    DamageBonus = 2;
                    break;
            }

            MaxHP = (int)(MaxHP * HpBonus);
            CurrentHP = MaxHP;
        }

        public override string ToString()
        {
            string specName;
            switch (Specialization)
            {
                case 0:
                    specName = "Воин";
                    break;
                case 1:
                    specName = "Маг";
                    break;
                case 2:
                    specName = "Вор";
                    break;
                default:
                    specName = "Неизвестно";
                    break;
            }

            return base.ToString() + ", Специализация: " + specName;
        }
    }

    public class Enemy : Person
    {
        public int Level { get; private set; }

        public Enemy(string name, int level, Armor armor, Weapon weapon)
            : base(name, 100, 0, armor, weapon)
        {
            Level = level;
            ApplyLevelBonus();
        }

        private void ApplyLevelBonus()
        {
            double multiplier = 1 + (Level * 0.005);
            HpBonus = multiplier;
            DamageBonus = multiplier;
            DefenseBonus = multiplier;

            MaxHP = (int)(MaxHP * HpBonus);
            CurrentHP = MaxHP;
        }

        public override string ToString()
        {
            return base.ToString() + ", Уровень: " + Level;
        }
    }
}