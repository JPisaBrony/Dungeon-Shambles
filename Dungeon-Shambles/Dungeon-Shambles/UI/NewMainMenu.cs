using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using DungeonShambles.Entities;

namespace DungeonShambles
{
    public class NewMainMenu
    {
        TextureImporter backgroundImage, newgame, newgameHighlight, quitgame, quitgameHighlight, title, controls;
        GameEntities mainChar;
        Font buttonFont = new Font(FontFamily.GenericSerif, 25);
        //Font font2 = new Font("UI/Fonts/ModerneFraktur.ttf", 35);
        Font titleFont = new Font(FontFamily.GenericSerif, 45);
        Font controlsFont = new Font(FontFamily.GenericSerif, 20);
        Brush brush = Brushes.White;
        Brush brushHighlight = Brushes.Purple;

        public NewMainMenu(GameEntities mainCharacter)
        {
            mainChar = mainCharacter;
            backgroundImage = new TextureImporter();
            newgame = new TextureImporter();
            newgameHighlight = new TextureImporter();
            quitgame = new TextureImporter();
            quitgameHighlight = new TextureImporter();
            title = new TextureImporter();
            controls = new TextureImporter();

            backgroundImage.importTexture("Images/800x60.jpg");
            newgame.drawText("New Game", buttonFont, brush);
            newgameHighlight.drawText("New Game", buttonFont, brushHighlight);
            quitgame.drawText("Quit", buttonFont, brush);
            quitgameHighlight.drawText("Quit", buttonFont, brushHighlight);
            title.drawText("Dungeon Shambles", titleFont, brush);
            controls.drawText("Next  >>", controlsFont, brush);
        }


        public void renderMenu()
        {
            backgroundImage.renderTexture(1, mainChar.getX(), mainChar.getY());
            GL.Enable(EnableCap.Blend);
            title.renderTexture(1, mainChar.getX() + 0.4f, mainChar.getY() - 0.4f);
            if (Globals.countButton == Globals.currentButton)
            {
                newgameHighlight.renderTexture(1, mainChar.getX() + 1.15f, mainChar.getY() - 1.1f);
                quitgame.renderTexture(1, mainChar.getX() + 1.15f, mainChar.getY() - 1.3f);
            }
            else
            {
                newgame.renderTexture(1, mainChar.getX() + 1.15f, mainChar.getY() - 1.1f);
                quitgameHighlight.renderTexture(1, mainChar.getX() + 1.15f, mainChar.getY() - 1.3f);
            }
            controls.renderTexture(1, mainChar.getX() + 1.6f, mainChar.getY() - 1.8f);
            GL.Disable(EnableCap.Blend);
        }

    }
}

