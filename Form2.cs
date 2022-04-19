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

        public string pictName = "";
        public int pictNumber;

        public int trefa = 0;
        public int konecHry = 12;
        public int otoceno = 0;
        public int skore = 0;
        public int body = 10;


        public Form2()
        {
            InitializeComponent();
            Logic logic = new Logic(this);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SestavBoard(vybranePozadi);
            b.PozadiImg = pozadiImg;
            NovaHra();
            //Aktualizuj();
        }
            
        private void NovaHra()
        {
            RozdejKarty();
           
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

            //Aktualizuj();
        }

     
        public void Hra(int otoceno)
        {
            if (trefa <= konecHry)
            {
                if (otoceno == 0)
                {
                    otoceno++;
                    PriradTempImage(otoceno);
                    System.Diagnostics.Debug.WriteLine("První karta otočená");
                }
                else if (otoceno == 1)
                {
                    otoceno++;
                    PriradTempImage(otoceno);
                    System.Diagnostics.Debug.WriteLine("Druhá karta otočená");
                    Vyhodnoceni(pictNumber, pictNumber);
                }
                //else if (otoceno == 2)
                //{
                //    otoceno = 0;
                //}
            } else
            {
                System.Diagnostics.Debug.WriteLine("KonecHry");
            }

        }

        public Image TempImage()
        {
            for (int i = 0; i < logic.karty.Count; i++)
            {
                if (pictNumber + 1 == logic.karty[i].Id)
                {
                    logic.pictureBoxes[pictNumber].BackgroundImage = logic.karty[i].PredniStrana;
                    break;
                }
            }
            return tempImage;
        }

        public void PriradTempImage(int karta)
        {
            if (karta == 1)
            {
                tempImg1 = TempImage();
            }
            else if (karta == 2)
            {
                tempImg2 = TempImage();
            }
        }

        public void Vyhodnoceni(int prvniKarta, int druhaKarta)
        {
            // obě karty shodné
            if (logic.pictureBoxes[prvniKarta].Tag == logic.pictureBoxes[druhaKarta].Tag)
            {
                System.Diagnostics.Debug.WriteLine("Karta1: " + logic.pictureBoxes[prvniKarta].Tag);
                System.Diagnostics.Debug.WriteLine("Karta2: " + logic.pictureBoxes[druhaKarta].Tag);
                System.Diagnostics.Debug.WriteLine("Trefa");
                trefa++;
                // prední strana zustane 
                logic.pictureBoxes[prvniKarta].BackgroundImage = logic.karty[prvniKarta].PredniStrana;
                logic.pictureBoxes[druhaKarta].BackgroundImage = logic.karty[druhaKarta].PredniStrana;


                //vynulování dočasných image
                System.Diagnostics.Debug.WriteLine("Nuluju image");
                tempImg1 = null;
                tempImg2 = null;

                // skore skáče po 10ti bodech
                skore += body;
                label2.Text = Convert.ToString(skore);
                otoceno = 0;
            }
            else
            {
                //timer - po dobu 1s 
                timer1.Start();
                // zadní strana
                logic.pictureBoxes[prvniKarta].BackgroundImage = k.ZadniStrana;
                logic.pictureBoxes[druhaKarta].BackgroundImage = k.ZadniStrana;
                //vynulování dočasných image
                tempImg1 = null;
                tempImg2 = null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        
        
        // klik na kartu
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }
      
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
           
            Hra(otoceno);
            otoceno++;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
           
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }


        private void pictureBox15_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            Hra(otoceno);
            otoceno++;
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10)) - 1;
            System.Diagnostics.Debug.WriteLine("Name: " + pictName);
            System.Diagnostics.Debug.WriteLine("PictNumber: " + pictNumber);
            Hra(otoceno);
            otoceno++;
        }
    }
}

