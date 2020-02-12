using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    class Game2
    {
        List<Players> playerList;
        Gestures gestures;
        Validation val;
        int roundCount;
        bool runnGame;
        int numberOfRoundsRequired;
        int gamemode;
        int numberOfPlayers;
        public Game2()
        {
            playerList = new List<Players>();
            gestures = new Gestures();
            val = new Validation();
            roundCount = 0;
            runnGame = true;
            numberOfPlayers = 0;
        }

        private void flushValues() 
        {
            this.playerList.Clear();
            this.roundCount = 0;
            runnGame = true;
            gamemode = 100;
            numberOfPlayers = 0;
            roundCount = 0;
            numberOfRoundsRequired = 0;
            Console.Clear();
        }
        public void Start() 
        {

            while (runnGame == true) 
            {
                flushValues();
                DisplayWelcomeMesssage();
                DisplayGameRules();
                DisplayGamemodePrompt();
                DecideWhatGameToLaunch();
                DisplayPlayerlist();
                GameRun();
                DisplayPlayAgain();
            }
            
        }
        public void DisplayGamemodePrompt() 
        {
            Console.WriteLine("What Gamemode Would you Like To PLay In?");
            Console.WriteLine("0. Player vs Player, you vs each other in a battle of witts");
            Console.WriteLine("1. Player vs Computer, you vs the computer in a battle of chance");
            Console.WriteLine("2. Computer vs Computer, you see what the monkeys at devCode are capable of");
            Console.WriteLine("3. Battle Royale");
            int choice = val.uservalidation(0, 3, Console.ReadLine());
            while (val.NegativeNumberValidation(choice)) 
            {
                choice = val.uservalidation(0, 3, Console.ReadLine());
            }
            SetGamemode(choice);
            
        }
        private string DisplayNameCollection(int position) 
        {
            string name;
            Console.WriteLine($"Player {position + 1} please enter your name");
            name = Console.ReadLine();
            return name;
        }
        private void SetGamemode(int gamemode) 
        {
            this.gamemode = gamemode;
        }
        private void DecideWhatGameToLaunch() 
        {
            if (gamemode == 0)
            {
                LaunchPlayervPlayer();
            }
            else if (gamemode == 1)
            {
                LaunchPlayervComputer();
            }
            else if (gamemode == 2) 
            {
                LaunchComputervsComputer();
            }
            else if (gamemode == 3) { Console.WriteLine("Not Ready"); }
        }
        private void LaunchPlayervPlayer() 
        {
            int players = 0;
            Console.WriteLine("How many players will there be?");
            players = val.NumberValidation(Console.ReadLine());
            while (val.NegativeNumberValidation(players)) 
            {
                Console.WriteLine("How many players will there be?");
                players = val.NumberValidation(Console.ReadLine());
            }
            numberOfPlayers = players;
            AddPlayersPvP(players);
        }
        private void LaunchPlayervComputer() 
        {
            int humanPlayers = 0;
            int computerPlayers = 0;
            Console.WriteLine("How Many Human Players will there be?");
            humanPlayers = val.NumberValidation(Console.ReadLine());
            while (val.NegativeNumberValidation(humanPlayers)) 
            {
                Console.WriteLine("How Many Human Players will there be?");
                humanPlayers = val.NumberValidation(Console.ReadLine());
            }
            Console.WriteLine("How many computer players will there be?");
            computerPlayers = val.NumberValidation(Console.ReadLine());
            while (val.NegativeNumberValidation(computerPlayers))
            {
                Console.WriteLine("How Many computer players will there be?");
                computerPlayers = val.NumberValidation(Console.ReadLine());
            }
            AddPlayersPvP(humanPlayers);
            addComputerPlayers(computerPlayers);
            numberOfPlayers = humanPlayers + computerPlayers;
        }
        private void LaunchComputervsComputer() 
        {
            int computerPlayers = 0;
            computerPlayers = val.NumberValidation(Console.ReadLine());
            while (val.NegativeNumberValidation(computerPlayers))
            {
                Console.WriteLine("How Many computer players will there be?");
                computerPlayers = val.NumberValidation(Console.ReadLine());
            }
            addComputerPlayers(computerPlayers);
            numberOfPlayers = computerPlayers;
        }
        private void addComputerPlayers(int numberofAI) 
        {
            int idToGive = -01110111;
            // METHOD THAT ADDS TO THIS ID
            for (int i = 0; i < numberofAI; i++)
            {
                idToGive--;
                playerList.Add(new Computer { name = $"Computer->{idToGive}", score = 0, gesture = new Gestures() });
            }
        }
        private void AddPlayersPvP(int numberofPlayers) 
        {
            for (int i = 0; i < numberofPlayers; i++)
            {
                playerList.Add(new Human { name = DisplayNameCollection(i), score = 0, gesture = new Gestures() });
                Console.WriteLine($"{playerList[i].name} has been added to the game");
            }
        }
        private void DisplayPlayerlist() 
        {
            foreach (Players player in playerList) 
            {
                Console.WriteLine($"{player.name},{player.score}");
            }
        }
        private void DisplayGameRules()
        {
            Console.WriteLine("ROCK CAN CRUSH LIZZARD AND SCISSORS BUT WILL BE VAPORIZED BY SPOCK AND COVERED BY PAPER");
            Console.WriteLine("PAPER CAN COVER ROCK AND DISPROVE SPOCK BUT WILL BE CUT BY SCISSORS AND EATEN BY LIZZARD");
            Console.WriteLine("SCISSORS CAN CUT PAPER AND DECAPITATE LIZZARD BUT WILL BE CRUSHED BY ROCK AND SPOCK");
            Console.WriteLine("LIZZARD CAN POSION SPOCK AND EAT PAPER BUT WILL BE DECAPITATED BY SCISSORS AND CRUSHED BY ROCK");
            Console.WriteLine("SPOCK CAN VAPORIZE ROCK AND CRUSH SCISSORS BUT WILL BE POISONED BY LIZZARD AND DISPROVEN BY PAPER");
            Console.WriteLine(" ");
        }
        private void DisplayWelcomeMesssage() 
        {
            Console.WriteLine("WELCOME TO ROCK PAPER SCISSORS LIZZARD SPOCK!");
            Console.WriteLine(" ");
        }
        private void DisplayPLayerPoints() 
        {
            Console.WriteLine("CURRENT SCORES");
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine($"{playerList[i].name} : {playerList[i].score}");
            }
        }
        private void DisplayWinner(Players winningPlayer)
        {
            Console.WriteLine($"Congrats {winningPlayer.name} you won the game with a score of {winningPlayer.score}!");
        }
        private void DisplayPlayAgain() 
        {
            Console.WriteLine("Play Again?");
            Console.WriteLine("1. YES");
            Console.WriteLine("2. NO");
            int choice = 0;
            choice = val.uservalidation(1, 2, Console.ReadLine());
            while (val.NegativeNumberValidation(choice)) 
            {
                Console.WriteLine("Please use a non negative number!");
                choice = val.uservalidation(1, 2, Console.ReadLine());
            }

            if (choice == 1) { runnGame = true; }
            else if (choice == 2) { runnGame = false; }
        }
        private void GameRun() 
        {
            //check the gamemodes
            if (gamemode < 3)
            {
                int NscoreRequired = 0;
                NscoreRequired = ((numberOfPlayers - 1) * 2); // For Best 2 of 3 style
                bool runThisGame = true;
                while (runThisGame == true)
                {
                    runThisGame = LaunchBest2of3Style(NscoreRequired, runThisGame);
                }
            }// Will run Best 2 of 3 style
            else if (gamemode == 4) { Console.WriteLine("BATTLE ROYALE IS NOT READY"); }//Will run battle royale logic
        }
        private bool LaunchBest2of3Style(int nscoreRequired, bool runthisgame) 
        {
            Console.Clear();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                playerList[i].promptMyGesture();
                Console.Clear();
            }
            
            calculatePoints();
            DisplayPLayerPoints();
            Console.ReadLine();

            for (int i = 0; i<numberOfPlayers; i++) 
            {
                if (playerList[i].score >= nscoreRequired) 
                {
                    DisplayWinner(playerList[i]);
                    runthisgame = false;
                    break;
                }
            } // check if there is a winner.

            return runthisgame;
        }
        private void calculatePoints() 
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                for (int index = 0; index < numberOfPlayers; index++)
                {
                    if (i != index) 
                    {
                        if (playerList[i].gesture == gestures.gestureLogic(playerList[i].gesture, playerList[index].gesture))// CURRENT i WON 
                        {
                            playerList[i].score++;
                        }
                        else if (playerList[index].gesture == gestures.gestureLogic(playerList[index].gesture, playerList[i].gesture))//Current index won 
                        {
                            Console.WriteLine($"{playerList[i].name} lost to {playerList[index].name} with {playerList[i].gesture.gestureName} vs {playerList[index].gesture.gestureName}");
                        }
                        else { Console.WriteLine($"Its a TIE! {playerList[i].name} used {playerList[i].gesture.gestureName} against {playerList[index].name}'s {playerList[index].gesture.gestureName}"); }
                    }
                }
            }
        }
        

    }
}
