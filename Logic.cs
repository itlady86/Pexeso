using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pexeso
{
    public class Logic
    {
        private Form1 f1;

        private static int pocetKaret = 24;

        // cesty, adresáře
        private static string rootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;

        // board
        private static string board = rootDir + "/images/board";
        public static String[] boardPaths = Directory.GetFiles(board);
        public static Image[] boards = new Image[boardPaths.Length];

        // zadní strana
        private static string background = rootDir + "/images/bg";
        public static String[] bgPaths = Directory.GetFiles(background);

        // motivy přední strany
        private static string motiv_01 = rootDir + "/images/motiv01";
        private static string motiv_02 = rootDir + "/images/motiv02";
        private static string motiv_03 = rootDir + "/images/motiv03";
        private static string motiv_04 = rootDir + "/images/motiv04";

        // v adresáři pouze 12 karet
        private static String[] motiv01Paths = Directory.GetFiles(motiv_01);
        private static String[] motiv02Paths = Directory.GetFiles(motiv_02);
        private static String[] motiv03Paths = Directory.GetFiles(motiv_03);
        private static String[] motiv04Paths = Directory.GetFiles(motiv_04);

        // pole 12 karet podle motivů
        private static Image[] christmas1 = new Image[motiv01Paths.Length];
        private static Image[] emoji1 = new Image[motiv02Paths.Length];
        private static Image[] animals1 = new Image[motiv03Paths.Length];
        private static Image[] alphabet1 = new Image[motiv04Paths.Length];

        // pole pro 24 karet, které budou dále použity
        private static Image[] christmas = new Image[pocetKaret];
        private static Image[] emoji = new Image[pocetKaret];
        private static Image[] animals = new Image[pocetKaret];
        private static Image[] alphabet = new Image[pocetKaret];

        // dočasné pole pro 24 karet
        public Image[] pole24 = new Image[pocetKaret];

        // posun pro zdvojené pole
        private int offset = pocetKaret/2;


        public Logic() { }

        public Logic(Form1 f1) 
        {
            this.f1 = f1;
        }

        public void VyberMotiv(string motiv)
        {
            switch (motiv)
            {
                case "christmas":
                    NaplPoleMotivy(motiv01Paths, christmas1);
                    break;
                case "emoji":
                    NaplPoleMotivy(motiv02Paths, emoji1);
                    break;
                case "animals":
                    NaplPoleMotivy(motiv03Paths, animals1);
                    break;
                case "alphabet":
                    NaplPoleMotivy(motiv04Paths, alphabet1);
                    break;
            }
        }

        private Image[] NaplPoleMotivy(String[] path12, Image[] pole12)
        {
            for (int i = 0; i < path12.Length; i++)
            {
                pole12[i] = Image.FromFile(path12[i]);
            }
            for (int i = 0; i < offset; i++)
            {
                pole24[i] = pole12[i];
                pole24[i + offset] = pole12[i];
            }
           
            return pole24;
        }
    }
}
