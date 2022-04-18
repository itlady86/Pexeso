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

        public List<Karta> karty = new List<Karta>();
        public Image PredniStrana;
        public Image tempImg;
        public int[] id = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
                            13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        public List<PictureBox> pictureBoxes = new List<PictureBox>();

        public string pictName = "";
        public int pictNumber;
        public int shoda;
        public int otoceno;
        public bool znovu = false;
        

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
                pictureBoxes.Add(picture);
            }

            // ke každému pictureBoxu přidej Image + naplnění Listu karty
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                for (int j = 0; j < logic.pole24.Length; j+=2)
                {
                    pictureBoxes[i].BackgroundImage = logic.pole24[i];
                    karty.Add(new Karta(pictureBoxes[i].BackgroundImage, id[i]));
                }
            }

            return karty;
        }
           
  
      
        private void RozdejKarty()
        {
            UkazPredniStranu();
            UkazZadniStranu();
            shoda = 0;
            otoceno = 0;
            tableLayoutPanel1.Enabled = true;

            //Aktualizuj();
        }
        
        
        // klik na jakoukoli kartu
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            picture.Enabled = false;
            pictName = picture.Name;
            pictNumber = int.Parse(pictName.Substring(10));

            System.Diagnostics.Debug.WriteLine("PictName: " + pictName);
            System.Diagnostics.Debug.WriteLine("PictNumber: " + pictNumber);

            for (int i = 0; i < karty.Count; i++)
            {
                if (pictNumber == karty[i].Id)
                {
                    picture.BackgroundImage = karty[i].PredniStrana;
                }
            }
            // picture.Refresh();

        }

        //DEBUG
        private void button1_Click(object sender, EventArgs e)
        {
          
        }
    }
}

