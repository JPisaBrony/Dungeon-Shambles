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
		private DoorSavedVariables[] doorVariables;
		private int roomNumber;

		public Room (string[] tNames, int tSize, int n) {
			tileSize = tSize;
			tileNames = tNames;
			roomNumber = n;
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

		public void setDoor(int side, int offset, Boolean locked, int index) {
			doorVariables [index] = new DoorSavedVariables (side, offset);
            switch (side) {
                case 0:
					if(locked)
						setTileAtLocation(tileNames[9], offset, 0, true, true);
					else
						setTileAtLocation(tileNames[0], offset, 0, false, true);
                    break;
                case 1:
					if(locked)
                    	setTileAtLocation(tileNames[10], 0, offset, true, true);
					else
						setTileAtLocation(tileNames[0], 0, offset, false, true);
                    break;
                case 2:
					if(locked)
                    	setTileAtLocation(tileNames[11], offset, roomHeight - 1, true, true);
					else
						setTileAtLocation(tileNames[0], offset, roomHeight - 1, false, true);
                    break;
                case 3:
					if(locked)
                    	setTileAtLocation(tileNames[12], roomWidth - 1, offset, true, true);
					else
						setTileAtLocation(tileNames[0], roomWidth - 1, offset, false, true);
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

		public void setDoorAndAdjacentRoom(Dungeon dungeon, int door, int adj, int index) {
			Room r = dungeon.getRooms () [adj];
			setDoor (doorVariables [door].getSide (), doorVariables [door].getOffset (), false, door);
			r.setDoor (r.getDoorVars()[index].getSide (), r.getDoorVars()[index].getOffset (), false, index);
		}

		public void setNumberOfDoors(int s) {
			doorVariables = new DoorSavedVariables[s];
		}

        private void setTileAtLocation(String name, int x, int y, Boolean wall, Boolean door) {
            tiles[x, y] = new Tile (name, tileSize, tileSize, wall, door);
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

        public float getOffsetX() {
            return coordinateOffsetX;
        }

        public float getOffsetY() {
            return coordinateOffsetY;
        }

		public DoorSavedVariables[]  getDoorVars() {
			return doorVariables;
		}

		public int getRoomNumber() {
			return roomNumber;
		}
	}
}