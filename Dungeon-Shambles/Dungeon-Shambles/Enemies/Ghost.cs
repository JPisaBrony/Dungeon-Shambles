using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles
{
    public class Ghost
    {
         //Dimension for rectangular collision box
        //Center of character is coordinate 0,0
        float collisionOffset = Globals.TextureSize / 2;

		// create a texture for the character
		TextureImporter character = new TextureImporter ();
		// character x and y position
		float x, y;
		// character movement speed
		float speed = 0.005f;

		public Ghost () {
			character.importTexture ("ghost.png");
			x = 0.4f;
			y = 0.8f;
		}

		public void renderCharacter() {
			character.renderTexture (Globals.TextureSize, x, y);
		}

        public void chase(MainCharacter main)
        {
            if (main.getX() > x)
                moveRight();
            if (main.getX() < x)
                moveLeft();
            if (main.getY() > y)
                moveUp();
            if (main.getY() < y)
                moveDown();
        }

        public void moveUp()
        {
            y += speed;
        }

        public void moveDown()
        {
            y -= speed;
        }

        public void moveRight()
        {
            x += speed;
        }

        public void moveLeft()
        {
            x -= speed;
        }




		public void increaseX(float theX) {
			x += theX;
		}

		public void increaseY(float theY) {
			y += theY;
		}

		public float getSpeed() {
			return speed;
		}

        public float getX()
        {
            return x;
        }

        public float getY()
        {
            return y;
        }
    }
}
