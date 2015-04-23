using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BowlingBE.Models;

namespace BowlingBE.Repository
{
    public class BowlingRepository
    {
        private List<int> rollList;
        private List<BowlingFrame> framesList; 
        public BowlingRepository(BowlingFrames bowlingFrames)
        {
            framesList = bowlingFrames.Frames;
            rollList = new List<int>();
            foreach (var frame in framesList)
            {
                rollList.Add(frame.First);
                rollList.Add(frame.Second);
                if (frame.Third != 0)
                {
                    rollList.Add(frame.Third);
                }
            }
            if (framesList.Count < 10)
            {
                for (var i = framesList.Count; i < 10; i++)
                {
                    rollList.Add(0);
                    rollList.Add(0);
                    framesList.Add(new BowlingFrame(0, 0));
                }
                
            }
        }

        private static int SumFrame(BowlingFrame frame)
        {
            return frame.First + frame.Second + frame.Third;
        }

        private static bool FrameIsStrike(BowlingFrame frame)
        {
            return frame.First == 10;
        }

        private int CalculateStrikeScore(BowlingFrame frame)
        {
            var indexOfFrame = framesList.IndexOf(frame);
            var nextFrame = framesList[indexOfFrame + 1];
            if (!FrameIsStrike(nextFrame))
            {
                return 10 + SumFrame(nextFrame);
            }
            if (indexOfFrame + 1 >= framesList.Count)
            {
                return 10;
            }
            return 10 + CalculateStrikeScore(framesList[indexOfFrame + 1]) - framesList[indexOfFrame + 2].Second;
        }

        public BowlingGame CountScore()
        {
            if (framesList.Count > 10)
            {
                return new BowlingGame(-1);
            }

            var score = 0;
            var strike = false;
            var spare = false;
            var strikeCount = 0;
            foreach (var frame in framesList)
            {
                if (spare)
                {
                    spare = false;
                    score += frame.First;
                }
                // Strike
                if (FrameIsStrike(frame))
                {
                    score += CalculateStrikeScore(frame);
                }
                else if (frame.First + frame.Second == 10) // Spare
                {
                    score += 10;
                    spare = true;
                    if (frame.Third != 0)
                    {
                        //last frame
                        score += frame.Third;
                    }
                }
                else
                {
                    score += frame.First + frame.Second + frame.Third;
                }
            }

            return new BowlingGame(score);
        }

    }
}
