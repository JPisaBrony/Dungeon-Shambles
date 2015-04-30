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
            float yOffset = 20;

            text1.renderTexture(1.0f, 0f, 0f);

            QFont.Begin();
			header.Print(title, QFontAlignment.Right);
			yOffset += 100;
            QFont.End();
        }
    }
}
