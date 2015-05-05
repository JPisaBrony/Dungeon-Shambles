using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles
{
    public class Key
    {
        private TextureImporter key = new TextureImporter();
        private float x, y;
        private bool pickedUp = false;
        public Key(float xPos, float yPos)
        {
            key.importTexture("meshes/Puzzle-Tiles/key.png");
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
        public void pickUp()
        {
            pickedUp = true;
        }
        
        public bool getPickedUp()
        {
            return pickedUp;
        }

        public TextureImporter getTexture()
        {
            return key;
        }
    }
}
