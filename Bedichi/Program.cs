using System;

namespace Bedichi
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
           Game game = new Game();
            bool a = game.play;
            Game(a, game);
            
        }
        public static void Game(bool a,Game game)
        {
            game.GetName();
            
                
                game.GetFirstTurn();
            
        }
    }
}
