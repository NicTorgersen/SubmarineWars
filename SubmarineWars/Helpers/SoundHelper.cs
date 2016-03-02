using SubmarineWars.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace SubmarineWars.Helpers
{
    public class SoundHelper
    {
        SoundPlayer player = new SoundPlayer();
        bool isMuted = false;

        public SoundHelper(bool mute = false)
        {
            this.isMuted = mute;
        }
        public void SetIsMuted(bool mute)
        {
            this.isMuted = mute;
        }
        public bool GetIsMuted()
        {
            return this.isMuted;
        }
        public void PlayNewWeaponSound()
        {
            if (!this.isMuted)
            {
                player.Stream = Properties.Resources.new_weapon;
                player.Play();
            }
        }
        public void PlayWinSound()
        {
            if (!this.isMuted)
            {
                player.Stream = Properties.Resources.win;
                player.Play();
            }
        }
        public void PlayFireSound()
        {
            if (!this.isMuted)
            {
                player.Stream = Properties.Resources.shoot_torpedo;
                player.Play();
            }
        }

        public void PlayEnemyDeathSound()
        {
            if (!this.isMuted)
            {
                player.Stream = Properties.Resources.enemy_explode;
                player.Play();
            }
        }

        public void PlayLoseSound()
        {
            if (!this.isMuted)
            {
                player.Stream = Properties.Resources.lose;
                player.Play();
            }
        }

        public void PlayExtraSound()
        {
            if (!this.isMuted)
            {
                player.Stream = Properties.Resources.extra;
                player.Play();
            }
        }
    }
}
