using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BowlingBE.Models
{
    public class BowlingGame
    {

        public List<BowlingFrame> Frames { get; set; } 
        public int CountScore()
        {
            if (Frames.Count > 10)
            {
                return -1;
            }

            var score = 0;
            var strike = false;
            var spare = false;
            foreach (var frame in Frames)
            {
                if (strike)
                {
                    strike = false;
                    score += frame.First + frame.Second;
                }
                if (spare)
                {
                    spare = false;
                    score += frame.First;
                }
                // Strike
                if (frame.First == 10)
                {
                    score += 10;
                    strike = true;
                }
                else if (frame.First + frame.Second == 10)
                {
                    score += 10;
                    spare = true;
                }
                else
                {
                    score += frame.First + frame.Second;
                }
            }
            return score;
        }

        private int CalculateFrame(BowlingFrame frame)
        {
            var score = 0;
            //Strike
            
            return 0;
        }
    }
}