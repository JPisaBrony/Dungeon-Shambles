using System;

namespace DungeonShambles
{
	public class Room
	{
		private Tile[,] tiles = new Tile[10,10];
		private int roomWidth, roomHeight;
		private string tileName;
		private int tileSize;

		public Room (string tile, int tSize) {
			tileName = tile;
			tileSize = tSize;
		}

		public void generateRoom(int w, int h) {
			roomWidth = w;
			roomHeight = h;
			for (int i = 0; i < w; i++) {
				for (int j = 0; j < h; j++) {
					tiles[i,j] = new Tile (tileName, tileSize, tileSize);
				}
			}

		}

		public void renderRoom() {

			for (int i = 0; i < roomWidth; i++) {
				for (int j = 0; j < roomHeight; j++) {
					tiles [i,j].renderTile (Globals.TextureSize, i * Globals.TextureSize, j * Globals.TextureSize);
				}
			}

		}

	}
}

