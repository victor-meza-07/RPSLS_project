using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    class Human : Players
    {
        Validation val;
        public Human()
        {
            val = new Validation();
        }

        public override void ResetMyScore()
        {
            this.score = 0;
        }
        public override void promptMyGesture()
        {
            Console.WriteLine($"{name} please select a gesture");
            Console.WriteLine(" ");
            foreach (Gestures g in listofGestures) 
            {
                Console.WriteLine($"{g.gestureID}.{g.gestureName}");
            }
            int choice = val.uservalidation(listofGestures.Count, Console.ReadLine());
            while (val.NegativeNumberValidation(choice))
            {
                Console.WriteLine("You can't select a move for someone else");
                choice = val.NumberValidation(Console.ReadLine());
            }
            foreach (Gestures g in listofGestures) 
            {
                if (g.gestureID == choice) 
                {
                    gesture = g;
                }
            }
        }

    }
}
