using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using DungeonShambles.Entities;

namespace DungeonShambles.UI
{
    public class WinScreen
    {
        TextureImporter bkgImg, y, o, u, w, o2, n, blah, content, controls;
        GameEntities mainChar;
        Font titleFont = new Font(FontFamily.GenericSerif, 35);
        Font contentFont = new Font(FontFamily.GenericSerif, 25);
        Font controlsFont = new Font(FontFamily.GenericSerif, 20);
        Brush titleBrush = Brushes.DarkTurquoise;
        Brush contentBrush = Brushes.Purple;
        Brush controlsBrush = Brushes.LightSeaGreen;

        string winning = "Wow... What a crazy dream!";
        string titleStr = "YOU WON!";

        public WinScreen(GameEntities main)
        {
            mainChar = main;
            bkgImg = new TextureImporter();
            y = new TextureImporter();
            o = new TextureImporter();
            u = new TextureImporter();
            w = new TextureImporter();
            o2 = new TextureImporter();
            n = new TextureImporter();
            blah = new TextureImporter();
            content = new TextureImporter();
            controls = new TextureImporter();

            bkgImg.importTexture("Images/endPic.jpg");
            y.drawText("Y", titleFont, Brushes.Red);
            o.drawText("O", titleFont, Brushes.Coral);
            u.drawText("U", titleFont, Brushes.Yellow);
            w.drawText("W", titleFont, Brushes.Green);
            o2.drawText("O", titleFont, Brushes.Blue);
            n.drawText("N", titleFont, Brushes.DarkViolet);
            blah.drawText("!", titleFont, Brushes.Gold);
            content.drawText(winning, contentFont, contentBrush);
            controls.drawText("Start Over? Y / N", controlsFont, controlsBrush);
        }


        public void renderMenu()
        {
            bkgImg.renderTexture(1, mainChar.getX(), mainChar.getY());
            GL.Enable(EnableCap.Blend);
            y.renderTexture(1, mainChar.getX() + 0.32f, mainChar.getY() - 0.62f);
            o.renderTexture(1, mainChar.getX() + 0.5f, mainChar.getY() - 0.45f);
            u.renderTexture(1, mainChar.getX() + 0.7f, mainChar.getY() - 0.35f);
            w.renderTexture(1, mainChar.getX() + 1.0f, mainChar.getY() - 0.32f);
            o2.renderTexture(1, mainChar.getX() + 1.2f, mainChar.getY() - 0.37f);
            n.renderTexture(1, mainChar.getX() + 1.4f, mainChar.getY() - 0.47f);
            blah.renderTexture(1, mainChar.getX() + 1.55f, mainChar.getY() - 0.6f);
            content.renderTexture(1, mainChar.getX() + 0.5f, mainChar.getY() - 1.0f);
            controls.renderTexture(1, mainChar.getX() + 1.4f, mainChar.getY() - 1.8f);
            GL.Disable(EnableCap.Blend);
        }
    }
}
