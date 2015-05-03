using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using DungeonShambles.Entities;

namespace DungeonShambles.UI
{
    public class StoryMenu
    {
        TextureImporter title, description, bkgImage, steveImage, controls;
        GameEntities mainChar;
        Font titleFont = new Font(FontFamily.GenericSerif, 35);
        Font contentFont = new Font(FontFamily.GenericSerif, 13);
        Font controlsFont = new Font(FontFamily.GenericSerif, 20);
        Brush contentBrush = Brushes.Teal;
        Brush textBrush = Brushes.White;

        string steveDesription = "He is a hot, sexy, valiant young man who is ready for anything the world throws at him." + Environment.NewLine + Environment.NewLine +
                        "Steve is also a professional gamer, and one of the top players in the game “Dungeon Crawler 2015”. " + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                        "Because of his fame, Steve regularly sponsors energy drink and snack companies." + Environment.NewLine + Environment.NewLine +
                        "As fate would have it, Steve’s favorite energy drink company, “Brawndo”, decided to hold a promotional " + Environment.NewLine + Environment.NewLine +
                        "gaming marathon for “dungeon Crawler 2015”, with Steve livestreaming a marathon where he attempts " + Environment.NewLine + Environment.NewLine +
                        "to stay awake as long as possible to set a world record score." + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                        "After nearly 3 days of constant play, Steve’s resolve ran out and " + Environment.NewLine + Environment.NewLine +
                        "he fell asleep at the computer.Upon awakening, Steve finds " + Environment.NewLine + Environment.NewLine +
                        "himself in the starting level of “Dungeon Crawler 2015”.";

        public StoryMenu(GameEntities mainCharacter)
        {
            mainChar = mainCharacter;
            bkgImage = new TextureImporter();
            title = new TextureImporter();
            description = new TextureImporter();
            steveImage = new TextureImporter();
            controls = new TextureImporter();

            bkgImage.importTexture("Images/800x60.jpg");
            steveImage.importTexture("meshes/SteveFront.png");
            title.drawText("Story", titleFont, textBrush);
            description.drawText(steveDesription, contentFont, contentBrush);
            controls.drawText("<<  Back", controlsFont, textBrush);
        }

        public void renderMenu()
        {
            bkgImage.renderTexture(1, mainChar.getX(), mainChar.getY());
            GL.Enable(EnableCap.Blend);
            title.renderTexture(1, mainChar.getX() + 0.1f, mainChar.getY() - 0.15f);
            description.renderTexture(1, mainChar.getX() + 0.1f, mainChar.getY() - 0.4f);
            controls.renderTexture(1, mainChar.getX() + 0.1f, mainChar.getY() - 1.8f);
            GL.Disable(EnableCap.Blend);
            steveImage.renderTexture(0.2f, mainChar.getX() + 0.5f, mainChar.getY() - 0.4f);

        }
    }
}
