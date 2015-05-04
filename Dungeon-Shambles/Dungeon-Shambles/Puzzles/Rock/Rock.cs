using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles
{
    public class Rock
    {
        private TextureImporter rock = new TextureImporter();
        private float x, y;
        
        public Rock(int xPos, int yPos)
        {
            rock.importTexture("meshes/rock.png");
            x = xPos;
            y = yPos;
        }

        public void renderRock()
        {rock.renderTexture(Globals.TextureSize, x, y);}

        public void increaseX(float theX)
        {x += theX;}

        public void increaseY(float theY)
        {y += theY;}

        public float getX()
        {return x;}

        public float getY()
        {return y;}

        public TextureImporter getTexture()
        {
            return rock;
        }
    }
}
