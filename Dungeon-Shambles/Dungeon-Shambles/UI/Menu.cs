using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using QuickFont;
using System.Collections.Generic;

namespace DungeonShambles.UI
{
    public class Menu
    {
        //QFont stuff
        QFont heading1, heading2, mainText, content, mainTitle, nothing;
        QFont steveDescript;
        QFont button, buttonHighlight, controlsText;
        List<string> buttons;

        OpenTK.Input.KeyboardKeyEventArgs oldState;

        string steve = "He is a hot, sexy, valiant young man who is ready for anything the world throws at him." + Environment.NewLine + Environment.NewLine +
                        "Steve is also a professional gamer, and one of the top players in the game “Dungeon Crawler 2015”.  Because of his fame, Steve regularly sponsors energy drink and snack companies." + Environment.NewLine + Environment.NewLine +
                        "As fate would have it, Steve’s favorite energy drink company, “Brawndo”, decided to hold a promotional gaming marathon for “dungeon Crawler 2015”, with Steve livestreaming a marathon where he attempts to stay awake as long as possible to set a world record score." + Environment.NewLine + Environment.NewLine +
                        "After nearly 3 days of constant play, Steve’s resolve ran out and he fell asleep at the computer." + Environment.NewLine + Environment.NewLine +
                        "Upon awakening, Steve finds himself in the starting level of “Dungeon Crawler 2015”.";
        string aboutUs = "Heck Yes!! WE GET A PAGE!";
        int currentPage = 1;
        int lastPage = 3;
		int currentButton = 0;

        // Texture object
        TextureImporter text1, text2, text3;

        public Menu()
        {
            oldState = new OpenTK.Input.KeyboardKeyEventArgs();

            // texture objects
            text1 = new TextureImporter();
            text1.importTexture("Images/800x60.jpg");
            text2 = new TextureImporter();
            text2.importTexture("Images/dungeon2_fixed.jpg");
            text3 = new TextureImporter();
            text3.importTexture("Images/dungeon3_fixed.jpg");

            // add fields to buttons
            buttons = new List<string>();
            buttons.Add("New Game");
            buttons.Add("Load Game");
            buttons.Add("Quit");

            // Font stuff, making it pretty!
            button = QFont.FromQFontFile("UI/Fonts/woodenFont.qfont", 1.0f, new QFontLoaderConfiguration(true));
            button.Options.Colour = new Color4(0.9f, 0.9f, 0.9f, 1.0f);
            button.Options.DropShadowActive = true;
            buttonHighlight = QFont.FromQFontFile("UI/Fonts/woodenFont.qfont", 1.0f, new QFontLoaderConfiguration(true));
            buttonHighlight.Options.DropShadowActive = true;

            // Other Fonts
            mainTitle = new QFont("UI/Fonts/Pamela.ttf", 70, FontStyle.Regular);
            mainTitle.Options.Colour = new Color4(0.3f, 0.5f, 0.5f, 1.0f);
            mainTitle.Options.DropShadowActive = true;

            heading1 = new QFont("UI/Fonts/ModerneFraktur.ttf", 70, new QFontBuilderConfiguration(true));
			//  0.7f, 0.7f, 0.7f, 1.0f
			heading1.Options.Colour = new Color4(0.3f, 0.5f, 0.5f, 1.0f);

            heading2 = QFont.FromQFontFile("UI/Fonts/woodenFont.qfont", 1.0f, new QFontLoaderConfiguration(true));

            var builderConfig = new QFontBuilderConfiguration(true);
			//reduce blur radius because font is very small
            builderConfig.ShadowConfig.blurRadius = 1;
			//best render hint for this font
            builderConfig.TextGenerationRenderHint = TextGenerationRenderHint.ClearTypeGridFit;

			// changed
            mainText = new QFont("UI/Fonts/times.ttf", 20, FontStyle.Regular);
            mainText.Options.Colour = new Color4(0.1f, 0.1f, 0.1f, 1.0f);
            mainText.Options.DropShadowActive = true;

            steveDescript = new QFont("UI/Fonts/Comfortaa-Regular.ttf", 18, FontStyle.Regular);
			// (0.0f, 0.9f, 0.7f, 0.3f);
            steveDescript.Options.Colour = new Color4(0.5f, 0.8f, 0.8f, 1.0f);

			//changed
            content = new QFont("UI/Fonts/Rock.TTF", 20, FontStyle.Regular);
			// pink : 0.7f, 0.3f, 0.5f, 1.0f
            content.Options.Colour = new Color4(0.5f, 0.8f, 0.8f, 1.0f);
            content.Options.DropShadowActive = false;
            controlsText = new QFont("UI/Fonts/OldNewspaperTypes.ttf", 30, new QFontBuilderConfiguration(true));

            nothing = new QFont("UI/Fonts/Rock.TTF", 1, FontStyle.Regular);
        }

