using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using DungeonShambles.Entities;

namespace DungeonShambles
{
	public class NewMainMenu
	{
		TextureImporter backgroundImage, newgame, quitgame;
		GameEntities mainChar;
		Font font = new Font (FontFamily.GenericSerif, 24);
		Brush brush = Brushes.White;

		public NewMainMenu (GameEntities mainCharacter) {
			mainChar = mainCharacter;
			backgroundImage = new TextureImporter ();
			newgame = new TextureImporter ();
			quitgame = new TextureImporter ();
			backgroundImage.importTexture ("Images/dungeon2_fixed.jpg");
			newgame.drawText ("New Game", font, brush);
			quitgame.drawText ("Quit", font, brush);
		}

		public void renderMenu() {
			backgroundImage.renderTexture (1, mainChar.getX(), mainChar.getY());
			GL.Enable(EnableCap.Blend);
			newgame.renderTexture (1, mainChar.getX() + 1.5f, mainChar.getY() - 1.3f);
			quitgame.renderTexture (1, mainChar.getX () + 1.5f, mainChar.getY () - 1.5f);
			GL.Disable(EnableCap.Blend);
		}

	}
}

