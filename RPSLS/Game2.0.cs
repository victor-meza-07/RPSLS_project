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
        }
        public void Start() 
        {
            flushValues();
            DisplayWelcomeMesssage();
            DisplayGameRules();
            DisplayGamemodePrompt();
            DecideWhatGameToLaunch();
            DisplayPlayerlist();
            GameRun();
        }
        public void DisplayGamemodePrompt() 
        {
            Console.WriteLine("What Gamemode Would you Like To PLay In?");
            Console.WriteLine("0. Player vs Player, you vs each other in a battle of witts");
            Console.WriteLine("1. Player vs Computer, you vs the computer in a battle of chance");
            Console.WriteLine("2. Computer vs Computer, you see what the monkeys at devCode are capable of");
            int choice = val.uservalidation(0, 2, Console.ReadLine());
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
            else if (gamemode == 2) { Console.WriteLine("Not Ready"); }
        }
        private void LaunchPlayervPlayer() 
        {
            Console.WriteLine("How many players will there be?");
            int players = val.NumberValidation(Console.ReadLine());
            numberOfPlayers = players;
            AddPlayersPvP(players);
        }
        private void LaunchPlayervComputer() 
        {
            Console.WriteLine("How Many Human PLayers will there be?");
            int humanPlayers = val.NumberValidation(Console.ReadLine());
            Console.WriteLine("How many computer players will there be?");
            int computerPlayers = val.NumberValidation(Console.ReadLine());
            AddPlayersPvP(humanPlayers);
            addComputerPlayers(computerPlayers);
        }
        private void addComputerPlayers(int numberofAI) 
        {
            int idToGive = -1000000;
            // METHOD THAT ADDS TO THIS ID
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
        private void GameRun() 
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                playerList[i].promptMyGesture();
                Console.Clear();
            }
            calculatePoints();
            DisplayPLayerPoints();
            Console.ReadLine();
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
