using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    class Score
    {
        public string Name { get; set; }
        public string Time { get; set; }
        public string Difficulty { get; set; }
        public Score()
        {
            Name = "";
            Time = "";
            Difficulty = "";
        }
        public Score(string name, string time, string diff)
        {
            Name = name;
            Time = time;
            Difficulty = diff;
        }
        public Score(string name, TimeSpan time)
        {
            Name = name;
            Time = "" + time.Hours + ":" + time.Minutes + ":" + time.Seconds;
            switch (Game.Rows)
            {
                case 9:
                    Difficulty = "Easy";
                    break;
                case 16:
                    Difficulty = "Normal";
                    break;
                case 30:
                    Difficulty = "Hard";
                    break;
                default:
                    Difficulty = "Custom";
                    break;
            }
        }
    }
}