namespace Pexeso
{
    public partial class Form1 : Form
    {
        public string vybranePozadi = "";
        public string vybranyMotiv = "";

        public Form1()
        {
            InitializeComponent();
            Logic logic = new Logic(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //defaultn� hodnoty v MenuStrip
            woodToolStripMenuItem.Checked = true;
            christmasToolStripMenuItem.Checked = true;
            vybranePozadi = volbaPozad�ToolStripMenuItem.DropDownItems[0].ToString();
            vybranyMotiv = volbaMotivuToolStripMenuItem.DropDownItems[0].ToString();
        }

        // tla��tko HR�T
        private void button1_Click(object sender, EventArgs e)
        {
            var GameWindow = new Form2();
            //System.Diagnostics.Debug.WriteLine("Pozad�: " + vybranePozadi);
            //System.Diagnostics.Debug.WriteLine("Motiv: " + vybranyMotiv);

            //p�ed�n� promennych do dalsiho okna
            GameWindow.vybranePozadi = this.vybranePozadi;
            GameWindow.vybranyMotiv = this.vybranyMotiv;
            GameWindow.Show();
        }

        // p�ep�n�n� checknut�
        private void woodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vybranePozadi = volbaPozad�ToolStripMenuItem.DropDownItems[0].ToString();
            woodToolStripMenuItem.Checked = true;
            natureToolStripMenuItem.Checked = false;
            candlesToolStripMenuItem.Checked = false;
        }

        private void natureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vybranePozadi = volbaPozad�ToolStripMenuItem.DropDownItems[1].ToString();
            woodToolStripMenuItem.Checked = false;
            natureToolStripMenuItem.Checked = true;
            candlesToolStripMenuItem.Checked = false;
        }

        private void candlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vybranePozadi = volbaPozad�ToolStripMenuItem.DropDownItems[2].ToString();
            woodToolStripMenuItem.Checked = false;
            natureToolStripMenuItem.Checked = false;
            candlesToolStripMenuItem.Checked = true;
        }

        private void christmasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vybranyMotiv = volbaMotivuToolStripMenuItem.DropDownItems[0].ToString();
            christmasToolStripMenuItem.Checked = true;
            emojiToolStripMenuItem.Checked = false;
            animalsToolStripMenuItem.Checked = false;
            alphabetToolStripMenuItem.Checked = false;
        }

        private void emojiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vybranyMotiv = volbaMotivuToolStripMenuItem.DropDownItems[1].ToString();
            christmasToolStripMenuItem.Checked = false;
            emojiToolStripMenuItem.Checked = true;
            animalsToolStripMenuItem.Checked = false;
            alphabetToolStripMenuItem.Checked = false;
        }

        private void animalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vybranyMotiv = volbaMotivuToolStripMenuItem.DropDownItems[2].ToString();
            christmasToolStripMenuItem.Checked = false;
            emojiToolStripMenuItem.Checked = false;
            animalsToolStripMenuItem.Checked = true;
            alphabetToolStripMenuItem.Checked = false;
        }

        private void alphabetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vybranyMotiv = volbaMotivuToolStripMenuItem.DropDownItems[3].ToString();
            christmasToolStripMenuItem.Checked = false;
            emojiToolStripMenuItem.Checked = false;
            animalsToolStripMenuItem.Checked = false;
            alphabetToolStripMenuItem.Checked = true;
        }
    }
}