using System;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

namespace DungeonShambles
{

    public class TextureImporter
    {
        // a reference to the texture to pass between the methods
        private int texture;
        // used for text rendering
        private Graphics gfx;
        // a bitmap for the texture
        private Bitmap tex;

        public TextureImporter() { }

        public void importTexture(String name)
        {
            tex = new Bitmap(name);
            this.genTexture();
        }

        private void genTexture()
        {
            GL.GenTextures(1, out texture);
            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            tex.MakeTransparent(Color.FromArgb(255, 0, 222));

            BitmapData data = tex.LockBits(new System.Drawing.Rectangle(0, 0, tex.Width, tex.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            tex.UnlockBits(data);
        }

        public void removeTexture()
        {
            GL.DeleteTextures(1, ref texture);
        }

        public void renderTexture(float size, float x, float y)
        {
            GL.BindTexture(TextureTarget.Texture2D, texture);

            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(x + size * -1, y + size * -1);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(x + size, y + size * -1);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(x + size, y + size);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(x + size * -1, y + size);

            GL.End();
        }

        public void drawText(String text, Font font, Brush color)
        {
            tex = new Bitmap(Globals.WindowWidth, Globals.WindowHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            gfx = Graphics.FromImage(tex);
            gfx.Clear(Color.Transparent);
            gfx.DrawString(text, font, color, PointF.Empty);
            genTexture();
        }

	}
}

