using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    class Cell
    {
        public bool IsMine { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsRevealed { get; set; }
        public int NearbyMines { get; set; }
        public static int Size { get; set; }
        public Cell()
        {
            IsMine = false;
            IsFlagged = false;
            IsRevealed = false;
            NearbyMines = 0;
        }
    }
}