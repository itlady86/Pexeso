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

        private static string rootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        private static string motiv_01 = rootDir + "/images/motiv01";
        private static string motiv_02 = rootDir + "/images/motiv02";
        private static string motiv_03 = rootDir + "/images/motiv03";
        private static string motiv_04 = rootDir + "/images/motiv04";
        private static string board = rootDir + "/images/board";
        private static string background = rootDir + "/images/bg";
        private static String[] motiv01Paths = Directory.GetFiles(motiv_01);
        private static String[] motiv02Paths = Directory.GetFiles(motiv_02);
        private static String[] motiv03Paths = Directory.GetFiles(motiv_03);
        private static String[] motiv04Paths = Directory.GetFiles(motiv_04);
        private static String[] boardPaths = Directory.GetFiles(board);
        private static String[] bgPaths = Directory.GetFiles(background);

        private static Image[] boards = new Image[boardPaths.Length];
        public static Bitmap pozadiImg;
        public Board b = new Board(pozadiImg);

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SestavBoard(vybranePozadi);
            b.PozadiImg = pozadiImg;
        }


        private Bitmap SestavBoard(string pozadi)
        {
            switch (pozadi)
            {
                case "wood":
                    for (int i = 0; i < boardPaths.Length; i++)
                    {
                        boards[i] = Image.FromFile(boardPaths[i]);
                        panel1.BackgroundImage = boards[0];
                        panel1.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                    break;
                case "nature":
                    for (int i = 0; i < boardPaths.Length; i++)
                    {
                        boards[i] = Image.FromFile(boardPaths[i]);
                        panel1.BackgroundImage = boards[1];
                        panel1.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                    break;
                case "candles":
                    for (int i = 0; i < boardPaths.Length; i++)
                    {
                        boards[i] = Image.FromFile(boardPaths[i]);
                        panel1.BackgroundImage = boards[2];
                        panel1.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    
                    label1.ForeColor = Color.White;
                    label2.ForeColor = Color.White;
                    break;
            }
            return pozadiImg;
        }



    }
}
