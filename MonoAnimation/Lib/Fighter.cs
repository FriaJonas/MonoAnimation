using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonoAnimation.Lib
{
    public class Fighter:Sprite
    {

        Dictionary<string, Rectangle> SpritePos =new Dictionary<string, Rectangle>();

        //int som bestämmer vilken bild Right0, Right1, Right2
        int step = 0;

        //int som bestämmer delay innan bildbyte
        int delay = 0;

        public Fighter(Texture2D graphics) 
        {
            Texture = graphics;
            Position = new Vector2(300, 300);
            SpritePos.Add("Right0", new Rectangle(10, 11, 85, 105));
            SpritePos.Add("Right1", new Rectangle(160, 11, 85, 105));
            SpritePos.Add("Right2", new Rectangle(304, 11, 85, 105));
            SpritePos.Add("Left0", new Rectangle(10, 120, 85, 105));
            SpritePos.Add("Left1", new Rectangle(153, 123, 85, 105));
            SpritePos.Add("Left2", new Rectangle(305, 121, 85, 105));

        }
        public override void Update()
        {
            KeyboardState ks = Keyboard.GetState();
            //Kollar om bildstep är 2 och sätt bild till 0
            if (step == 2)
            {
                step = 0;
            }
            //Om delay <5 börja om
            if (delay < 0)
            {
                delay = 5;
            }
            if (ks.IsKeyDown(Keys.Left))
            {

                Speed = - 5;
                if (delay == 0)
                {
                    //Byt bara bild när delay är 0
                    step += 1;
                }
                delay--;
            }
            else if(ks.IsKeyDown(Keys.Right))
            {
                Speed = 5;
                if (delay == 0){
                    step += 1;
                }
                delay--;
            }
            else
            {
                Speed = 0;
            }
            Position.X += Speed;
         
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Speed < 0)
            {
                spriteBatch.Draw(Texture, Position, SpritePos["Left" + step], Color.White);
            }
            else if (Speed > 0)
            {
                spriteBatch.Draw(Texture, Position, SpritePos["Right" + step], Color.White);
            }
            else
            {
                spriteBatch.Draw(Texture, Position, SpritePos["Left" + step], Color.White);
            }
        }
    }
}
