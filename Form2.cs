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

        public string pictName = "";
        public int pictNumber;

        public int krok;
        public int firstIndex;
        public int nalezeno;       

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
            logic.shoda = false;
            logic.otoceno = 0;
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

            for (int i = 0; i < logic.karty.Count; i++)
            {
                if (pictNumber == logic.karty[i].Id)
                {
                    picture.BackgroundImage = logic.karty[i].PredniStrana;
                    break;
                }
            }

            if (tempImg1 == null)
            {
                tempImg1 = picture.BackgroundImage;
                System.Diagnostics.Debug.WriteLine("První karta");
                System.Diagnostics.Debug.WriteLine("Tag: " + picture.Tag.ToString());
            }
            else if (tempImg1 != null && tempImg2 == null)
            {
                tempImg2 = picture.BackgroundImage;
                System.Diagnostics.Debug.WriteLine("Druhá karta");
            }

            if (tempImg2 != null && tempImg2 != null)
            {
                if (tempImg1.Tag == tempImg2.Tag)
                {
                    System.Diagnostics.Debug.WriteLine("Trefa");
                    tempImg1 = null;
                    tempImg2 = null;
                    picture.Enabled = false;
                    //skore zde
                }
                else
                    //není shoda
                    System.Diagnostics.Debug.WriteLine("Otočka");
                    // casovac
            }  

            picture.Refresh();

        }
      


        //DEBUG
        private void button1_Click(object sender, EventArgs e)
        {
          
        }
    }
}

