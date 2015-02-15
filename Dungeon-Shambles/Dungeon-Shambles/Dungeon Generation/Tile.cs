using System;

namespace DungeonShambles
{
	public class Tile
	{
		// create a texture for the tile
		private TextureImporter tile = new TextureImporter ();
		// tile width and height
		private int width, height;

		public Tile (string tileName, int w, int h)
		{
			tile.importTexture(tileName);
			width = w;
			height = h;
		}

		public void renderTile(float size, float xPos, float yPos) {
			tile.renderTexture (size, xPos, yPos);
		}

		public int getWidth() {
			return width;
		}

		public int getHeight() {
			return height;
		}
	}
}

