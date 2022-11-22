﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonoAnimation.Lib
{
    public abstract class Sprite
    {
        protected Texture2D Texture { get; set; }
        public SoundEffect Sound { get; set; }
        public Vector2 Position;
        public Vector2 Velocity;
        public virtual Color Color { get; set; } = Color.White;
        public int Speed { get; set; } = 5;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color);
        }

        public abstract void Update();
    }
}
