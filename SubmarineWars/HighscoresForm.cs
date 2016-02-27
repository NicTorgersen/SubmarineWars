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
    public partial class HighscoresForm : Form
    {

        MainMenuForm mainmenu;
        ConfigurationHelper config;

        public HighscoresForm(MainMenuForm mainmenu)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.mainmenu = mainmenu;
            this.config = new ConfigurationHelper();

            ShowHighscores();
        }

        private void ShowHighscores()
        {
            int count = 0;
            List<KeyValuePair<string, int>> highscores = config.ReadHighscores();

            if (highscores.Count < 1) {
                Label label = new Label();
                Font labelFont = new Font(label.Font.FontFamily, 26);

                label.Font = labelFont;
                label.ForeColor = Color.White;
                label.Location = new Point(12, 9);
                label.Text = "Ingen highscores.";
                label.AutoSize = true;

                this.Controls.Add(label);
                return;
            }

            foreach (KeyValuePair<string, int> highscore in highscores)
            {
                Console.WriteLine("{0} fra {1}", highscore.Value, highscore.Key);
                Label labelName = new Label();
                Label labelScore = new Label();
                Font labelFont = new Font(labelName.Font.FontFamily, 26);

                labelName.Font = labelFont;
                labelName.ForeColor = Color.White;
                labelName.Location = new Point( 12, ((count < 1) ? 9 : (45 * count) + 9) );
                labelName.Text = (count + 1) + ". " + highscore.Key;
                labelName.AutoSize = true;

                labelScore.Font = labelFont;
                labelScore.ForeColor = Color.White;
                labelScore.Location = new Point( 200, ((count < 1) ? 9 : (45 * count) + 9) );
                labelScore.Text = "" + highscore.Value;
                labelScore.AutoSize = true;

                this.Controls.Add(labelName);
                this.Controls.Add(labelScore);
                count++;
                if (count == 10) { return; }
            }
        }

        // "Lukk" button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            mainmenu.Show();
        }

    }
}
