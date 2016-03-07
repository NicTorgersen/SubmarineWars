using SubmarineWars.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineWars
{
    public class Torpedo : Weapon
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int speed = 20;

        public Torpedo(int originX = 0, int originY = 0) : base(WeaponTypes.TORPEDO)
        {
            this.X = originX;
            this.Y = originY;
        }
    }
}
