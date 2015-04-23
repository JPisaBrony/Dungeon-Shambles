using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles
{
    public class Lever
    {
        bool flipped = false;
        private TextureImporter leftLever = new TextureImporter();
        private TextureImporter rightLever = new TextureImporter();

        private float x, y;

        public Lever(float xPos, float yPos)
        {
            leftLever.importTexture("meshes/LeftLever.png");
            rightLever.importTexture("meshes/RightLever.png");
            x = xPos;
            y = yPos;
        }

        public void renderLever()
        {
            if (flipped == false)
            {
                leftLever.renderTexture(Globals.TextureSize, x, y);
                
            }
            if (flipped == true)
            {
                rightLever.renderTexture(Globals.TextureSize, x, y);
                
            }
        }

        public float getX()
        {
            return x;
        }

        public float getY()
        {
            return y;
        }

        public void setFlippedF()
        {
            flipped = false;
        }

        public void setFlippedT()
        {
            flipped = true;
        }

        public bool getFlipped()
        {
            return flipped;
        }
    }
}
