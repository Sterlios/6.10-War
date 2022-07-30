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
            for (int i = 0; i < _soldiers.Count; i++)
            {
                if (_soldiers[i].IsAlive == false)
                {
                    _soldiers.Remove(_soldiers[i]);
                    i--;
                }
            }
        }

        public override string ToString()
        {
            return Country + " (" + _soldiers.Count + " солдат)";
        }

        private void InitializeSoldiers()
        {
            int minSoldiersCount = 5;
            int maxSoldiersCount = 10;
            int soldiersCount = _random.Next(minSoldiersCount, maxSoldiersCount);

            _soldiers = new List<Soldier>();

            for(int i = 0; i < soldiersCount; i++)
            {
                _soldiers.Add(new Soldier(i+1));
            }
        }
    }
}
