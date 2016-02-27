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
    public partial class MainMenuForm : Form
    {
        
        public ConfigurationHelper config = new ConfigurationHelper();

        public MainMenuForm()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        // "Avslutt" button
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        // "Highscores" button
        private void button4_Click(object sender, EventArgs e)
        {
            Form highscores = new HighscoresForm(this);
            highscores.Owner = this;
            highscores.Show();
            this.Hide();
        }

        // "Start spill" button
        private void button2_Click(object sender, EventArgs e)
        {
            Form game = new GameForm(this);
            game.Owner = this;
            game.Show();
            this.Hide();
        }

    }
}
