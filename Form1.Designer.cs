namespace Pexeso
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.volbaPozadíToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.woodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.natureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.candlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volbaMotivuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.christmasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emojiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alphabetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(64, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pexeso | Memory Game";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(64, 570);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(422, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "HRÁT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(58, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(437, 470);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.volbaPozadíToolStripMenuItem,
            this.volbaMotivuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(545, 29);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // volbaPozadíToolStripMenuItem
            // 
            this.volbaPozadíToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.woodToolStripMenuItem,
            this.natureToolStripMenuItem,
            this.candlesToolStripMenuItem});
            this.volbaPozadíToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.volbaPozadíToolStripMenuItem.Name = "volbaPozadíToolStripMenuItem";
            this.volbaPozadíToolStripMenuItem.Size = new System.Drawing.Size(111, 25);
            this.volbaPozadíToolStripMenuItem.Text = "Volba pozadí";
            // 
            // woodToolStripMenuItem
            // 
            this.woodToolStripMenuItem.Name = "woodToolStripMenuItem";
            this.woodToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.woodToolStripMenuItem.Text = "wood";
            this.woodToolStripMenuItem.Click += new System.EventHandler(this.woodToolStripMenuItem_Click);
            // 
            // natureToolStripMenuItem
            // 
            this.natureToolStripMenuItem.Name = "natureToolStripMenuItem";
            this.natureToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.natureToolStripMenuItem.Text = "nature";
            this.natureToolStripMenuItem.Click += new System.EventHandler(this.natureToolStripMenuItem_Click);
            // 
            // candlesToolStripMenuItem
            // 
            this.candlesToolStripMenuItem.Name = "candlesToolStripMenuItem";
            this.candlesToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.candlesToolStripMenuItem.Text = "candles";
            this.candlesToolStripMenuItem.Click += new System.EventHandler(this.candlesToolStripMenuItem_Click);
            // 
            // volbaMotivuToolStripMenuItem
            // 
            this.volbaMotivuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.christmasToolStripMenuItem,
            this.emojiToolStripMenuItem,
            this.animalsToolStripMenuItem,
            this.alphabetToolStripMenuItem});
            this.volbaMotivuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.volbaMotivuToolStripMenuItem.Name = "volbaMotivuToolStripMenuItem";
            this.volbaMotivuToolStripMenuItem.Size = new System.Drawing.Size(114, 25);
            this.volbaMotivuToolStripMenuItem.Text = "Volba motivu";
            // 
            // christmasToolStripMenuItem
            // 
            this.christmasToolStripMenuItem.Name = "christmasToolStripMenuItem";
            this.christmasToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.christmasToolStripMenuItem.Text = "christmas";
            this.christmasToolStripMenuItem.Click += new System.EventHandler(this.christmasToolStripMenuItem_Click);
            // 
            // emojiToolStripMenuItem
            // 
            this.emojiToolStripMenuItem.Name = "emojiToolStripMenuItem";
            this.emojiToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.emojiToolStripMenuItem.Text = "emoji";
            this.emojiToolStripMenuItem.Click += new System.EventHandler(this.emojiToolStripMenuItem_Click);
            // 
            // animalsToolStripMenuItem
            // 
            this.animalsToolStripMenuItem.Name = "animalsToolStripMenuItem";
            this.animalsToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.animalsToolStripMenuItem.Text = "animals";
            this.animalsToolStripMenuItem.Click += new System.EventHandler(this.animalsToolStripMenuItem_Click);
            // 
            // alphabetToolStripMenuItem
            // 
            this.alphabetToolStripMenuItem.Name = "alphabetToolStripMenuItem";
            this.alphabetToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.alphabetToolStripMenuItem.Text = "alphabet";
            this.alphabetToolStripMenuItem.Click += new System.EventHandler(this.alphabetToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 634);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pexeso | Memory Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button button1;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem volbaPozadíToolStripMenuItem;
        private ToolStripMenuItem woodToolStripMenuItem;
        private ToolStripMenuItem natureToolStripMenuItem;
        private ToolStripMenuItem candlesToolStripMenuItem;
        private ToolStripMenuItem volbaMotivuToolStripMenuItem;
        private ToolStripMenuItem christmasToolStripMenuItem;
        private ToolStripMenuItem emojiToolStripMenuItem;
        private ToolStripMenuItem animalsToolStripMenuItem;
        private ToolStripMenuItem alphabetToolStripMenuItem;
    }
}