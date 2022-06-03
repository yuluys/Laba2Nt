using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedichi
{
    public class Game
    {
        Player player1 = new Player();
        Player player2 = new Player();
        Random random = new Random();
        public bool play = true;

        public void GetName()
        {
            Console.WriteLine($"Игрок 1 введите имя:");
            player1.Name = Console.ReadLine();
            Console.WriteLine($"Игрок 2 введите имя:");
            player2.Name = Console.ReadLine();
        }
        /// <summary>
        /// Ход
        /// </summary>
        /// <param name="player"></param>
        public void Turn(Player player)
        {
            int r;
            Console.WriteLine($"Ход игрока \t<<{player.Name}>> Счет: {player.Score}");
            Console.WriteLine($"Раунд {player.Rounds}");
            Console.WriteLine();

            for (int t = 0; t < 3; t++) // Кол-во бросков
            {
                for (int i = 0; i < 5; i++) //1 бросок 5-ти кубиков
                {

                    r = random.Next(1, 7);
                    player.Score += r;
                    
                }
            }
            Console.WriteLine($"Игрок {player.Name} набрал {player.Score} очков");
            Console.ReadKey(true);
            GetTurn();
        }

        /// <summary>
        /// Выбирает кто из игроков будет ходить первым
        /// </summary>
        public void GetFirstTurn()
        {

            int value1 = random.Next(1, 7);
            int value2 = random.Next(1, 7);

            if (value1 > value2)
            {
                Console.WriteLine($"Ходит игрок {player1.Name}");
                Console.WriteLine();
                player1.Turns += 1;
                player1.Rounds += 1;
                Turn(player1);
            }
            else
            {
                Console.WriteLine($"Ходит игрок {player2.Name}");
                Console.WriteLine();
                player2.Turns += 1;
                player2.Rounds += 1;
                Turn(player2);
            }
        }


        /// <summary>
        /// Очередность ходов
        /// </summary>
        /// <param name="player"></param>
        public void GetTurn()
        {

            if (player1.Score >= 1000 || player2.Score >= 1000)
            {
                PlayerWin();
            }
            else
            {
                
                if(player1.Turns <= player2.Turns)
                {
                    player1.Rounds += 1;
                    player1.Turns += 1;
                    Turn(player1);
                }
                if(player1.Turns >= player2.Turns)
                {
                    player2.Rounds += 1;
                    player2.Turns += 1;
                    Turn(player2);
                }
               
            }

        }

        public void PlayerWin()
        {
            if (player1.Score >= 1000)
            {
                player1.Wins += 1;
                player2.Loses += 1;
                Console.WriteLine($"Игрок {player1.Name} победил. Ура! Победа!");
                Console.WriteLine($"Хотите начать новый раунд?\n<Да> - 1 \n<Нет> - 0");
                StartNewRound(int.Parse(Console.ReadLine()));
            }
            else if (player2.Score >= 1000)
            {
                player2.Wins += 1;
                player1.Loses += 1;
                Console.WriteLine($"Игрок {player2.Name} победил. Ура! Победа!");
                Console.WriteLine($"Хотите начать новый раунд?\n<Да> - 1 \n<Нет> - 0");
                StartNewRound(int.Parse(Console.ReadLine()));
            }
            else
                return;
        }

        public void StartNewRound(int a)
        {
            switch (a)
            {
                case 1:
                    {
                        Console.Clear();
                        NewRound();
                        Console.WriteLine("Новая игра началась");
                        GetFirstTurn();
                        break;
                    }
                case 0:
                    {
                        Console.Clear();
                        Console.WriteLine("До новых встреч");
                        Environment.Exit(0);
                        break;
                    }
            }
        }
        public void NewRound()
        {
            player1.Rounds = 0;
            player2.Rounds = 0;
            player1.Cast = 0;
            player2.Cast = 0;
            player1.Score = 0;
            player2.Turns = 0;
            player2.Score = 0;
            player1.Turns = 0;
        }
    }
}


