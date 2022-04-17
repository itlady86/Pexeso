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

        

        //public Image[] pole24;

        public int shoda;
        public int otoceno;
        

        public Form2()
        {
            InitializeComponent();
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


        private void RozdejKarty()
        {
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
        }

        //DEBUG
        private void button1_Click(object sender, EventArgs e)
        {
            logic.VyberMotiv(vybranyMotiv);
            foreach (PictureBox picture in tableLayoutPanel1.Controls)
            {
                picture.BackgroundImageLayout = ImageLayout.Stretch;
                for (int i = 0; i < logic.pole24.Length; i++)
                {
                    picture.BackgroundImage = logic.pole24[i];
                }
            }

        }
    }
}
