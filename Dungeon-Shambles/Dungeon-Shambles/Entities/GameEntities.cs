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
        protected Double health;
		protected Double mana;
		protected Double meleeModifier;
		protected Double magicModifier;
		// character x and y position
		protected float x, y;
		// character movement speed can only be multiples of 2
		protected float speed;
        protected Room currentRoom;

        public GameEntities(String ci, Room room)
        {
			characterImage.importTexture (ci);
			x = 0f;
			y = 0f;
			speed = 0.025f;
            health = 100;
            mana = 100;
            meleeModifier = 0;
            magicModifier = 0;
            currentRoom = room;
        }

		public GameEntities(String ci, float inputX, float inputY)
		{
			characterImage.importTexture (ci);
			x = 0f;
			y = 0f;
			speed = 0.015f;
			health = 1;
			mana = 0;
			meleeModifier = 0;
			magicModifier = 0;
		}

		public GameEntities(String ci, float initialX, float initialY,
			float initialSpeed, Double h, Double m, Double cMod, Double aMod)
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

		/*public void chase(GameEntities target, Room room)
		{
			if (target.getX() > x)
				changeX(1, room);
			if (target.getX() < x)
				changeX(-1, room);
			if (target.getY() > y)
				changeY(1, room);
			if (target.getY() < y)
				changeY(-1, room);
		}*/

		public void renderCharacter() 
		{
			characterImage.renderTexture (Globals.TextureSize, x, y);
		}


        public Boolean changeX(float delta) 
		{
            float mod = Globals.TextureSize * -1 / 10;
            if (delta > 0)
                mod = Globals.TextureSize * 2;

            if (!collisionTests.wallCollision(currentRoom, x + mod - currentRoom.getOffsetX(), y - currentRoom.getOffsetY()))
            {
                x += delta * speed;
                return true;
            }
            else
            {
                return false;
            }
		}

        public Boolean changeY(float delta)
        {
            float mod = Globals.TextureSize * -1 / 10;
            if (delta > 0)
                mod = Globals.TextureSize * 2;
            
            if (!collisionTests.wallCollision(currentRoom, x - currentRoom.getOffsetX(), y + mod - currentRoom.getOffsetY()))
            {
                y += delta * speed;
                return true;
            }
            else
            {
                return false;
            }
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

        public void setCurrentRoom(Room cr) {
            currentRoom = cr;
        }

        public Room getCurrentRoom() {
            return currentRoom;
        }
    }    
}
