using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles
{
    public class Target
    {
        private TextureImporter target = new TextureImporter();
        private float x, y;

        public Target(float xPos, float yPos)
        {
            target.importTexture("meshes/target.jpg");
            x = xPos;
            y = yPos;
        }

        public void renderTarget() { 
            target.renderTexture(Globals.TextureSize, x, y);
        }

        public float getX()
        {
            return x;
        }

        public float getY()
        {
            return y;
        }

        public TextureImporter getTexture()
        {
            return target;
        }
    }
}
