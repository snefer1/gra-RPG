using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    
    public class Player
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public bool IsDead { get; set; }
        public bool IsGurading { get; set; }


        public Player()
        {
            Health = 100;
        }
        public void GetsHit(int hit_value)
        {
            //sprawdzenie czy gracz używa obrony
            if (IsGurading)
            {
                Console.WriteLine(Name + " pomyślnie zablokowałeś cios! ");

                //przestanie obrony
                IsGurading = false;
            }
            //odjęcie hit_value z HP
            Health = Health - hit_value;

            Console.WriteLine(Name + " zaatakowałeś za " + hit_value + " zostało mu " + Health + "HP");

            if (Health <= 0)
            {
                //gracz umarł (Wywołanie funckji)
                Die();
            }
        }
        //leczenie Healtha
        public void Heal(int amout_to_heal)
        {
            Health = (Health + amout_to_heal > 100) ? 100 : (Health + amout_to_heal);
            Console.WriteLine(Name + " has healed " + amout_to_heal + " heath. You now have " + Health + " health reameing. ");

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

