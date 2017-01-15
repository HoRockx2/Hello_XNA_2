using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Hello_XNA.Tool;

namespace Hello_XNA
{
    class Zaku
    {
		private SpriteBatch m_SpriteBatch;
        private Texture2D m_ImgResource;
        private Vector2 m_Position;
        private int m_FrameNumber;
        private int m_Frame;
        private float m_TimePerFrame;
        private float m_TotalElapsed;

        public Vector2 VECTOR
		{
            get
            {
                return m_Position;
            }
		}

		public Zaku(SpriteBatch spriteBatch, ContentManager baseContent)
		{
            m_SpriteBatch = spriteBatch;
            m_ImgResource = baseContent.Load<Texture2D>("zaku_anim");

            m_FrameNumber = 4;
            m_Frame = 0;
            m_TimePerFrame = (float)1/(float)(1.5);
            m_TotalElapsed = 0;
		}

        public void Draw(Vector2 drawPosition)
        {
            m_Position = drawPosition;

            int frameWidth = m_ImgResource.Width / m_FrameNumber;
            Rectangle drawRect = new Rectangle(frameWidth * m_Frame, 0, frameWidth, m_ImgResource.Height);

            m_SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
//            m_SpriteBatch.Draw(m_ImgResource, drawPosition, drawRect, Color.White);
            m_SpriteBatch.Draw(m_ImgResource, drawPosition, Vector2.Zero, 0f);
            m_SpriteBatch.End();
        }

        public void UpdateFrame(float elapsed)
        {
            m_TotalElapsed += elapsed;

            if (m_TotalElapsed >= m_TimePerFrame)
            {
                m_Frame++;
                m_Frame %= m_FrameNumber;
                m_TotalElapsed -= m_TimePerFrame;
            }
        }
    }
}
