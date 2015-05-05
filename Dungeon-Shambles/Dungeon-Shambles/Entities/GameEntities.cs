using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles.Entities
{
    public class GameEntities
    {
		//Dimension for rectangular collision box
		//Center of character is coordinate 0,0
		protected float collisionOffset = Globals.TextureSize / 2;
		// create a texture for the character
		protected TextureImporter characterImage = new TextureImporter ();
        protected double health;
		protected double mana;
		protected double meleeModifier;
		protected double magicModifier;
		// character x and y position
		protected float x, y;
		// character movement speed can only be multiples of 2
		protected float speed;

		public GameEntities(string ci)
        {
			characterImage.importTexture (ci);
			x = 0f;
			y = 0f;
			speed = 0.025f;
            health = 100;
            mana = 100;
            meleeModifier = 0;
            magicModifier = 0;
        }

		public GameEntities(string ci, float inputX, float inputY)
		{
			characterImage.importTexture (ci);
			x = 0f;
			y = 0f;
			speed = 0.015f;
			health = 100;
			meleeModifier = 0;
			magicModifier = 0;
		}

		public GameEntities(string ci, float initialX, float initialY,
			float initialSpeed, double h, double m, double cMod, double aMod)
        {
			characterImage.importTexture (ci);
			x = initialX;
			y = initialY;
			speed = initialSpeed;
            health = h;
            mana = m;
            meleeModifier = cMod;
            magicModifier = aMod;
        }

		public void chase(GameEntities target, Room room)
		{
			if (target.getX() > x)
				changeX(speed, room);
			if (target.getX() < x)
				changeX(speed*-1, room);
			if (target.getY() > y)
				changeY(speed);
			if (target.getY() < y)
				changeY(speed*-1);
		}

		public void renderCharacter() 
		{
			characterImage.renderTexture (Globals.TextureSize, x, y);
		}

        public double getHealth()
        {
            return health;
        }

		public void changeX(float theSpeed, Room room) 
		{
			if (!collisionTests.wallCollision (room, x - Globals.TextureSize * 2 - speed / 2, y))
				x += theSpeed;
		}

        public void changeX(float speed) {
            x += speed;
        }

		public void changeY(float speed) {
			y += speed;
		}

		public float getSpeed() 
		{
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

		public void setX(float inputX) {x = inputX;}
		public void setY(float inputY) {y = inputY;}

    }    
}
