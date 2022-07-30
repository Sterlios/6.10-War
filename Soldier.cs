using System;
using System.Collections.Generic;
using System.Text;

namespace War
{
    class Soldier
    {
        private Random _random;
        private int _id;
        private int _damageSpreading = 10;

        public float Health { get; private set; }
        public int Damage { get; private set; }
        public int Armor { get; private set; }
        public bool IsAlive => Health > 0;

        public Soldier(int id)
        {
            int minParameterPercent = 20;
            int maxParameterPercent = 80;
            int percetage = 100;

            _id = id;
            _random = new Random();
            Health = 1000;
            Armor = _random.Next(minParameterPercent, maxParameterPercent);
            Damage = percetage - Armor;
        }

        public void TakeDamage(int damage)
        {
            float precenage = 100;
            float calculatedDamage = damage * (float)(precenage - Armor) / (float)precenage;

            Console.WriteLine(this + " получил урон " + calculatedDamage);

            Health -= calculatedDamage;
        }

        public void ToAttack(Soldier soldier)
        {
            int minDamage = Math.Min(Math.Abs(Damage - _damageSpreading), Math.Abs(Damage + _damageSpreading));
            int maxDamage = Math.Max(Math.Abs(Damage - _damageSpreading), Math.Abs(Damage + _damageSpreading));
            int calculatedDamage = _random.Next(minDamage, maxDamage);

            Console.Write(this + " нанес урон " + calculatedDamage + " | ");

            soldier.TakeDamage(calculatedDamage);
        }

        public override string ToString()
        {
            return "Солдат " + _id + " (HP: " + Health + ")";
        }
    }
}
