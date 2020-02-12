using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    public abstract class Players
    {
        public int score;
        public Gestures gesture;
        public string name;
        public List<Gestures> listofGestures;
        public Players()
        {
            listofGestures = new List<Gestures>();
            flushvalues();
            addmyGestures();
        }

        public abstract void ResetMyScore();
        public abstract void promptMyGesture();
        private void addmyGestures() 
        {
            listofGestures.Add(new Gestures { gestureName = "Rock", gestureID = 0 });
            listofGestures.Add(new Gestures { gestureName = "Paper", gestureID = 1 });
            listofGestures.Add(new Gestures { gestureName = "Scissors", gestureID = 2 });
            listofGestures.Add(new Gestures { gestureName = "Lizzard", gestureID = 3 });
            listofGestures.Add(new Gestures { gestureName = "Spock", gestureID = 4 });
        }
        private void flushvalues() 
        {
            score = 0;
            gesture = new Gestures();
            listofGestures.Clear();
        }
    }
}
