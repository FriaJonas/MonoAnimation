using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MonoAnimation.Lib
{
    public class Ball : Sprite
    {
        public Ball(Texture2D graphics)
        {
            Texture = graphics;
            Position = new Vector2(100, 100);
            Velocity = new Vector2(5, 5);
         }
        public override void Update()
        {
            //denna funktionen Måste implementeras!!

            //lite random för att få bollarna att få olika fart och riktning
            Random random= new Random();
            int ranx = random.Next(-3, 3);
            int rany = random.Next(-3, 3);
            
            //Ökar på positionen med Velocity (riktning / hastighet)
            //Det går att lägga ihop 2st vektorer
            Position += Velocity;
            
            //vi ändrar positionen och vänder håll om vi kommer mot en vägg
            if (Position.Y <= 0)
            {
                Velocity.Y = Speed+rany;
            }
            if (Position.Y >= 430)
            {
                Velocity.Y= -Speed + rany;
            }
            if(Position.X<=0)
            {
                Velocity.X = Speed + ranx;
            }
            if (Position.X >= 730)
            {
                Velocity.X= -Speed + ranx;
            }
        }
    }
}
