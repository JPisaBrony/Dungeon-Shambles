using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using QuickFont;
using System.Drawing;

namespace DungeonShambles.UI
{
    class Stats
    {
       // variables
        QFont header, testText;
        String testString;
        string title = "Your Stats";

        TextureImporter text1;


        public Stats()
        {
            header = new QFont("UI/Fonts/ModerneFraktur.ttf", 35);
            header.Options.Colour = new Color4(0.3f, 0.5f, 0.4f, 1.0f);
            header.Options.DropShadowActive = true;

            text1 = new TextureImporter();
            text1.importTexture("Images/dungeon3_fixed.jpg");
        }


        public void RenderMenu()
        {
            // clear color and depth buffer
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
            GL.LoadIdentity();

            GL.ClearColor(0.0f, 0.0f, 0.0f, 0f);

            float yOffset = 20;

            text1.renderTexture(1.0f, 0f, 0f);

            QFont.Begin();
                // push current matrix stack
                GL.PushMatrix();
                GL.Translate(Globals.WindowWidth * 0.4f, yOffset, 0f);
                header.Print(title, QFontAlignment.Right);
                GL.PopMatrix();

                yOffset += 100;

            QFont.End();

            GL.Disable(EnableCap.Texture2D);

        }
    }
}
