using System;
using OpenTK.Graphics.OpenGL;
using DungeonShambles.Entities;

namespace DungeonShambles.UI
{
    public class HUD
    {
        GameEntities mainChar;

        public HUD(GameEntities main)
        {
            mainChar = main;
        }

        public void drawHUD(float value)
        {
            GL.Begin(PrimitiveType.Quads);
            //GL.Color3(255, 255, 255);
            GL.Vertex2(mainChar.getX() + 0.5, mainChar.getY() + 0.9);
            GL.Vertex2(mainChar.getX() + 0.9 - value, mainChar.getY() + 0.9);
            GL.Vertex2(mainChar.getX() + 0.9 - value, mainChar.getY() + 0.95);
            GL.Vertex2(mainChar.getX() + 0.5,mainChar.getY() + 0.95);
            GL.End();
        }
    }
}
