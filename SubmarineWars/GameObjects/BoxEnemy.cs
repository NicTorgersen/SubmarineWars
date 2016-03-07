using SubmarineWars.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineWars
{
    public class BoxEnemy : Enemy
    {
        public BoxEnemy(int x, int y, int width = 10, int height = 10, int value = 1, int speed = 30) : base(x, y, width, height, value, speed)
        {
            // todo:
        }
    }
}
