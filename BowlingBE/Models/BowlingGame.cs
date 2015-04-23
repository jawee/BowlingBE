using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBE.Models
{
    public class BowlingGame
    {
        public int Score { get; set; }

        public BowlingGame(int Score)
        {
            this.Score = Score;
        }
    }
}
