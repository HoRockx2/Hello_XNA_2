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

using Hello_XNA.Tool;
using DebugLogger;

namespace Hello_XNA
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        Zaku m_Zaku;
        Zaku m_Zaku2;

        Texture2D m_BackgroundImg;
        SpriteBatch m_SpriteBatch;

//        List<Rectangle> m_UnitsArea = new List<Rectangle>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            m_SpriteBatch = new SpriteBatch(GraphicsDevice);
            m_BackgroundImg = Content.Load<Texture2D>("starfield");

            m_Zaku = new Zaku(m_SpriteBatch, Content, "Zaku 1");
            m_Zaku2 = new Zaku(m_SpriteBatch, Content, "Zaku 2");

            CDebugLogger.DEBUG_LOG("LoadContent is Done");
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
            MouseState ms =  Mouse.GetState();

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.Escape))
                this.Exit();
            if (ms.LeftButton == ButtonState.Pressed)
            {
                CheckClicked(new Point(ms.X, ms.Y));
            }

            // TODO: Add your update logic here
            m_Zaku.UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
//            m_UnitsArea.Clear();
            // TODO: Add your drawing code here
            Vector2 position = new Vector2(50, 50);

            m_SpriteBatch.Begin();
            m_SpriteBatch.Draw(m_BackgroundImg, Vector2.Zero, Vector2.Zero, 0.9f);
            m_SpriteBatch.End();

            m_Zaku.Draw(Vector2.Zero);
            m_Zaku2.Draw(position);

            base.Draw(gameTime);
        }

        private void CheckClicked(Point clickedPoint)
        {
            m_Zaku.CheckClicked(clickedPoint);
            m_Zaku2.CheckClicked(clickedPoint);
        }
    }
}
