﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineWars
{
    public class Enemy
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int TravelDistance { get; set; }

        public int Value { get; set; }

        public Enemy(int x, int y, int width = 10, int height = 10, int value = 1, int speed = 30)
        {
            this.Width = width;
            this.Height = height;
            this.X = x;
            this.Y = y;
            this.Value = value;
            this.TravelDistance = speed;
        }

    }
}