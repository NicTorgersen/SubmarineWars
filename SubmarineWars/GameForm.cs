using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubmarineWars
{
    public partial class GameForm : Form
    {
        MainMenuForm mainmenu;
        int score = 0;
        int level;
        Point[] enemies;
        Point torpedo;

        public GameForm(MainMenuForm mainmenu)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.mainmenu = mainmenu;


        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {

        }
        private void GameForm_Load(object sender, EventArgs e)
        {
            this.UpdateScore(score);
        }

        // Helper for å oppdatere score in game
        private void UpdateScore(int newScore)
        {
            label1.Text = newScore.ToString() + " pts";
        }

        // Avslutt
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            mainmenu.Show();
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            PaintHero(e.Graphics);
            PaintEnemies(e.Graphics);
        }

        private void PaintEnemies(Graphics g)
        {
            
        }

        private void PaintHero(Graphics g)
        {
            
        }

    }
}
