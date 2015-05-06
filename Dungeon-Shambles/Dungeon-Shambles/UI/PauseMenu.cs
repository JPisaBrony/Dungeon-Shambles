using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using DungeonShambles.Entities;

namespace DungeonShambles.UI
{
	public class PauseMenu
	{
		TextureImporter title, resumeGame, resumeGameHighlight, quitGame, quitGameHighlight, bkgImage;
		GameEntities mainChar;
		Font titleFont = new Font(FontFamily.GenericSerif, 35);
		Font buttonFont = new Font(FontFamily.GenericSerif, 25);
		Brush controlsBrush = Brushes.Teal;
		Brush normalBrush = Brushes.White;

		public PauseMenu(GameEntities mainCharacter)
		{
			mainChar = mainCharacter;

			bkgImage = new TextureImporter();
			title = new TextureImporter();
			resumeGame = new TextureImporter();
			resumeGameHighlight = new TextureImporter();
			quitGame = new TextureImporter();
			quitGameHighlight = new TextureImporter();

			bkgImage.importTexture("Images/800x60.jpg");
			title.drawText("The Game is Paused ...", titleFont, normalBrush);
			resumeGame.drawText("Resume", buttonFont, normalBrush);
			resumeGameHighlight.drawText("Resume", buttonFont, controlsBrush);
			quitGame.drawText("Quit", buttonFont, normalBrush);
			quitGameHighlight.drawText("Quit", buttonFont, controlsBrush);
		}

		public void renderMenu()
		{
			bkgImage.renderTexture(1, mainChar.getX(), mainChar.getY());
			GL.Enable(EnableCap.Blend);
			title.renderTexture(1, mainChar.getX() + 0.5f, mainChar.getY() - 0.3f);
			if (Globals.countButton == Globals.currentButton)
			{
				resumeGameHighlight.renderTexture(1, mainChar.getX() + 0.9f, mainChar.getY() - 0.95f);
				quitGame.renderTexture(1, mainChar.getX() + 0.9f, mainChar.getY() - 1.15f);
			}
			else
			{
				resumeGame.renderTexture(1, mainChar.getX() + 0.9f, mainChar.getY() - 0.95f);
				quitGameHighlight.renderTexture(1, mainChar.getX() + 0.9f, mainChar.getY() - 1.15f);
			}
			GL.Disable(EnableCap.Blend);
		}


	}
}