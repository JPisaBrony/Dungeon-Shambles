using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using DungeonShambles.Entities;

namespace DungeonShambles.UI
{
    public class HUD
    {
        GameEntities mainChar;
        TextureImporter hpBar;
        TextureImporter health;
        public double h = (100 % 100) ;

        

        public HUD(GameEntities main)
        {

            mainChar = main;
            hpBar = new TextureImporter();
            health = new TextureImporter();
            hpBar.drawText("HP: ", new Font(FontFamily.GenericSerif, 17), Brushes.Gray);            
        }

        public void drawHUD(double value)
        {
            GL.Enable(EnableCap.Blend);
            hpBar.renderTexture(1, mainChar.getX() + 1.25f, mainChar.getY() - 0.075f);
            GL.Disable(EnableCap.Blend);

            GL.Begin(PrimitiveType.Quads);
            //GL.Color3(255, 255, 255);
            GL.Vertex2(mainChar.getX() + 0.4, mainChar.getY() + 0.85);
            GL.Vertex2(mainChar.getX() + 0.9 - value, mainChar.getY() + 0.85);
            GL.Vertex2(mainChar.getX() + 0.9 - value, mainChar.getY() + 0.95);
            GL.Vertex2(mainChar.getX() + 0.4,mainChar.getY() + 0.95);
            GL.End();
        }
    }
}
