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
using System.Xml;

namespace SubmarineWars
{
    public partial class GameForm : Form
    {
        MainMenuForm mainmenu;

        enum GameState { RUNNING, VICTORY, LOSE, RESET }

        int score = 0;
        int torpedoAmmo = 20;
        int level = 1; // factor in for number of enemies
        int maxEnemies;
        int ticksSinceStart = 0;

        bool victory = false;
        bool lose = false;

        List<Enemy> enemies = new List<Enemy>();
        Hero hero;
        Torpedo torpedo = null;
        Random rand = new Random();
        

        public GameForm(MainMenuForm mainmenu)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.mainmenu = mainmenu;
            this.hero = new Hero();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            // set hero in middle
            hero.X = this.Width / 2;
            // at y = 444 for some padding
            hero.Y = 444;

            if (enemies.Count > 0)
            {
                enemies.Clear();
            }

            this.maxEnemies = rand.Next(6, (level * 2) + 6);

            // start enemy spawn at   y = 110
            //                  x = 50
            // end enemy spawn before y = 300
            //                  x = 703
            // have padding between enemies (10 px)
            for (int i = 0; i < maxEnemies; i++)
            {
                int x = rand.Next(50, 704);
                int y = rand.Next(110, 200);
                int w = rand.Next(10, 31);
                int h = rand.Next(10, 31);

                int value = ((h < 20 && w < 20) || h > w + 5) ? 2 : 1; // generate value based on size of enemy

                if (SpaceOccupied(x, y) == null)
                {
                    enemies.Add(new Enemy(x, y, w, h, value));
                }
            }
        }

        private Enemy SpaceOccupied(int x, int y)
        {
            foreach (Enemy enemy in enemies)
            {
                if (
                    ((x >= enemy.X && x <= enemy.X + enemy.Width) &&
                    (y <= enemy.Y + enemy.Height))
                )
                {
                    return enemy;
                }
            }
            return null;
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            this.UpdateScore(score);

            if (GetGameState() == GameState.LOSE)
            {
                Lose();
                return;
            }

            this.UpdateEnemies();
            this.UpdateTorpedo();
            this.Refresh();
            this.ticksSinceStart++;
            this.LevelCount.Text = "Level: " + level;

            if (enemies.Count == 0)
            {
                SetGameState(GameState.VICTORY, sender, e);
            }

        }

        private GameState GetGameState()
        {
            if (lose)
            {
                return GameState.LOSE;
            }
            if (victory)
            {
                return GameState.VICTORY;
            }

            return GameState.RUNNING;
        }

        private void SetGameState(GameState state, object sender, EventArgs e)
        {
            switch (state)
            {
                case GameState.VICTORY:
                    Victory();
                    break;
                case GameState.RESET:
                    Reset(sender, e);
                    break;
                case GameState.LOSE:
                    Lose();
                    break;
            }
        }

        public void Reset(object sender, EventArgs e)
        {
            if (!victory)
            {
                this.score = 0;
            }
            this.ticksSinceStart = 0;
            YouWin.Visible = false;
            YouLose.Visible = false;
            FinalScore.Visible = false;
            Username.Enabled = false;
            Username.Visible = false;
            Continue.Enabled = false;
            Continue.Visible = false;
            UsernameLabel.Visible = false;
            UsernameLabel2.Visible = false;
            this.victory = false;
            this.lose = false;

            GameForm_Load(sender, e);
        }


        // TODO: refactor
        private void Lose()
        {
            if (!victory)
            {
                this.ticksSinceStart = 0;
                FinalScore.Text = "Score: " + score;
                YouLose.Visible = true;
                FinalScore.Visible = true;
                if (score > 0)
                {
                    Username.Enabled = true;
                    Username.Visible = true;
                    UsernameLabel.Visible = true;
                    UsernameLabel2.Visible = true;
                }
                this.lose = true;
            }
        }

        // TODO: refactor
        private void Victory()
        {
            if (!victory)
            {
                this.ticksSinceStart = 0;
                FinalScore.Text = "Score: " + score;
                YouWin.Visible = true;
                FinalScore.Visible = true;
                Username.Enabled = true;
                Username.Visible = true;
                Continue.Enabled = true;
                Continue.Visible = true;
                UsernameLabel.Visible = true;
                UsernameLabel2.Visible = true;
                this.victory = true;
                level++;
            }

            return;
        }

        private void UpdateTorpedo()
        {
            if (torpedo != null)
            {
                torpedo.Y = torpedo.Y - torpedo.speed;
            }
        }

        private void UpdateEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                if (ticksSinceStart % (100 - (level * 2)) == 1)
                {
                    enemy.Y += enemy.TravelDistance;

                    if (enemy.Y > hero.Y)
                    {
                        this.lose = true;
                    }
                }

            }
        }

        private void FireTorpedo()
        {
            if (torpedo == null && torpedoAmmo > 0)
            {
                torpedo = new Torpedo();
                torpedo.X = hero.X + 2;
                torpedo.Y = hero.Y;
            }
        }

        // Helper for å oppdatere score in game
        private void UpdateScore(int newScore)
        {
            label1.Text = score + " pts";
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
            PaintTorpedo(e.Graphics);
        }

        private void PaintTorpedo(Graphics g)
        {
            if (torpedo != null)
            {
                SolidBrush b = new SolidBrush(Color.White);
                g.FillRectangle(b, torpedo.X, torpedo.Y, 5, 5);

                Enemy collidedWith = SpaceOccupied(torpedo.X, torpedo.Y);
                if (collidedWith != null)
                {
                    torpedo = null;
                    enemies.Remove(collidedWith);
                    score += collidedWith.Value;
                }
            }

            if (torpedo != null && torpedo.Y < 1)
            {
                torpedo = null;
            }

        }

        private void PaintHero(Graphics g)
        {
            SolidBrush b = new SolidBrush(Color.White);
            g.FillRectangle(b, hero.X + 5, hero.Y + 5, 5, 5);
            g.FillRectangle(b, hero.X, hero.Y, 10, 10);
        }

        private void PaintEnemies(Graphics g)
        {
            SolidBrush b = new SolidBrush(Color.White);
            foreach (Enemy enemy in enemies)
            {
                g.FillRectangle(b, enemy.X, enemy.Y, enemy.Width, enemy.Height);
            }
        }

        private void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            this.hero.X = e.X;
        }

        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            FireTorpedo();
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            SetGameState(GameState.RESET, sender, e);
        }

        private void Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (sender is TextBox)
                {
                    TextBox input = (TextBox)sender;
                    string text = input.Text;
                    if (text.Length == 3)
                    {
                        HighscoreHelper highscoreHelper = new HighscoreHelper();
                        highscoreHelper.AddHighscore(text.ToUpper(), this.score);
                        input.Visible = false;
                        input.Enabled = false;
                    }
                }

            }
        }

    }
}
