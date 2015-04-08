using System;

namespace DungeonShambles
{
	public class MainCharacter
	{
		// create a texture for the character
		TextureImporter character = new TextureImporter ();
		// character x and y position
		float x, y;
		// character movement speed
		float speed = 0.1f;

		public MainCharacter () {
			character.importTexture ("twi.jpg");
			x = 0.0f;
			y = 0.0f;
		}

		public void renderCharacter() {
			character.renderTexture (Globals.TextureSize, x, y);
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

		public float getX() {
			return x;
		}

		public float getY() {
			return y;
		}
	}
}

