using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakout01
{
    internal class AudioManager
    {
        private SoundEffect _soundEffect;

        public AudioManager(ContentManager contentManager)
        {
            _soundEffect = contentManager.Load<SoundEffect>("Audio/click");
        }

        public void AudioHitPaddle()
        {
            _soundEffect.Play(1, -1, 0);
        }

        public void AudioHitBlock()
        {
            _soundEffect.Play(1, 0, 0);
        }

        public void AudioHitWall()
        {
            _soundEffect.Play(1, 1, 0);
        }
    }
}
