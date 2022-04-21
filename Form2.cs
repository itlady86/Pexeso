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
        public int pictNumber = -1;

        public int trefa = 0;
        public int konecHry = 12;
        public int otoceno = 0;
        public int skore = 0;
        public int prictiBody = 10;

        public int prvniKarta;
        public int druhaKarta;
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
            RozdejKarty();
            //while (trefa < konecHry)
            //{
            //}
          
        }

        // po odkyrtí dvou karet, které nejsou stejné, čeká 2s, pak otočí kartu zadní stranou nahoru
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



        
        private List<Karta> UkazPredniStranu()
        {
            logic.VyberMotiv(vybranyMotiv);

            // uložení pictureBoxů do Listu
            foreach (PictureBox picture in tableLayoutPanel1.Controls)
            {
                logic.pictureBoxes.Add(picture);
            }

            // ke každému pictureBoxu přidej Image + naplnění Listu karty
            for (int i = 0; i < logic.pictureBoxes.Count; i++)
            {
                for (int j = 0; j < logic.pole24.Length; j+=2)
                {
                    logic.pictureBoxes[i].BackgroundImage = logic.pole24[i];
                    logic.karty.Add(new Karta(logic.pictureBoxes[i].BackgroundImage, logic.id[i]));
                    break;
                }
            }

            return logic.karty;
        }


        private void RozdejKarty()
        {
            UkazPredniStranu();
            UkazZadniStranu();
            tableLayoutPanel1.Enabled = true;

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

        private void Kolo(int otoceno)
        {
            switch (otoceno)
            {
                case 1:
                    PriradTempImage(otoceno);
                    prvniKarta = pictNumber;
                    tag1 = tag;
                    break;
                case 2:
                    PriradTempImage(otoceno);
                    druhaKarta = pictNumber;
                    tag2 = tag;
                    Vyhodnot(tag1, tag2);

                    // vynulování otočení karet
                    otoceno = 0;
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

        
        private void Vyhodnot(int tag1, int tag2)
        {
            if (tag1 != tag2) 
            {
                // uvnitř následující metody otočení karet zadní stranou nahoru
                timer1.Start();
            }
            else
            {   // nalezen pár shodných karet

                
            }

        }

      

        // klik na kartu
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            //picture.Enabled = false;
            picture.Cursor = Cursors.Hand;
            pictName = picture.Name;        // pictureBox1 - pictureBox24
            tag = Convert.ToInt32(picture.Tag);
            pictNumber = int.Parse(pictName.Substring(10)) - 1;     // číslo 0-23
            otoceno++;
            Kolo(otoceno);
        }
      
       
    }
}

