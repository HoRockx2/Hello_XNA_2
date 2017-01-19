#region defultNamespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

#region customNamespace
using Hello_XNA.Tool;
using DebugLogger;
#endregion

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

        private SpriteFont m_Font;
        private Vector2 m_TextPosition;

        private string m_strName;

        private Rectangle m_ThisUnitArea;

        private Color m_UnitColor;

        #region property
        public Rectangle UNIT_AREA
        {
            get
            {
                return m_ThisUnitArea;
            }
        }
        public Vector2 VECTOR
		{
            get
            {
                return m_Position;
            }
		}
        #endregion

        public Zaku(SpriteBatch spriteBatch, ContentManager baseContent, string zakuName)
		{
            m_SpriteBatch = spriteBatch;
            m_ImgResource = baseContent.Load<Texture2D>("zaku_anim");

            m_FrameNumber = 4;
            m_Frame = 0;
            m_TimePerFrame = (float)1/(float)(1.5);
            m_TotalElapsed = 0;

            m_Font = baseContent.Load<SpriteFont>("BasicFont");

            m_strName = zakuName;

            m_UnitColor = Color.White;
		}

        public bool CheckClicked(Point clickedPoint)
        {
            CDebugLogger.DEBUG_LOG("");

            bool bRet = false;
            if (m_ThisUnitArea.Contains(clickedPoint))
            {
                CDebugLogger.DEBUG_LOG("clicked");
                m_UnitColor = Color.Red;
                bRet = true;
            }
            else
            {
                CDebugLogger.DEBUG_LOG("no clicked");
                m_UnitColor = Color.White;
            }

            return bRet;
        }

        public void Draw(Vector2 drawPosition)
        {
            m_Position = drawPosition;
            m_TextPosition = new Vector2(m_Position.X, m_Position.Y + m_ImgResource.Height);

            int frameWidth = m_ImgResource.Width / m_FrameNumber;
            Rectangle drawRect = new Rectangle(frameWidth * m_Frame, 0, frameWidth, m_ImgResource.Height);

            

            m_SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            m_SpriteBatch.Draw(m_ImgResource, drawPosition, drawRect, m_UnitColor);
            m_SpriteBatch.DrawString(m_Font, m_strName, m_TextPosition, Color.Red);
            //m_SpriteBatch.Draw(m_ImgResource, drawPosition, Vector2.Zero, 0f);
            m_SpriteBatch.End();

            m_ThisUnitArea = new Rectangle((int)m_Position.X, (int)m_Position.Y, drawRect.Width, drawRect.Height);
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
