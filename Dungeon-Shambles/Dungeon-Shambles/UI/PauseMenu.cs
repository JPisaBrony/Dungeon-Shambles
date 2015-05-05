using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using QuickFont;
using System.Drawing;

namespace DungeonShambles.UI
{
    public class PauseMenu
    {
        // fields
        QFont title, buttonHighlight, button, nothing;
        List<string> buttons;

        int currentButton = 0;

        OpenTK.Input.KeyboardKeyEventArgs oldState;

        TextureImporter text1;

        public PauseMenu()
		{
            oldState = new OpenTK.Input.KeyboardKeyEventArgs();

            // gray bkgd color
            GL.ClearColor(0.2f, 0.2f, 0.2f, 1.0f);

            text1 = new TextureImporter();
            text1.importTexture("Images/800x60.jpg");

            buttons = new List<string>();
            buttons.Add("Resume");
            buttons.Add("Save Game");
            buttons.Add("Quit");

            button = QFont.FromQFontFile("UI/Fonts/woodenFont.qfont", 1.0f, new QFontLoaderConfiguration(true));
            button.Options.DropShadowActive = true;
            buttonHighlight = QFont.FromQFontFile("UI/Fonts/woodenFont.qfont", 1.0f, new QFontLoaderConfiguration(true));
            buttonHighlight.Options.DropShadowActive = true;
            button.Options.Colour = new Color4(0.7f, 0.7f, 0.7f, 1.0f);

            title = new QFont("UI/Fonts/Dungeon.TTF", 80, FontStyle.Regular);
            title.Options.Colour = new Color4(0.7f, 0.7f, 0.7f, 1.0f);
            title.Options.DropShadowActive = true;

            nothing = new QFont("UI/Fonts/Rock.TTF", 1, FontStyle.Regular);
        }

      /*  public void Update()
        {
            KeyState();
        }*/

        public void RenderMenu()
        {
            float yOffset = 25;
            int count = 0;

            QFont.Begin();
            nothing.Print("NO", QFontAlignment.Centre);
            text1.renderTexture(1.0f, 0f, 0f);
            title.Print("Pause Menu", QFontAlignment.Centre);

            yOffset += 175;
            foreach (string s in buttons)
            {
                if (count == currentButton)
                {
                    buttonHighlight.Options.Colour = new Color4(3.0f, 0.0f, 1.5f, 1.9f);
                    buttonHighlight.Print(s, QFontAlignment.Centre);
                }
                else
                {
                    button.Options.DropShadowActive = false;
                    button.Print(s, QFontAlignment.Centre, new Vector2(Globals.WindowWidth * 0.5f, yOffset));
                }
                yOffset += button.Measure(s).Height + (50);
                count++;
            }

            QFont.End();
        }

      /*  private void KeyState()
        {
            OpenTK.Input.KeyboardKeyEventArgs newState = new KeyboardKeyEventArgs();

            switch (newState.Key)
            {
                case Key.Up:
					if (currentButton != 0)
						currentButton--;
					break;
                case Key.Down:
					if (currentButton < 2)
                    	currentButton++;
                    break;
            }

            oldState = newState;
        }
       * */
    }
}
