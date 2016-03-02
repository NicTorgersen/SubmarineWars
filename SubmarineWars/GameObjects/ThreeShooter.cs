using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineWars.GameObjects
{
    public class ThreeShooter
    {
        public List<Torpedo> Torpedos = new List<Torpedo>();

        int X { get; set; }
        int Y { get; set; }

        public ThreeShooter(int originX, int originY)
        {
            this.X = originX;
            this.Y = originY;

            for (int i = 0; i < 3; i++)
            {
                Torpedo torpedo = new Torpedo(this.X, this.Y);

                if (i == 0)
                {
                    torpedo.X += 5;
                }
                else if (i == (Torpedos.Count - 1))
                {
                    torpedo.X -= 5;
                }

                Torpedos.Add(torpedo);
            }
        }
    }
}
