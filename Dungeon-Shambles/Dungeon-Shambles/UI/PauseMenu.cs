using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using DungeonShambles.Entities;

namespace DungeonShambles.UI
{
    public class PauseMenu
    {
        TextureImporter title, resumeGame, bkgImage, quitGame;
        GameEntities mainChar;
        Font titleFont = new Font(FontFamily.GenericSerif, 35); 
        Font buttonFont = new Font(FontFamily.GenericSerif, 25);
        Brush whiteBrush = Brushes.White;
        Brush brush = Brushes.Teal;

        public PauseMenu(GameEntities mainCharacter)
        {
            mainChar = mainCharacter;
            bkgImage = new TextureImporter();
            title = new TextureImporter();
            resumeGame = new TextureImporter();
            quitGame = new TextureImporter();
            bkgImage.importTexture("Images/800x60.jpg");
            title.drawText("The Game is Paused ...", titleFont, whiteBrush);
            resumeGame.drawText("Resume", buttonFont, whiteBrush);
            quitGame.drawText("Quit", buttonFont, whiteBrush);
        }

        public void renderMenu()
        {
            bkgImage.renderTexture(1, mainChar.getX(), mainChar.getY());
            GL.Enable(EnableCap.Blend);
            title.renderTexture(1, mainChar.getX() + 0.5f, mainChar.getY() - 0.2f);
            resumeGame.renderTexture(1, mainChar.getX() + 0.9f, mainChar.getY() - 0.95f);
            quitGame.renderTexture(1, mainChar.getX() + 0.9f, mainChar.getY() - 1.15f);
            GL.Disable(EnableCap.Blend);
        }


    }
}
