using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubmarineWars.GameObjects
{
    public class Weapon
    {
        public enum WeaponTypes { THREE_SHOOTER }
        public WeaponTypes WeaponType;

        public Weapon(WeaponTypes weaponType)
        {
            this.WeaponType = weaponType;
        }
    }
}
