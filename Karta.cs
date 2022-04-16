using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pexeso
{
    public class Karta
    {
        public Bitmap PredniStrana { get; set; }
        public Bitmap ZadniStrana { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Karta(Bitmap predniStrana, Bitmap zadniStrana, int x, int y)
        {
            this.PredniStrana = predniStrana;
            this.ZadniStrana = zadniStrana;
            this.X = x;
            this.Y = y;
        }
    }
}
