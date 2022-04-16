using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pexeso
{
    public class Board
    {
        public Bitmap PozadiImg { get; set; }

        public Board(Bitmap pozadiImg)
        {
            this.PozadiImg = pozadiImg;
        }
    }
}
