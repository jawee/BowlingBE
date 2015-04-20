using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BowlingBE.Models
{
    public class BowlingGame
    {
        public int score { get; set; }

        public BowlingGame(List<BowlingFrame> list)
        {
            score = CountScore(list);
        }

        private int CountScore(List<BowlingFrame> list)
        {
            return 0;
        }
    }
}