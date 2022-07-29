using System;
using System.Collections.Generic;
using System.Text;

namespace War
{
    class Army
    {
        private List<Soldier> _soldiers;
        private Random _random;

        public string Country { get; }
        public bool IsExist => _soldiers.Count > 0;

        public Army(string country)
        {
            Country = country;
            _random = new Random();

            InitializeSoldiers();
        }

        public void ToAttack(Army defendingArmy)
        {
            Soldier attackingSoldier = _soldiers[_random.Next(_soldiers.Count)];
            Soldier defendingSoldier = defendingArmy.GetDefendingSoldier();

            attackingSoldier.ToAttack(defendingSoldier);
        }

        public Soldier GetDefendingSoldier() => _soldiers[_random.Next(_soldiers.Count)];

        public void UpdateSoldiersList()
        {
            List<Soldier> soldiers = new List<Soldier>();

            foreach(Soldier soldier in _soldiers)
            {
                soldiers.Add(soldier);
            }

            foreach(Soldier soldier in soldiers)
            {
                if (soldier.IsAlive == false)
                {
                    _soldiers.Remove(soldier);
                }
            }
        }

        public override string ToString()
        {
            return Country + " (" + _soldiers.Count + " солдат)";
        }

        private void InitializeSoldiers()
        {
            int minSoldiersCount = 10;
            int maxSoldiersCount = 20;
            int soldiersCount = _random.Next(minSoldiersCount, maxSoldiersCount);

            _soldiers = new List<Soldier>();

            for(int i = 0; i < soldiersCount; i++)
            {
                _soldiers.Add(new Soldier(i+1));
            }
        }
    }
}
