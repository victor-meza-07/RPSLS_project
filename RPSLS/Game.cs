using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    class Game : Player
    {
        List<Player> playerlist;
        Validation val;
        Gestures gestures;
        AI aI;
        public Game()
        {
            val = new Validation();
            playerlist = new List<Player>();
            gestures = new Gestures();
            aI = new AI();

        }


        public void playAgainstComputer()
        {
            Console.WriteLine("Enter a Name");
            string name = Console.ReadLine();
            playerlist.Add(new Player { playerName = name, playerID = 0, score = 0 });
            playerlist.Add(new AI());
        }

        public bool DisplayComputer(bool runthegame)
        {
            int choice = aI.generateMyChoice();
            for (int i = 0; i < playerlist.Count; i++)
            {
                choice = aI.generateMyChoice();
                if (playerlist[i].playerID == 01110111)
                {
                    playerlist[i].setMyGesture(choice);
                }
                else
                {
                    Console.WriteLine($"{playerlist[i].playerName} PLEASE SELECT A GESTURE!");
                    foreach (Gestures gesture in listofGestures)
                    {
                        Console.WriteLine($"{gesture.gestureID}.{gesture.gestureName}");
                    }
                    string userChoice = Console.ReadLine();
                    int pchoice = val.uservalidation(listofGestures.Count, userChoice);
                    playerlist[i].setMyGesture(pchoice);
                    choice = aI.generateMyChoice();
                    playerlist[playerlist.IndexOf(playerlist[i + 1])].setMyGesture(choice);
                }
            }

            Gestures winningGesture = new Gestures();
            for (int i = 0; i < playerlist.Count; i++)
            {
                if (i == playerlist.Count) { Console.WriteLine($"{playerlist[i].playerName} HAS WON WITH {playerlist[i].myGesture.gestureName} vs {playerlist[i - 1].myGesture.gestureName}"); playerlist[i].AddtoPlayerScore(1); break; }
                else if (playerlist[i].myGesture == gestures.gestureLogic(playerlist[i].myGesture, playerlist[i + 1].myGesture)) { Console.WriteLine($"{playerlist[i].playerName} HAS WON WITH {playerlist[i].myGesture.gestureName} vs {playerlist[i + 1].myGesture.gestureName}"); playerlist[i].AddtoPlayerScore(1); break; }
                else if (playerlist[i + 1].myGesture == gestures.gestureLogic(playerlist[i].myGesture, playerlist[i + 1].myGesture)) { Console.WriteLine($"{playerlist[i + 1].playerName} HAS WON WITH {playerlist[i + 1].myGesture.gestureName} vs {playerlist[i].myGesture.gestureName}"); playerlist[i + 1].AddtoPlayerScore(1); break; }
                else { Console.WriteLine($"ISSSAAA TIE {playerlist[i].myGesture.gestureName} vs {playerlist[i + 1].myGesture.gestureName}"); break; }
            }

            for (int i = 0; i < playerlist.Count; i++)
            {
                if (playerlist[i].score == 3)
                {
                    runthegame = false;
                    Console.WriteLine($"{playerlist[i].playerName} HAS WON THE GAME WITH A SCORE OF {playerlist[i].score}");
                }
            }

            return runthegame;

        } //WORKS WITH COMPUTER
        public bool Display(bool rungame)
        {
            Console.Clear();
            Console.WriteLine($"{playerlist[0].playerName}:{playerlist[0].score} vs {playerlist[1].playerName}:{playerlist[1].score}");
            for (int i = 0; i < playerlist.Count; i++)
            {
                Console.WriteLine($"{playerlist[i].playerName} PLEASE SELECT A GESTURE!");
                foreach (Gestures gesture in listofGestures)
                {
                    Console.WriteLine($"{gesture.gestureID}.{gesture.gestureName}");
                }
                string userChoice = Console.ReadLine();
                int pchoice = val.uservalidation(listofGestures.Count, userChoice);
                playerlist[i].setMyGesture(pchoice);
                Console.Clear();
            }

            Console.Clear();
            if (playerlist[0].myGesture == gestures.gestureLogic(playerlist[0].myGesture, playerlist[1].myGesture)) { Console.WriteLine($"{playerlist[0].playerName} WON with {playerlist[0].myGesture.gestureName} vs {playerlist[1].myGesture.gestureName}"); playerlist[0].AddtoPlayerScore(1); }//PLAYERONE WON
            else if (playerlist[1].myGesture == gestures.gestureLogic(playerlist[0].myGesture, playerlist[1].myGesture)) { Console.WriteLine($"{playerlist[1].playerName} WON with {playerlist[1].myGesture.gestureName} vs {playerlist[0].myGesture.gestureName}"); playerlist[1].AddtoPlayerScore(1); }//Player TWO WON
            else { Console.WriteLine($"ISSSAAA TIE  with {playerlist[0].myGesture.gestureName} vs {playerlist[1].myGesture.gestureName}"); }//TIE
            Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < playerlist.Count; i++)
            {
                if (playerlist[i].score == 3)
                {
                    rungame = false;
                    Console.WriteLine($"{playerlist[i].playerName} WON WITH A SCORE OF: {playerlist[i].score}");
                }
            }

            return rungame;
        } // Works with PVP

        public void addPlayers()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Enter Your Name");
                string name = getplayerName();
                playerlist.Add(new Player { playerName = name, playerID = i, score = 0 });
            }
        }

        public void bestTwoOfThreeComp()
        {
            playAgainstComputer();
            bool rungame = true;
            while (rungame == true)
            {
                rungame = DisplayComputer(rungame);
            }
        }
        public void bestTwoOfThreeMP()
        {
            addPlayers();
            bool rungame = true;
            while (rungame == true)
            {
                rungame = Display(rungame);
            }

        }
        public string getplayerName()
        {
            string userchoice = "";
            userchoice = Console.ReadLine();
            return userchoice;
        }

        public void DisplayGameOptions()
        {
            flushvalues();
            Console.WriteLine("Select What Gamemode You'd Like!");
            Console.WriteLine("0. PLAYER VS AI");
            Console.WriteLine("1. PLAYER VS PLAYER");
            int userchoice = val.uservalidation(2, Console.ReadLine());
            Console.Clear();
            if (userchoice == 0) { bestTwoOfThreeComp(); }
            else if (userchoice == 1) { bestTwoOfThreeMP(); }
        }
        public void flushvalues() 
        {
            playerlist.Clear();
        }
        
        
        
        
    }
}
