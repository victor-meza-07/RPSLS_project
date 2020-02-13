using System;

namespace RPSLS
{

   
    class Program
    {
        
        static void Main(string[] args)
        {
            //BOTH VERSIONS WORK, USE game2.Start();


            Game game = new Game();
            System.Threading.Thread.Sleep(200);
            Game2 game2 = new Game2();
            game2.Start();
            
        }

    }
}
