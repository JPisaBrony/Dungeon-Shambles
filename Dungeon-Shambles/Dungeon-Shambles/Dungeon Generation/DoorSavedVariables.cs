using System;

namespace DungeonShambles
{
	public class DoorSavedVariables
	{
		private int side;
		private int offset;

		public DoorSavedVariables (int s, int o)
		{
			side = s;
			offset = o;
		}

		public int getSide() {
			return side;
		}

		public int getOffset() {
			return offset;
		}
	}
}

