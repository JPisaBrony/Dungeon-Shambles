using System;

namespace DungeonShambles
{
	public class Room
	{
		private Tile[,] tiles;
		private int roomWidth, roomHeight;
		private string[] tileNames;
		private int tileSize;
        private float coordinateOffsetX;
        private float coordinateOffsetY;

		public Room (string[] tNames, int tSize) {
			tileSize = tSize;
			tileNames = tNames;
		}

		public void generateRoom(int w, int h) {
			tiles = new Tile[w, h];
			roomWidth = w;
			roomHeight = h;
			for (int i = 0; i < w; i++) {
				for (int j = 0; j < h; j++) {
					if (i == 0 && j == 0) {
						tiles [i, j] = new Tile (tileNames [5], tileSize, tileSize, true, false);
					} else if (i == 0 && j == h - 1) {
						tiles [i, j] = new Tile (tileNames [6], tileSize, tileSize, true, false);
					} else if (i == w - 1 && j == h - 1) {
						tiles [i, j] = new Tile (tileNames [7], tileSize, tileSize, true, false);
					} else if (i == w - 1 && j == 0) {
						tiles [i, j] = new Tile (tileNames [8], tileSize, tileSize, true, false);
					} else if (i == 0) {
						tiles [i, j] = new Tile (tileNames [1], tileSize, tileSize, true, false);
					} else if (j == h - 1) {
						tiles [i, j] = new Tile (tileNames [2], tileSize, tileSize, true, false);
					} else if (i == w - 1) {
						tiles [i, j] = new Tile (tileNames [3], tileSize, tileSize, true, false);
					} else if (j == 0) {
						tiles [i, j] = new Tile (tileNames [4], tileSize, tileSize, true, false);
					} else {
						tiles [i, j] = new Tile (tileNames [0], tileSize, tileSize, false, false);
					}
				}
			}
		}

        public void setDoor(int side, int offset) {
            switch (side) {
                case 0:
                    setTileAtLocation(offset, 0, false, true);
                    break;
                case 1:
                    setTileAtLocation(0, offset, false, true);
                    break;
                case 2:
                    setTileAtLocation(offset, roomHeight - 1, false, true);
                    break;
                case 3:
                    setTileAtLocation(roomWidth - 1, offset, false, true);
                    break;
            }
        }

		public void renderRoom(float offsetX, float offsetY) {
            coordinateOffsetX = offsetX;
            coordinateOffsetY = offsetY;
			for (int i = 0; i < roomWidth; i++) {
				for (int j = 0; j < roomHeight; j++) {
					tiles [i,j].renderTile (Globals.TextureSize, i * Globals.TextureSize * 2 + offsetX, j * Globals.TextureSize * 2 + offsetY);
				}
			}
		}

        private void setTileAtLocation(int x, int y, Boolean wall, Boolean door) {
            tiles[x, y] = new Tile (tileNames [0], tileSize, tileSize, wall, door);
        }

		public Tile getTileAtLocation(int x, int y) {
			return tiles [x, y];
		}

        public void setAboveTileAtLocation(float x, float y, TextureImporter t) {
            t.renderTexture(Globals.TextureSize, x * Globals.TextureSize * 2  + coordinateOffsetX, y * Globals.TextureSize * 2 + coordinateOffsetY);
        }

		public int getRoomWidth() {
			return roomWidth;
		}

		public int getRoomHeight() {
			return roomHeight;
		}

        public float getcoordinateOffsetX() {
            return coordinateOffsetX;
        }

        public float getcoordinateOffsetY() {
            return coordinateOffsetY;
        }
	}
}

