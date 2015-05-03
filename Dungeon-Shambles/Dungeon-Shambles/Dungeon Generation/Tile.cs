using System;

namespace DungeonShambles
{
	public class Tile
	{
		// create a texture for the tile
		private TextureImporter tile = new TextureImporter ();
		// tile width and height
		private int width, height;
		// if the tile is a wall
		private Boolean isWall;

        public Tile (string tileName, int w, int h, Boolean wall) {
			tile.importTexture(tileName);
			width = w;
			height = h;
			isWall = wall;
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

		public Boolean getIsWall() {
			return isWall;
		}
	}
}

