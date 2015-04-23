using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingBE.Models;

namespace BowlingBE.Repository
{
    class BowlingRepository
    {

        public static BowlingGame CountScore(BowlingFrames bowlingFrames)
        {
            if (bowlingFrames.Frames.Count > 10)
            {
                return new BowlingGame(-1);
            }

            var score = 0;
            var strike = false;
            var spare = false;
            foreach (var frame in bowlingFrames.Frames)
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
            
            return new BowlingGame(score);
        }
    }
}
