using SubmarineWars.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineWars
{
    public class Hero
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; protected set; }
        public int Width { get; protected set; }

        private Dictionary<Weapon, int> Weapons = new Dictionary<Weapon, int>();

        public Hero()
        {
            this.Height = 10;
            this.Width = 10;
        }

        public void AddWeapon(Weapon weapon, int ammo)
        {
            if (!this.Weapons.ContainsKey(weapon))
            {
                this.Weapons.Add(weapon, ammo);
            }
            else
            {
                this.Weapons[weapon] += ammo;
            }
        }

        public bool HasAmmo(Weapon.WeaponTypes weaponType)
        {
            foreach(KeyValuePair<Weapon, int> w in this.Weapons)
            {
                if (w.Key.WeaponType == weaponType && w.Value > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public int GetAmmo(Weapon.WeaponTypes weaponType)
        {
            foreach (KeyValuePair<Weapon, int> w in this.Weapons)
            {
                if (w.Key.WeaponType == weaponType && w.Value > 0)
                {
                    return w.Value;
                }
            }

            return 0;
        }
    }
}
