using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    class Computer : Players
    {
        Random random;
        
        public Computer()
        {
            random = new Random();
        }

        public override void ResetMyScore()
        {
            this.score = 0;
        }
        public override void promptMyGesture()
        {
            int gestureChoice = 0;
            gestureChoice = random.Next(0, listofGestures.Count);
            foreach (Gestures g in listofGestures) 
            {
                if (g.gestureID == gestureChoice) 
                {
                    this.gesture = g;
                }
            }
        }
    }
}
