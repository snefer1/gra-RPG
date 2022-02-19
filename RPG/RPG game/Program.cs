using System;

namespace RPG_game
{
    class Program
    {       
		static void Main(string[] args)
        {
            try
            {
                Random random = new Random();

                Console.WriteLine("Jak masz na imię?");

                //Tworzenie nazwy postaci i zapisanie jej 
                Player player = new Player()
                {
                    Name = Console.ReadLine()
                };

                //Wypisanie imienia gracza 
                Console.WriteLine("Twoje imie to " + player.Name + ".");

                //Po zabiciu 1 przeciwnika
                Enemy firstEnemy = new Enemy("Gigantyczny krab ");
                firstEnemy = null;
               
                GameLoop(firstEnemy, random, player, 5, 20);

                if (!player.IsDead)
                {
                    //stworzenie bossa
                    Boss boss = new Boss();

                    GameLoop(boss, random, player, 50, 10);
                    if (!player.IsDead)
                    {
                        Console.WriteLine("Gratulacje " + player.Name + ", Pokonałeś wszystkich!");
                    }
                    else
                    {
                        GameOver();
                    }
                }
                else
                {
                    GameOver();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
	   
        private static void GameOver()
        {
            Console.Write("PZEGRAłEŚ!");
        }

        private static void GameLoop(Enemy enemy, Random random, Player player, int max_attack_power, int max_player_attack_power)
        {
            //Spotkanie przeciwnika i wybór działania  
            Console.WriteLine(player.Name + " Spotkałeś przeciwnika! " + enemy.Name);
            //Kiedy pierwszy przeciwnik przeżyje powtarzasz pętle
            while (!enemy.IsDead && !player.IsDead)
            {
                //wybierz co chcesz zrobić
                Console.WriteLine(" Co chcesz zrobić?\n1. Pojedynczy atak\n2.Potrójny atak\n3.Obrona\n4.Leczenie ");
                //Zapisanie czego chce użyć gracz
                string playersAction = Console.ReadLine();

                switch (playersAction)
                {
                    case "1":
                        Console.WriteLine("Wybierasz pojedynczy atak" + enemy.Name);
                        enemy.GetsHit(random.Next(1, max_player_attack_power));
                        break;
                    case "2":
                        Console.WriteLine("Wybierasz potrójny atak" + enemy.Name);

                        for (int i = 0; i < 3; i++)
                        {
                            enemy.GetsHit(random.Next(1, max_player_attack_power));
                            
                            if (!enemy.IsDead) 
                            {
                                break;
                            }
                        }

                        break;
                    case "3":
                        Console.WriteLine("Wybierasz obrone");
                        player.IsGurading = true;

                        break;
                    case "4":
                        Console.WriteLine("Wybierasz leczenie ");
                        player.Heal(random.Next(1, 15));
                        break;

                    default:
                        //gracz wybrał złą opcje
                        Console.WriteLine("wybrałeś co innego");
                        break;
                }
                if (!enemy.IsDead)
                {
                    //przeciwnik atakuje gracza
                    player.GetsHit(random.Next(1, 5));

                }
            }
        }
    }
}

