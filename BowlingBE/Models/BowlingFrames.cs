using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BowlingBE.Models
{
    public class BowlingFrames
    {
        public List<BowlingFrame> Frames { get; set; }

        public BowlingFrames(List<BowlingFrame> frames)
        {
            this.Frames = frames;
        }
    }
}