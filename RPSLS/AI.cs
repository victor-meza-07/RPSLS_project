using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    class AI : Player
    {
        Random random;
        public AI()
        {
            random = new Random();
            assignAIPlayerValues();
        }

        public void assignAIPlayerValues() 
        {
            playerName = "COMPUTER";
            score = 0;
            playerID = 01110111; //w in bianary
        }
        public int generateMyChoice() 
        {
            int choice = 0;
            choice = random.Next(0, listofGestures.Count);
            return choice;
        }
    }
}
