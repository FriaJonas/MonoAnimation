using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoAnimation.Lib;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MonoAnimation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D _background;

        Texture2D _fighter;
        Sprite Player;

        Texture2D _ball;
        Sprite RandomBall;

        //Listan som kommer innehålla alla sprites
        List<Sprite> _sprites { get; set; }=new List<Sprite>();


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;// GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = 550;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _fighter = Content.Load<Texture2D>("sprite");
            _ball = Content.Load<Texture2D>("ball");
            _background = Content.Load <Texture2D>("bg");
            Player = new Fighter(_fighter);
            _sprites.Add(Player);

            for(int i=0;i<5;i++)
            {
                RandomBall = new Ball(_ball);
                _sprites.Add(RandomBall);
            }
            

            // TODO: use this.Content to load your game content here

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here      
            _sprites.ForEach(e=>e.Update());
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);
            _sprites.ForEach(e => e.Draw(_spriteBatch));
            _spriteBatch.End();
            base.Draw(gameTime);

            
        }
    }

}