using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Hello_XNA
{
    class Zaku
    {
		SpriteBatch m_SpriteBatch;
        Texture2D m_ImgResource;
        Vector2 m_Position;

		public Vector2 VECTOR
		{
            get
            {
                return m_Position;
            }
		}

		public Zaku(GraphicsDevice baseGraphicsDevice, ContentManager baseContent)
		{
            m_SpriteBatch = new SpriteBatch(baseGraphicsDevice);
            m_ImgResource = baseContent.Load<Texture2D>("zaku2");
		}

        public void Draw(Vector2 drawPosition)
        {
            m_Position = drawPosition;

            m_SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            m_SpriteBatch.Draw(m_ImgResource, drawPosition, Color.White);
            m_SpriteBatch.End();
        }

    }
}
