using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineWars.GameObjects
{
    public class Enemy
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int TravelDistance { get; set; }
        public int Value { get; set; }

        protected int travelDirection;

        public Enemy(int x, int y, int width = 10, int height = 10, int value = 1, int speed = 30)
        {
            this.Width = width;
            this.Height = height;
            this.X = x;
            this.Y = y;
            this.Value = value;
            this.TravelDistance = speed;
            this.travelDirection = -speed;
        }

        internal void EnemyWobble(int min, int max)
        {
            if (this.X > max) {
                this.travelDirection = -TravelDistance;
            }
            else if (this.X < min)
            {
                this.travelDirection = TravelDistance;
            }

            this.X += travelDirection;
            
        }

        internal static object SpaceHasEnemy(List<Enemy> enemies, int x, int y, int w, int h)
        {
            foreach (Enemy enemy in enemies)
            {
                if (
                    ((x >= enemy.X && x + w <= enemy.X + enemy.Width) &&
                    (y + h <= enemy.Y + enemy.Height))
                )
                {
                    return enemy;
                }
            }

            return null;
        }

        public static List<Enemy> SpawnEnemies(int maxEnemies, Random rand)
        {
            List<Enemy> enemies = new List<Enemy>();

            for (int i = 0; i < maxEnemies; i++)
            {
                int x = rand.Next(50, 704);
                int y = rand.Next(110, 200);
                int w = rand.Next(10, 31);
                int h = rand.Next(10, 31);

                int value = ((h < 20 && w < 20) || h > w + 5) ? 2 : 1; // generate value based on size of enemy

                if (SpaceHasEnemy(enemies, x, y, w, h) == null)
                {
                    enemies.Add(new BoxEnemy(x, y, w, h, value));
                }
            }

            return enemies;
        }
    }
}
