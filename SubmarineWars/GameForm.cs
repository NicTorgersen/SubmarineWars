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
using SubmarineWars.Helpers;
using SubmarineWars.GameObjects;

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
        int preferredTickrate = 60;
        const int fallConst = 20;

        bool victory = false;
        bool lose = false;

        List<Enemy> enemies = new List<Enemy>();
        List<Loot> loot = new List<Loot>();
        Hero hero;
        Torpedo torpedo = null;
        ThreeShooter threeShooter = null;
        Random rand = new Random();
        SoundHelper sound = new SoundHelper();

        public GameForm(MainMenuForm mainmenu)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.mainmenu = mainmenu;
            this.hero = new Hero();
            GameLoop.Interval = 1000 / preferredTickrate; // 60 fps
            this.Focus();
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

            // start enemy spawn at     y = 110
            //                          x = 50
            // end enemy spawn before   y = 300
            //                          x = 703
            // have padding between enemies (10 px)
            SpawnEnemies();
        }

        private Enemy SpaceHasEnemy(int x, int y)
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

        private Hero SpaceHasHero(int x, int y)
        {
            if ((x >= hero.X && x <= hero.X + hero.Width) &&
                (y <= hero.Y + hero.Height))
            {
                return hero;
            }

            return null;
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {

            if (GetGameState() == GameState.LOSE)
            {
                Lose();
                return;
            }

            this.UpdateScore(score);
            this.UpdateEnemies();
            this.UpdateTorpedo();
            this.UpdateThreeShooter();
            this.UpdateLoot();
            this.ticksSinceStart++;
            this.LevelCount.Text = "Level: " + level;
            this.Refresh();

            if (enemies.Count == 0)
            {
                SetGameState(GameState.VICTORY, sender, e);
                return;
            }

            // random events
            if (ticksSinceStart % preferredTickrate == 1)
            {
                return;
            }

        }

        private void SpawnEnemies()
        {
            for (int i = 0; i < maxEnemies; i++)
            {
                int x = rand.Next(50, 704);
                int y = rand.Next(110, 200);
                int w = rand.Next(10, 31);
                int h = rand.Next(10, 31);

                int value = ((h < 20 && w < 20) || h > w + 5) ? 2 : 1; // generate value based on size of enemy

                if (SpaceHasEnemy(x, y) == null)
                {
                    enemies.Add(new Enemy(x, y, w, h, value));
                }
            }
        }

        private void SpawnLoot(int x = -1, int y = -1)
        {
            int lootX = rand.Next(50, 704);
            int lootY = rand.Next(110, 301);

            if (x != -1 && y != -1)
            {
                lootX = x;
                lootY = y;
            }
            
            loot.Add(new Loot(lootX, lootY));
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
                    sound.PlayExtraSound();
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

                sound.PlayWinSound();
            }

            return;
        }

        private void UpdateTorpedo()
        {
            if (torpedo != null)
            {
                torpedo.Y = torpedo.Y - torpedo.speed;

                if (torpedo.Y < 1)
                {
                    torpedo = null;
                    return;
                }

                Enemy collidedWith = SpaceHasEnemy(torpedo.X, torpedo.Y);

                if (collidedWith != null)
                {
                    torpedo = null;
                    enemies.Remove(collidedWith);
                    score += collidedWith.Value;
                    sound.PlayEnemyDeathSound();

                    if (rand.Next(1, 21) == rand.Next(1, 21))
                    {
                        SpawnLoot(collidedWith.X, collidedWith.Y);
                    }
                }
            }
        }
        private void UpdateThreeShooter()
        {
            if (threeShooter != null)
            {
                // if a threeshooter hits someone,
                // contemplate if it's smarter to replace the value
                // in the list with a null value

                for (int i = 0; i < threeShooter.Torpedos.Count; i++)
                {
                    if (threeShooter.Torpedos[i] == null) {
                        continue;
                    }

                    threeShooter.Torpedos[i].Y -= threeShooter.Torpedos[i].speed;

                    if (i == 0)
                    {
                        threeShooter.Torpedos[i].X += threeShooter.Torpedos[i].speed;
                    }
                    else if (i == (threeShooter.Torpedos.Count - 1))
                    {
                        Console.WriteLine(threeShooter.Torpedos.Count.ToString());

                        threeShooter.Torpedos[i].X -= threeShooter.Torpedos[i].speed;
                    }

                    if (threeShooter.Torpedos[i].Y < 1)
                    {
                        threeShooter = null;
                        return;
                    }

                    Enemy collidedWith = SpaceHasEnemy(threeShooter.Torpedos[i].X, threeShooter.Torpedos[i].Y);

                    if (collidedWith != null)
                    {
                        threeShooter.Torpedos.Insert(i, null);
                        enemies.Remove(collidedWith);
                        score += collidedWith.Value;
                        sound.PlayEnemyDeathSound();
                    }
                }
            }
        }

        private void UpdateEnemies()
        {
            int timeCalc = preferredTickrate - (level * 2);

            if (timeCalc < 1) timeCalc = 1;

            if (ticksSinceStart % timeCalc == 1)
            {
                foreach (Enemy enemy in enemies)
                {
                    if (level >= 5) {
                        enemy.EnemyWobble(50, 703);
                    }

                    enemy.Y += enemy.TravelDistance;

                    if (enemy.Y > hero.Y)
                    {
                        this.lose = true;
                    }
                }
            }
        }

        private void UpdateLoot()
        {
            foreach (Loot lootBox in loot.ToList())
            {
                lootBox.Y += 1;

                Hero collidedWith = SpaceHasHero(lootBox.X, lootBox.Y);
                if (collidedWith != null)
                {
                    this.hero.AddWeapon(lootBox.Weapon, lootBox.Ammo);
                    this.loot.Remove(lootBox);
                    sound.PlayNewWeaponSound();
                }
            }
        }

        private void FireTorpedo()
        {
            if (torpedo == null && torpedoAmmo > 0)
            {
                torpedo = new Torpedo();
                torpedo.X = hero.X + 5;
                torpedo.Y = hero.Y;
                sound.PlayFireSound();
            }
        }

        private void FireThreeShooter()
        {
            if (
                threeShooter == null 
                && hero.HasAmmo(Weapon.WeaponTypes.THREE_SHOOTER)
                )
            {
                threeShooter = new ThreeShooter(this.hero.X, this.hero.Y - 2);
                hero.SubtractAmmo(Weapon.WeaponTypes.THREE_SHOOTER);
            }
        }

        // Helper for å oppdatere score in game
        private void UpdateScore(int newScore)
        {
            label1.Text = score + " pts";
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            PaintHero(e.Graphics);
            PaintEnemies(e.Graphics);
            PaintTorpedo(e.Graphics);
            PaintLootBoxes(e.Graphics);
        }

        private void PaintTorpedo(Graphics g)
        {
            if (torpedo != null)
            {
                SolidBrush b = new SolidBrush(Color.White);
                g.FillRectangle(b, torpedo.X, torpedo.Y, 5, 5);
            }

            if (threeShooter != null)
            {
                SolidBrush b = new SolidBrush(Color.White);
                foreach (Torpedo t in threeShooter.Torpedos)
                {
                    if (t != null) g.FillRectangle(b, t.X, t.Y, 5, 5);
                }
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

        private void PaintLootBoxes(Graphics g)
        {
            SolidBrush b = new SolidBrush(Color.Gold);

            foreach (Loot lootBox in loot)
            {
                g.FillRectangle(b, lootBox.X, lootBox.Y, lootBox.Width, lootBox.Height);
            }
        }

        private void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            this.hero.X = e.X;
        }

        // Continue knapp
        private void Continue_Click(object sender, EventArgs e)
        {
            SetGameState(GameState.RESET, sender, e);
        }

        // Museklikk
        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                FireThreeShooter();
            }
            else
            {
                FireTorpedo();
            }
        }

        // Når enter trykkes i Highscore input
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

        // Mute button
        private void button2_Click(object sender, EventArgs e)
        {
            sound.SetIsMuted(!sound.GetIsMuted());
        }

        // Avslutt
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            mainmenu.Show();
        }

    }
}
