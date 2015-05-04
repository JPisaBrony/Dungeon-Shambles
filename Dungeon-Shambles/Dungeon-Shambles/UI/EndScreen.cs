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
        Font contFont = new Font(FontFamily.GenericSerif, 14);
        Font controlsFont = new Font(FontFamily.GenericSerif, 20);
        Brush titleBrush = Brushes.Red;

        
        public EndScreen(GameEntities main)
        {
            mainChar = main;
            bkgImage = new TextureImporter();
            content = new TextureImporter();
            controls = new TextureImporter();

            controls.drawText("Start Over?", controlsFont, Brushes.White);

            
        }
        
        

    }
}
