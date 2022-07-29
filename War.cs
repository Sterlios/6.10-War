using System;
using System.Collections.Generic;
using System.Text;

namespace War
{
    class War
    {
        private Random _random;
        private List<Army> _armies;

        public War()
        {
            _random = new Random();

            InitializeArmy();
        }

        public void ToFight()
        {
            ShowArmies();

            while (_armies.Count > 1)
            {
                ChooseArmies(out Army attackingArmy, out Army defendingArmy);

                Console.WriteLine("Атакует " + attackingArmy + ", Защищается " + defendingArmy);

                attackingArmy.ToAttack(defendingArmy);

                defendingArmy.UpdateSoldiersList();

                if (defendingArmy.IsExist == false)
                {
                    _armies.Remove(defendingArmy);
                    Console.WriteLine("УНИЧТОЖЕНА АРМИЯ СТРАНЫ " + defendingArmy);
                    Console.ReadKey();
                }

                Console.WriteLine();
            }

            Console.WriteLine("Победила армия страны " + _armies[0].Country);
        }

        private void ShowArmies()
        {
            Console.WriteLine("В войне участвуют страны");

            foreach(Army army in _armies)
            {
                Console.WriteLine(army);
            }

            Console.WriteLine();
        }

        private void ChooseArmies(out Army attackingArmy, out Army defendingArmy)
        {
            bool isCorrect = false;

            attackingArmy = _armies[_random.Next(_armies.Count)];
            defendingArmy = null;

            while (isCorrect == false)
            {
                defendingArmy = _armies[_random.Next(_armies.Count)];

                if (attackingArmy != defendingArmy)
                {
                    isCorrect = true;
                }
            }
        }

        private void InitializeArmy()
        {
            _armies = new List<Army>
            {
                new Army("Россия"),
                new Army("США"),
                new Army("Германия")
            };
        }
    }
}
