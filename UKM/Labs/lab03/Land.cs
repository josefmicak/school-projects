using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKM1Project
{
    public class Land
    {
        public int squareMeters { get; set; }
        public string lawnType { get; set; }
        public int treesCount { get; set; }
        public int fenceHeight { get; set; }
        
        public Land(int squareMeters, string lawnType, int treesCount, int fenceHeight)
        {
            this.squareMeters = squareMeters;
            this.lawnType = lawnType;
            this.treesCount = treesCount;
            this.fenceHeight = fenceHeight;
        }
    }
}
