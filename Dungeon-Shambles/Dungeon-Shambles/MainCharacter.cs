using System;

namespace DungeonShambles
{
	public class MainCharacter
	{
		// create a texture for the character
		TextureImporter character = new TextureImporter ();
		// character x and y position
		float x, y;

		public MainCharacter ()
		{
			character.importTexture ("twi.jpg");
			x = 0f;
			y = 0f;
		}

		public void renderCharacter() {
			character.renderTexture (0.5f, x, y);
		}

		public void increaseX(float theX) {
			x += theX;
		}

		public void increaseY(float theY) {
			y += theY;
		}

	}
}

