using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    //klasa reprezentuje elementy przeciwnika 
    public class Enemy
    {
        //konstruktor
        public int Health { get; set; }
        public string Name { get; set; }

        public bool IsDead { get; set; }

        public Enemy(string name)
        {
            Health = 100;
            Name = name;

        }
        public void GetsHit(int hit_value)
        {
            //odjęcie hit_value z HP
            Health = Health - hit_value;

            Console.WriteLine(Name + " zaatakował za " + hit_value + " zostało tobie " + Health + "HP");

            if (Health <= 0)
            {
                //gracz umarł
                Die();
            }
        }
        private void Die()
        {
            //Wypisanie że prezeciwnik umarł
            Console.WriteLine(Name + "Umarł!");

            //
            IsDead = true;
        }
    }
}
