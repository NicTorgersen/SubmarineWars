using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineWars.GameObjects
{
    public class Loot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; protected set; }
        public int Width { get; protected set; }
        public int Speed { get; set; }
        public Weapon Weapon { get; set; }

        public int Ammo { get; set; }

        public Loot(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Speed = 10;
            this.Width = 10;
            this.Height = 6;
            this.Ammo = 2;
            this.Weapon = new Weapon(Weapon.WeaponTypes.THREE_SHOOTER);
        }
    }
}