        public void Update()
        {
            KeyState();
        }

        public void RenderMenu()
        {
			float yOffset = 20;

            switch (currentPage)
            {
                // first page
                case 1:
                        int count = 0;

                        QFont.Begin();
						nothing.Print("NO", QFontAlignment.Centre);
                        // render background
                        text1.renderTexture(1.0f, 0f, 0f);

                        mainTitle.Print("Dungeon Shambles", QFontAlignment.Centre);
                        
                        yOffset += 180;

                        foreach (string s in buttons)
                        {
                            if (count == currentButton)
                            {
                                buttonHighlight.Options.Colour = new Color4(3.0f, 0.0f, 1.5f, 1.9f);
                                buttonHighlight.Print(s, QFontAlignment.Left);
                            }
                            else
                            {
                                button.Options.DropShadowActive = false;
                                button.Print(s, QFontAlignment.Left, new Vector2(Globals.WindowWidth * 0.5f, yOffset));
                            }
                            yOffset += button.Measure(s).Height + (45);
                            count++;
                        }
                        QFont.End();
                    	break;

                // second page
                case 2:
						QFont.Begin();
						nothing.Print("NO", QFontAlignment.Centre);
                        
						// render background
                        text2.renderTexture(1.0f, 0f, 0f);

						heading2.Print("Story", QFontAlignment.Left);
                        yOffset += heading2.Measure("Story").Height;
                        
						steveDescript.Print(steve, Globals.WindowWidth - 60, QFontAlignment.Justify);
                        
						QFont.End();
                    	break;

                // third page
                case 3:
                        QFont.Begin();
                        nothing.Print("NO", QFontAlignment.Centre);

                        // render background
                        text3.renderTexture(1.0f, 0f, 0f);

                        heading2.Print("About Us", QFontAlignment.Left);
                        yOffset += heading2.Measure("About Us").Height;

                        content.Print(aboutUs, QFontAlignment.Left);
                        QFont.End();
                    	break;
            }

            // controls on bottom of all pages
            QFont.Begin();
            if (currentPage != lastPage)
			{
                controlsText.Options.Colour = new Color4(0.7f, 0.7f, 0.7f, 1.0f);
                controlsText.Print("Next->", QFontAlignment.Right);
            }
			if (currentPage != 1)
			{
				controlsText.Options.Colour = new Color4 (0.3f, 0.5f, 0.5f, 1.0f);
				controlsText.Print ("<- Back", QFontAlignment.Left);
			}
            QFont.End();
        }

        // State of keys
        public void KeyState()
        {
            OpenTK.Input.KeyboardKeyEventArgs newState = new KeyboardKeyEventArgs();
            
            switch (newState.Key)
            {
                case Key.Right:
                    currentPage++;
                    break;

                case Key.Left:
                    currentPage--;
                    break;

                case Key.Up:
                    {
                        if (currentPage == 1)
                        {
                            if (currentButton != 0)
                                currentButton--;
                        }
                    }
                    break;
                /*
                case Key.Enter:
                    {
                        if (currentPage == 1)
                        {
                            if (currentButton == 0)
                            {
                                displayMenu = false;
                                displayDungeon = true;
                            }
                            if (currentButton == 1) ;
                            //DO SOMETHING LIKE LOAD GAME;
                            if (currentButton == 2)
                                Exit();
                        }
                    }
                    break;
                 */

                case Key.Down:
                    {
                        if (currentPage == 1)
                        {
                            if (currentButton < 2)
                                currentButton++;
                        }
                    }
                    break;

                case Key.F9:    
                    break;
            }

            // navigate to pages
            if (currentPage > lastPage)
                currentPage = lastPage;

            if (currentPage < 1)
                currentPage = 1;
        }
    }
}
