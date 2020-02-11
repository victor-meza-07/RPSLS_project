
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public class Player
    {
        public string playerName;
        public List<Gestures> listofGestures;
        public int score;
        
        /// <summary>
        /// Generates a New Player with a list of possible moves
        /// </summary>
        public Player()
        {
            generateMyGestureLibreary();
        }

        public void generateMyGestureLibreary() 
        {
            listofGestures.Add(new Gestures{ gestureName = "Rock", gestureID = 0 });
            listofGestures.Add(new Gestures { gestureName = "Paper", gestureID = 1 });
            listofGestures.Add(new Gestures { gestureName = "Scissors", gestureID = 2 });
            listofGestures.Add(new Gestures { gestureName = "Lizzard", gestureID = 3 });
            listofGestures.Add(new Gestures { gestureName = "Spock", gestureID = 4 });
        }
        public void AddtoPlayerScore(int addedScore) 
        {
            this.score = this.score + addedScore;
        }
    }
}
