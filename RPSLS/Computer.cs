using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    class Computer : Players
    {
        int ID;
        public Computer()
        {}

        public override void ResetMyScore()
        {
            this.score = 0;
        }
        public override void promptMyGesture()
        {
            
        }
    }
}
