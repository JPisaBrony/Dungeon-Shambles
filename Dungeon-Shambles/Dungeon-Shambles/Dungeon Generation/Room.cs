using System;

namespace DungeonShambles
{
	public class Room
	{
		private Tile[,] tiles;
		private int roomWidth, roomHeight;
		private string tileName;
		private string wallName;
		private int tileSize;

		public Room (string tile, string wall, int tSize) {
			tileName = tile;
			tileSize = tSize;
			wallName = wall;
		}

		public void generateRoom(int w, int h) {
			tiles = new Tile[w, h];
			roomWidth = w;
			roomHeight = h;
			for (int i = 0; i < w; i++) {
				for (int j = 0; j < h; j++) {
					if(i == 0 || j == 0 || i == w || j == h)
						tiles[i,j] = new Tile (wallName, tileSize, tileSize, true);
					tiles[i,j] = new Tile (tileName, tileSize, tileSize, false);
				}
			}
		}

		public void renderRoom() {
			for (int i = 0; i < roomWidth; i++) {
				for (int j = 0; j < roomHeight; j++) {
					tiles [i,j].renderTile (Globals.TextureSize, i * Globals.TextureSize * 2, j * Globals.TextureSize * 2);
				}
			}
		}

		public Tile getTileAtLocation(int x, int y) {
			return tiles [x, y];
		}
	}
}

