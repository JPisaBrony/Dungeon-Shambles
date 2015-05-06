using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using DungeonShambles.Entities;

namespace DungeonShambles.UI
{
    public class EndScreen
    {
        GameEntities mainChar;
        TextureImporter bkgImage, content, controls;
        Font titleFont = new Font(FontFamily.GenericSerif, 35);
        Font contFont = new Font(FontFamily.GenericSerif, 24);
        Font controlsFont = new Font(FontFamily.GenericSerif, 20);
        Brush titleBrush = Brushes.Red;
        Brush contentBrush = Brushes.Purple;

        
        public EndScreen(GameEntities main)
        {
            mainChar = main;
            bkgImage = new TextureImporter();
            content = new TextureImporter();
            controls = new TextureImporter();

            controls.drawText("Start Over? Y / N", controlsFont, Brushes.White);
            bkgImage.importTexture("Images/gameOver.jpg");
            content.drawText("Looks like dreams don't come true...", contFont, contentBrush);
        }

        public void renderMenu()
        {
            bkgImage.renderTexture(1, mainChar.getX(), mainChar.getY());
            GL.Enable(EnableCap.Blend);
            content.renderTexture(1, mainChar.getX() + 0.5f, mainChar.getY() - 1.0f);
            controls.renderTexture(1, mainChar.getX() + 1.4f, mainChar.getY() - 1.8f);
            GL.Disable(EnableCap.Blend);
        }
        
        

    }
}
