using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using DungeonShambles.Entities;

namespace DungeonShambles.UI
{
    public class ControlsMenu
    {
        GameEntities mainChar;
        TextureImporter bkgImage, title, backControl, wasdImage, udlrImage, enterImage, printImage;
        Font titleFont = new Font(FontFamily.GenericSerif, 35);
        Font controlsFont = new Font(FontFamily.GenericSerif, 20);
        Brush titleBrush = Brushes.White;
        //Brush controlsBrush = Brushes.Thistle;

        public ControlsMenu(GameEntities mainCharacter)
        {
            mainChar = mainCharacter;
            bkgImage = new TextureImporter();
            wasdImage = new TextureImporter();
            udlrImage = new TextureImporter();
            enterImage = new TextureImporter();
            printImage = new TextureImporter();
            title = new TextureImporter();
            backControl = new TextureImporter();

            bkgImage.importTexture("Images/dungeon3_fixed.jpg");
            wasdImage.importTexture("Images/WASD.png");
            udlrImage.importTexture("Images/UDLR.png");
            enterImage.importTexture("Images/Enter.png");
            printImage.importTexture("Images/Print & F4.png");
            title.drawText("Options", titleFont, titleBrush);
            backControl.drawText("<<  Back", controlsFont, titleBrush);
        }

        public void renderMenu()
        {
            bkgImage.renderTexture(1, mainChar.getX(), mainChar.getY());
            GL.Enable(EnableCap.Blend);
            title.renderTexture(1, mainChar.getX() + 0.1f, mainChar.getY() - 0.15f);
            wasdImage.renderTexture(0.35f, mainChar.getX() - 0.5f, mainChar.getY() + 0.3f);
            udlrImage.renderTexture(0.35f, mainChar.getX() - 0.5f, mainChar.getY() - 0.4f);
            enterImage.renderTexture(0.30f, mainChar.getX() + 0.5f, mainChar.getY() + 0.3f);
            printImage.renderTexture(0.35f, mainChar.getX() + 0.5f, mainChar.getY() - 0.4f);
            backControl.renderTexture(1, mainChar.getX() + 0.1f, mainChar.getY() - 1.8f);
            GL.Disable(EnableCap.Blend);
        }

    }
}
