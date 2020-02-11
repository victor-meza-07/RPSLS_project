using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public class Gestures
    {
        public string gestureName;
        public int gestureID;
        

        public Gestures()
        {
            gestureName = null;
            gestureID = 0;
        }

        public Gestures gestureLogic(Gestures gOne, Gestures gTwo) 
        {
            Gestures winningGesture = new Gestures();
            if (gOne.gestureID == 0) 
            {
                if (gTwo.gestureID == 0) { winningGesture.gestureName = "TIE"; winningGesture.gestureID = 5; }
                else if (gTwo.gestureID == 1) { winningGesture = gTwo; }
                else if (gTwo.gestureID == 4) { winningGesture = gTwo; }
                else if (gTwo.gestureID == 2) { winningGesture = gOne; }
                else if (gTwo.gestureID == 3) { winningGesture = gOne; }
            }//Rock
            else if (gOne.gestureID == 1) 
            {
                if (gTwo.gestureID == 1) { winningGesture.gestureName = "TIE"; winningGesture.gestureID = 5; }
                else if (gTwo.gestureID == 2) { winningGesture = gTwo; }
                else if (gTwo.gestureID == 3) { winningGesture = gTwo; }
                else if (gTwo.gestureID == 0) { winningGesture = gOne; }
                else if (gTwo.gestureID == 4) { winningGesture = gOne; }
            }//Paper
            else if (gOne.gestureID == 2) 
            {
                if (gTwo.gestureID == 2) { winningGesture.gestureName = "TIE"; winningGesture.gestureID = 5; }
                else if (gTwo.gestureID == 4) { winningGesture = gTwo; }
                else if (gTwo.gestureID == 0) { winningGesture = gTwo; }
                else if (gTwo.gestureID == 1) { winningGesture = gOne; }
                else if (gTwo.gestureID == 3) { winningGesture = gOne; }
            }//Scissors
            else if (gOne.gestureID == 3) 
            {
                if (gTwo.gestureID == 3) { winningGesture.gestureName = "TIE"; winningGesture.gestureID = 5; }
                else if (gTwo.gestureID == 0) { winningGesture = gTwo; }
                else if (gTwo.gestureID == 2) { winningGesture = gTwo; }
                else if (gTwo.gestureID == 1) { winningGesture = gOne; }
                else if (gTwo.gestureID == 4) { winningGesture = gOne; }
            }//Lizzard
            else if (gOne.gestureID == 4) 
            {
                if (gTwo.gestureID == 4) { winningGesture.gestureName = "TIE"; winningGesture.gestureID = 5; }
                else if (gTwo.gestureID == 3) { winningGesture = gTwo; }
                else if (gTwo.gestureID == 1) { winningGesture = gTwo; }
                else if (gTwo.gestureID == 2) { winningGesture = gOne; }
                else if (gTwo.gestureID == 0) { winningGesture = gOne; }
            }//Spock
            return winningGesture;
        }
        public string WinMessage(Gestures winningGesture) 
        {
            string message = "";
            if (winningGesture.gestureID == 0) { message = "ROCK WAS VICTORIOUS"; }
            else if (winningGesture.gestureID == 1) { message = "PAPER WAS VICTORIOUS"; }
            else if (winningGesture.gestureID == 2) { message = "SCISSORS WAS VICTORIOUS"; }
            else if (winningGesture.gestureID == 3) { message = "LIZZARD WAS VICTORIOUS"; }
            else if (winningGesture.gestureID == 4) { message = "SPOCK WAS VICTORIOUS"; }

            return message;
        }
        
    }
}
