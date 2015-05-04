using System;

namespace DungeonShambles
{
	public class Animation
	{
		private TextureImporter[] texs;
		private int delay;
		private int currentlyRendered;
		private Boolean play;

		public Animation (String [] pics, int d) {
			delay = d;
			currentlyRendered = 0;
			play = true;
			texs = new TextureImporter [pics.Length];
			for (int i = 0; i < texs.Length; i++) {
				TextureImporter t = new TextureImporter ();
				t.importTexture (pics [i]);
				texs [i] = t;
			}
		}

		public void renderAnimation(float size, int x, int y) {
			texs [currentlyRendered].renderTexture (size , x, y);
			if (play) {
				if (Globals.time % delay == 0) {
					if (currentlyRendered < texs.Length - 1)
						currentlyRendered++;
					else
						currentlyRendered = 0;
				}
			}
		}

		public void setPlaying(Boolean p) {
			play = p;
		}
	}
}

