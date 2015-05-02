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

        private TextureImporter current = new TextureImporter();
        private float x, y;

        public Lever(float xPos, float yPos)
        {
            leftLever.importTexture("meshes/LeftLever.png");
            rightLever.importTexture("meshes/RightLever.png");
            current = leftLever;
            x = xPos;
            y = yPos;
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
            current = leftLever;
        }

        public void setFlippedT()
        {
            flipped = true;
            current = rightLever;
        }

        public bool getFlipped()
        {
            return flipped;
        }

        public TextureImporter getCurrentTexture()
        {
            return current;
        }
    }
}
