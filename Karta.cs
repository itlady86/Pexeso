using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pexeso
{
    public class Karta
    {
        public Image PredniStrana { get; set; }
        public Image ZadniStrana = Image.FromFile(Logic.bgPaths[0]);
        public int Id;
        public Karta()
        {
        }

        public Karta(Image predniStrana, int Id)
        {
            this.PredniStrana = predniStrana;
            this.Id = Id;
        }
    }
}
