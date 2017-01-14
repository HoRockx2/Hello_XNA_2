using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Hello_XNA
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteBatch m_SBForAnim;

        Texture2D m_Zaku2Unit;
        Vector2 m_SpritePosition = Vector2.Zero;
        Vector2 m_SpriteSpeed = new Vector2(50.0f, 50.0f);

        AnimatedTexture m_SpriteTexture; 
        Viewport m_ViewPort;
        Vector2 m_ShipPos;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            m_SpriteTexture = new AnimatedTexture(Vector2.Zero, 0, 2.0f, 0.5f);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            m_Zaku2Unit = Content.Load<Texture2D>("zaku2");
            System.Console.WriteLine("load content done");
            
            m_SBForAnim = new SpriteBatch(GraphicsDevice);
            
            m_SpriteTexture.load(Content, "shipAnim", 4, 2);
            m_ViewPort = graphics.GraphicsDevice.Viewport;
            m_ShipPos = new Vector2(m_ViewPort.Width / 2, m_ViewPort.Height / 2 );
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            KeyboardState keyboardState = Keyboard.GetState();
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            m_SpriteTexture.UpdateFrame(elapsed);
            
            UpdateSprite(gameTime);
            base.Update(gameTime);
        }

        private void UpdateSprite(GameTime gameTiem)
        {
            System.Console.WriteLine("");
            m_SpritePosition += m_SpriteSpeed * (float)gameTiem.ElapsedGameTime.TotalSeconds;

            int MaxX = graphics.GraphicsDevice.Viewport.Width - m_Zaku2Unit.Width;
            int MinX = 0;
            int MaxY = graphics.GraphicsDevice.Viewport.Height - m_Zaku2Unit.Height;
            int MinY = 0;

            if (m_SpritePosition.X > MaxX)
            {
                m_SpriteSpeed.X *= -1;
                m_SpritePosition.X = MaxX;
            }

            else if (m_SpritePosition.X < MinX)
            {
                m_SpriteSpeed.X *= -1;
                m_SpritePosition.X = MinX;
            }

            if (m_SpritePosition.Y > MaxY)
            {
                m_SpriteSpeed.Y *= -1;
                m_SpritePosition.Y = MaxY;
            }

            else if (m_SpritePosition.Y < MinY)
            {
                m_SpriteSpeed.Y *= -1;
                m_SpritePosition.Y = MinY;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(m_Zaku2Unit, m_SpritePosition, Color.White);
            spriteBatch.End();

            m_SBForAnim.Begin();
            m_SpriteTexture.DrawFrame(m_SBForAnim, m_ShipPos);
            m_SBForAnim.End();

            base.Draw(gameTime);
        }
    }
}
