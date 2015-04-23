using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles
{
    public class Door
    {
        private TextureImporter door = new TextureImporter();
        private float x, y;
        
        public Door(float xPos, float yPos)
        {
            door.importTexture("meshes/door.png");
            x = xPos;
            y = yPos;
        }

        public void renderDoor()
        {
            door.renderTexture(Globals.TextureSize, x, y);
        }
    }
}
