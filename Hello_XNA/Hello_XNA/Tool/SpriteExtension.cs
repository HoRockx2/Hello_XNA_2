using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Hello_XNA.Tool
{
    public static class SpriteExtension
    {
        public static void Draw(this SpriteBatch sb, Texture2D ImgResource,
            Vector2 drawPositon, Vector2 drawOrigin, float drawDepth)
        {
            //sb.Draw(ImgResource, drawPositon, null, 
            //    Color.White, 0, drawOrigin, 0, SpriteEffects.None, drawDepth);
            sb.Draw(ImgResource, drawPositon, null,
                Color.White, 0, drawOrigin, 1, SpriteEffects.None, drawDepth);

        }

    }
}
