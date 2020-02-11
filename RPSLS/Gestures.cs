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

        }

        public Gestures gestureLogic(Gestures gOne, Gestures gTwo) 
        {

            Gestures winningGesture = new Gestures();
            if (gOne.gestureID == 0) 
            {
                if (gTwo.gestureID == 0) { winningGesture.gestureName = "TIE"; winningGesture.gestureID = 5; }
                else if (gTwo.gestureID == 3) { winningGesture = gTwo; }
                else if (gTwo.gestureID == 2) { winningGesture = gTwo; }
                else if (gTwo.gestureID == 1) { winningGesture = gOne; }
                else if (gTwo.gestureID == 4) { winningGesture = gOne; }
            }//Rock
            else if (gOne.gestureID == 0) 
            {

            }//Paper
            else if (gOne.gestureID == 0) { }//Scissors
            else if (gOne.gestureID == 0) { }//Lizzard
            else if (gOne.gestureID == 0) { }//Spock
            

            return winningGesture;
        }
        
    }
}
