using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pexeso
{
    public partial class Form2 : Form
    {
        public string vybranePozadi;
        public string vybranyMotiv;

        public Logic logic = new Logic();
        public static Bitmap pozadiImg;
        public Board b = new Board(pozadiImg);
        public Karta k = new Karta();

        public Image PredniStrana;
        public Image tempImg1;
        public Image tempImg2;
        public Image tempImage;

        public string pictName;
        public int pictNumber;

        public bool znovu = false;
        public int otoceno = 0;
        public int skore = 0;
        public int prictiBody = 10;
        public int trefa = 0;
        public int konec = 12;

        public Random rnd = new Random();
        public int prvniKarta;
        public int druhaKarta;
        public string p1;
        public string p2;
        public int tag;
        public int tag1;
        public int tag2;

       
        public Form2()
        {
            InitializeComponent();
            Logic logic = new Logic(this);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SestavBoard(vybranePozadi);
            b.PozadiImg = pozadiImg;
            Hra();
            
        }

        // po odkrytí dvou karet, které nejsou stejné, čeká 2s, pak otočí kartu zadní stranou nahoru
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            SchovejKartu(prvniKarta, druhaKarta);
        }
        
        #region Nastavení boardu
        private Bitmap SestavBoard(string pozadi)
        {
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            switch (pozadi)
            {
                case "wood":
                    NastavImageBoard(0);
                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                    break;
                case "nature":
                    NastavImageBoard(1);                    
                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                    break;
                case "candles":
                    NastavImageBoard(2);
                    label1.ForeColor = Color.White;
                    label2.ForeColor = Color.White;
                    break;
            }
            return pozadiImg;
        }

        private void NastavImageBoard(int index)
        {
            for (int i = 0; i < Logic.boardPaths.Length; i++)
            {
                Logic.boards[i] = Image.FromFile(Logic.boardPaths[i]);
                panel1.BackgroundImage = Logic.boards[index];
            }
        }
        #endregion

        #region Zadní strana
        private void UkazZadniStranu()
        {
            foreach(PictureBox picture in tableLayoutPanel1.Controls)
            {
                picture.BackgroundImage = k.ZadniStrana;
                picture.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
        #endregion

        #region Přední strana
        private List<Karta> UkazPredniStranu()
        {
            logic.VyberMotiv(vybranyMotiv);

            // uložení pictureBoxů do Listu
            foreach (PictureBox picture in tableLayoutPanel1.Controls)
            {
                logic.pictureBoxes.Add(picture);
            }

            // ke každému pictureBoxu přidej Image
            for (int i = 0; i < logic.pictureBoxes.Count; i++)
            {
                for (int j = 0; j < logic.pole24.Length; j++)
                {
                    logic.pictureBoxes[i].BackgroundImage = logic.pole24[i];
                }


                logic.id = logic.id.OrderBy(x => rnd.Next()).ToArray();
                for (int j = 0; j < logic.id.Length; j++)
                {
                    logic.karty.Add(new Karta(logic.pictureBoxes[i].BackgroundImage, logic.id[j]));
                }
            }
            return logic.karty;
        }
        #endregion

        private void Hra()
        {
            UkazPredniStranu();
            UkazZadniStranu();
        }


        #region Kontrola otočení 1 páru karet - přiřazení obrázku, vyhodnocení rovnosti, přepínání povolení kliknutí
        private void Kolo(int otoceno)
        {
            switch (otoceno)
            {
                case 1:
                    PriradTempImage(otoceno);
                    prvniKarta = pictNumber;
                    p1 = pictName;
                    tag1 = tag;
                    ZakazKlik(p1);
                    break;
                case 2:
                    PriradTempImage(otoceno);
                    druhaKarta = pictNumber;
                    p2 = pictName;
                    tag2 = tag;
                    ZakazKlik(p2);
                    Vyhodnot(tag1, tag2);
                    break;
            }
        }
        private void PriradTempImage(int poradiKarty)
        {
            switch (poradiKarty)
            {
                case 1:
                    tempImg1 = TempImage(pictNumber);
                    break;

                case 2:
                    tempImg2 = TempImage(pictNumber);
                    break;
            }
        }
            
        public Image TempImage(int pictNumber)
        {
            for (int i = 0; i < logic.karty.Count; i++)
            {
                if (logic.karty[i].Id == pictNumber)
                {
                    for (int j = 0; j < logic.pictureBoxes.Count; j++)
                    {
                        logic.pictureBoxes[pictNumber].BackgroundImage = logic.karty[pictNumber].PredniStrana;
                    }
                    break;
                }
                
            }
            return tempImage;
        }

        private void Vyhodnot(int tag1, int tag2)
        {
            if (tag1 != tag2) 
            {
                // uvnitř následující metody otočení karet zadní stranou nahoru
                timer1.Start();
                PovolKlik(p1);
                PovolKlik(p2);
                otoceno = 0;
            }
            else
            {   
                // nalezen pár shodných karet
                trefa++;
                System.Diagnostics.Debug.WriteLine("Trefa: " + trefa.ToString());
                ZakazKlik(p1);
                ZakazKlik(p2);
                otoceno = 0;

                // konec hry nebo rozdat znovu
                if (trefa == konec)
                    Znovu();
                //Skore
                skore += prictiBody;
                label2.Text = skore.ToString();
            }
        
        }

        private void ZakazKlik(string jmenoKarty)
        {
            foreach (var p in logic.pictureBoxes)
            {
                if (p.Name.Contains(jmenoKarty))
                {
                    System.Diagnostics.Debug.WriteLine("Karta zakázana");
                    p.Enabled = false;
                    break;
                }
            }
        }

        private void PovolKlik(string jmenoKarty)
        {
            foreach (var p in logic.pictureBoxes)
            {
                if (p.Name.Contains(jmenoKarty))
                {
                    System.Diagnostics.Debug.WriteLine("Karta zakázana");
                    p.Enabled = true;
                    break;
                }
            }
        }
            

        private void SchovejKartu(int prvniKarta, int druhaKarta)
        {
            for (int i = 0; i < logic.karty.Count; i++)
            {
                if (logic.karty[i].Id == prvniKarta)
                {
                    for (int j = 0; j < logic.pictureBoxes.Count; j++)
                    {
                        logic.pictureBoxes[prvniKarta].BackgroundImage = k.ZadniStrana;
                    }
                }
                if (logic.karty[i].Id == druhaKarta)
                {
                    for (int j = 0; j < logic.pictureBoxes.Count; j++)
                    {
                        logic.pictureBoxes[druhaKarta].BackgroundImage = k.ZadniStrana;
                    }
                }
            }
        }

        private void Znovu()
        {
            DialogResult dialogResult = MessageBox.Show("Rozdat znovu", "Konec hry", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Hra();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Konec hry\ntvoje skore: " + skore.ToString()); 
            }
        }
        #endregion

    
        // klik na kartu
        private void KartaClick(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            pictName = picture.Name;        // pictureBox1 - pictureBox24
            tag = Convert.ToInt32(picture.Tag);
            pictNumber = int.Parse(pictName.Substring(10)) - 1;     // číslo 0-23
            otoceno++;
            Kolo(otoceno);
        }
    }
}

