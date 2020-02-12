using System;

namespace RPSLS
{

   
    class Program
    {
        
        static void Main(string[] args)
        {
            //BOTH VERSIONS WORK, USE game2.Start();


            Game game = new Game();
            Game2 game2 = new Game2();


            game2.Start();
            
        }

    }
}
