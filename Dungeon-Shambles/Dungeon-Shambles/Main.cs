using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using DungeonShambles.UI;
using DungeonShambles.Entities;
using QuickFont;
using System.Collections.Generic;

namespace DungeonShambles
{
    class Game : GameWindow
    {
		// object references to pass between OnLoad and OnRenderFrame
		GameEntities mainChar;
		GameEntities ghost;
		GameEntities shot;
		bool fired;
		Dungeon dungeon;

        #region MainMenu
        // QFONT STUFF
        QFont heading1, heading2, mainText, content, mainTitle, nothing;
        QFont steveDescript;
        QFont button, buttonHighlight, controlsText;
        List<string> buttons;

        #region strings

        string steve = "He is a hot, sexy, valiant young man who is ready for anything the world throws at him." + Environment.NewLine + Environment.NewLine +
                        "Steve is also a professional gamer, and one of the top players in the game “Dungeon Crawler 2015”.  Because of his fame, Steve regularly sponsors energy drink and snack companies." + Environment.NewLine + Environment.NewLine +
                        "As fate would have it, Steve’s favorite energy drink company, “Brawndo”, decided to hold a promotional gaming marathon for “dungeon Crawler 2015”, with Steve livestreaming a marathon where he attempts to stay awake as long as possible to set a world record score." + Environment.NewLine + Environment.NewLine +
                        "After nearly 3 days of constant play, Steve’s resolve ran out and he fell asleep at the computer." + Environment.NewLine + Environment.NewLine +
                        "Upon awakening, Steve finds himself in the starting level of “Dungeon Crawler 2015”.";

        string aboutUs = "Heck Yes!! WE GET A PAGE!";
        #endregion


        // Pages/button controls
        double cnt;
        double boundsAnimationCnt = 1.0f;

        int currentPage = 1;
        int lastPage = 3;
        int currentButton = 0;


        // Texture object
        TextureImporter text1, text2, text3;

        // Menus
        PauseMenu pauseMenu;
        //Inventory invMenu;
        //Stats statsMenu;

        #endregion

        bool displayMenu = true;
        bool displayStats = false;
        bool displayDungeon = false;
        bool displayPause = false;
        bool displayInv = false;

        // setup the window width and height
        public Game() : base(Globals.WindowWidth, Globals.WindowHeight) { }

        public static void Main(string[] args)
        {
            using (Game game = new Game())
            {
				// run update and game at 30 frames per second
				game.Run(30, 30);
            }
        }

        private void init()
        {
            // clear the window to white
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            GL.MatrixMode(MatrixMode.Modelview);

            GL.LoadIdentity();
            // setup the view port
			GL.Ortho(1.0, 1.0, 1.0, 1.0, 0.0, 4.0);
            // enable textures to be rendered
            GL.Enable(EnableCap.Texture2D);
            // enable alpha blending
            GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.DstAlpha);

			// enable alpha blending
			GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.DstAlpha);

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // base setup
            init();
            // set the windows title
            Title = "Dungeon Shambles";
			// clear the color of the window to black
			GL.ClearColor(Color.Black);
            // create the main character
            mainChar = new Player();
			//TODO fix ghost
            //ghost = new Ghost(0.9f, 0.9f);
            //TODO Fix mainmenu and stats menu
            
			//projectiles
			shot = new Projectile.Projectile(mainChar);
			fired = false;
			// create a new dungeon object
			dungeon = new Dungeon (11);

            // set the main character to the center of the dungeon
            mainChar.changeX(0.9f);
            mainChar.changeY(0.9f);
            GL.Translate(-0.9, -0.9, 0);

            
            pauseMenu = new PauseMenu();
            /*
            invMenu = new Inventory();
            statsMenu = new Stats();
            */
			// generate a new dungeon
			dungeon.generateDungeon ();

            #region main menu
            // texture objects
            text1 = new TextureImporter();
            text1.importTexture("Images/800x60.jpg");
            text2 = new TextureImporter();
            text2.importTexture("Images/dungeon2_fixed.jpg");
            text3 = new TextureImporter();
            text3.importTexture("Images/dungeon3_fixed.jpg");


            this.Keyboard.KeyDown += KeyState;

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
            mainTitle = new QFont("UI/Fonts/Pamela.TTF", 70, FontStyle.Regular);
            mainTitle.Options.Colour = new Color4(0.3f, 0.5f, 0.5f, 1.0f);
            mainTitle.Options.DropShadowActive = true;

            heading1 = new QFont("UI/Fonts/ModerneFraktur.ttf", 70, new QFontBuilderConfiguration(true));
            //heading1.Options.Colour = new Color4(0.8f, 0.8f, 0.8f, 0.7f);
            heading1.Options.Colour = new Color4(0.3f, 0.5f, 0.5f, 1.0f);           //  0.7f, 0.7f, 0.7f, 1.0f

            heading2 = QFont.FromQFontFile("UI/Fonts/woodenFont.qfont", 1.0f, new QFontLoaderConfiguration(true));

            var builderConfig = new QFontBuilderConfiguration(true);
            builderConfig.ShadowConfig.blurRadius = 1; //reduce blur radius because font is very small
            builderConfig.TextGenerationRenderHint = TextGenerationRenderHint.ClearTypeGridFit; //best render hint for this font

            mainText = new QFont("UI/Fonts/times.ttf", 20, FontStyle.Regular);     // changed
            mainText.Options.Colour = new Color4(0.1f, 0.1f, 0.1f, 1.0f);
            mainText.Options.DropShadowActive = true;

            steveDescript = new QFont("UI/Fonts/Comfortaa-Regular.ttf", 18, FontStyle.Regular);
            steveDescript.Options.Colour = new Color4(0.5f, 0.8f, 0.8f, 1.0f);      // (0.0f, 0.9f, 0.7f, 0.3f);

            content = new QFont("UI/Fonts/Rock.TTF", 20, FontStyle.Regular); //changed
            content.Options.Colour = new Color4(0.5f, 0.8f, 0.8f, 1.0f);        // pink : 0.7f, 0.3f, 0.5f, 1.0f
            content.Options.DropShadowActive = false;
            controlsText = new QFont("UI/Fonts/OldNewspaperTypes.ttf", 30, new QFontBuilderConfiguration(true));

            nothing = new QFont("UI/Fonts/Rock.TTF", 1, FontStyle.Regular);

            // stop depth comparisons and update depth buffer
            GL.Disable(EnableCap.DepthTest);
            #endregion
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
			//room = dungeon.getRooms ().;
			//ghost.chase(mainChar, room);
			//if (collisionTests.collision (mainChar, ghost))
			//	this.Close();
            // variable for checking keyboard input
            var keyboard = OpenTK.Input.Keyboard.GetState();
            // left key is pressed
			if (keyboard [OpenTK.Input.Key.A]) {
                //TODO fix collisions
				//if (!collisionTests.wallCollision (
					//room, mainChar.getX () - Globals.TextureSize*2 - mainChar.getSpeed()/2, mainChar.getY ())) {
					// change the main characters x position
					mainChar.changeX (-1 * mainChar.getSpeed ());
					// move the scene around the character in the x position
					GL.Translate (mainChar.getSpeed (), 0, 0);
				//}
			}
            // right key is pressed
			else if (keyboard [OpenTK.Input.Key.D]) {
                //TODO fix collisions
				//if (!collisionTests.wallCollision (
					//room, mainChar.getX () + mainChar.getSpeed(), mainChar.getY ())) {
					// decrease the main characters x position
					mainChar.changeX (mainChar.getSpeed ());
					// move the scene around the character in the x position
					GL.Translate (mainChar.getSpeed () * -1, 0, 0);
				//}
			}
            // up key is pressed
			if (keyboard [OpenTK.Input.Key.W]) {
                //TODO fix collisions
				//if (!collisionTests.wallCollision (room, mainChar.getX (), mainChar.getY () + mainChar.getSpeed())) {
					// change the main characters y position
					mainChar.changeY (mainChar.getSpeed ());
					// move the scene around the character in the y position
					GL.Translate (0, mainChar.getSpeed () * -1, 0);
				//}
			}
            // down key is pressed
			else if (keyboard [OpenTK.Input.Key.S]) {
                //TODO fix collisions
				//if (!collisionTests.wallCollision (
				//	room, mainChar.getX (), mainChar.getY () - Globals.TextureSize*2 - mainChar.getSpeed()/2)) {
					// decrease the main characters x position
					mainChar.changeY (-1 * mainChar.getSpeed ());
					// move the scene around the character in the y position
					GL.Translate (0, mainChar.getSpeed (), 0);
				//}
			}
			//Mouse events
			this.MouseDown += (object sender, MouseButtonEventArgs buttonEvent) => {
				fired = true;
			};

            //TODO fix firing
			//if (fired);
				//shot.chase (ghost);
			//else
				//shot.setX (mainChar.getX ());
            //TODO fix collisions
			//if (collisionTests.collision (shot, ghost) == true) {
			//	fired = false;
			//}
			
			if(keyboard[OpenTK.Input.Key.E]) displayMenu = true;
			if(keyboard[OpenTK.Input.Key.Escape]) displayMenu = false;

			// if tab key is held down, status menu opens and dissappears when release
			this.KeyDown += (sender, button) =>
			{
				if (button.Key == Key.Tab)
				{
					displayStats = true;
				}
			};
			this.KeyUp += (sender, button) =>
			{
				if (button.Key == Key.Tab)
				{
					displayStats = false;
				}
			};

            // variable for checking mouse input
            var mouse = OpenTK.Input.Mouse.GetState();

            Vector2 pos = new Vector2(0.6f, -0.2f);

            /*
            if (mouse[OpenTK.Input.MouseButton.Button1])
            {
                displayMenu = false;
            }
            if (mouse[OpenTK.Input.MouseButton.Right])
            {
                //TODO probably want to save game before exit
                Dispose();
            }
             */

            #region mainMenu controls update
            base.OnUpdateFrame(e);

            cnt += e.Time;

            if (boundsAnimationCnt < 1.0f)
                boundsAnimationCnt += e.Time * 0.2f;
            else
                boundsAnimationCnt = 1.0f;
            #endregion

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // clear the screen
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            // the view of the window
            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            if (displayDungeon == true)
            {
                dungeon.renderDungeon();
                GL.Enable(EnableCap.Blend);
                GL.Enable(EnableCap.Blend);
                // render the main character
                if (displayMenu == false && displayStats == false) mainChar.renderCharacter();
                GL.Disable(EnableCap.Blend);

                //TODO fix ghost
                //ghost.renderCharacter();

                if (fired)
                    shot.renderCharacter();
                GL.Disable(EnableCap.Blend);
                SwapBuffers();
            }

             // render menus
            //if (displayStats == true) 
            //    statsMenu.RenderMenu();
            if (displayPause == true)
                pauseMenu.RenderMenu();
            //if (displayInv == true)
            //    invMenu.RenderMenu();
             

            if (displayMenu == true)
            {
                #region mainMenu render
                // the view of the window
                //Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
                //GL.MatrixMode(MatrixMode.Modelview);
                //GL.LoadMatrix(ref modelview);


                switch (currentPage)
                {
                    // first page
                    case 1:
                        {
                            float yOffset = 20;
                            float noOffset = 0;
                            int count = 0;

                            //GL.ClearColor(0.2f, 0.2f, 0.2f, 1.0f);

                            //******* DOES NOTHING START REGION, FOR SOME REASON, ALLOWS BKGROUND PIC TO BE RENDERED?
                            QFont.Begin();
                            GL.PushMatrix();
                            GL.Translate(Globals.WindowWidth * 0.5f, noOffset, 0f);
                            nothing.Print("NO", QFontAlignment.Centre);
                            GL.PopMatrix();
                            QFont.End();
                            //******* DOES NOTHING END REGION

                            // render background
                            text1.renderTexture(1.0f, 0f, 0f);

                            QFont.Begin();
                            GL.PushMatrix();
                            GL.Translate(Globals.WindowWidth * 0.5f, yOffset + 20, 0f);
                            mainTitle.Print("Dungeon Shambles", QFontAlignment.Centre);
                            GL.PopMatrix();

                            yOffset += 180;

                            foreach (string s in buttons)
                            {
                                if (count == currentButton)
                                {
                                    GL.PushMatrix();
                                    buttonHighlight.Options.Colour = new Color4(3.0f, 0.0f, 1.5f, 1.9f);
                                    GL.Translate(Globals.WindowWidth * 0.5f, yOffset, 0f);
                                    buttonHighlight.Print(s, QFontAlignment.Left);

                                    GL.PopMatrix();
                                }
                                else
                                {
                                    GL.PushMatrix();
                                    button.Options.DropShadowActive = false;
                                    button.Print(s, QFontAlignment.Left, new Vector2(Globals.WindowWidth * 0.5f, yOffset));
                                    GL.PopMatrix();
                                }
                                yOffset += button.Measure(s).Height + (45);
                                count++;
                            }

                            QFont.End();
                            //text.renderTexture(1.0f, 0f, 0f);

                            GL.Disable(EnableCap.Texture2D);

                        }
                        break;

                    // second page
                    case 2:
                        {
                            float yOffset = 20;
                            float noOffset = 0;

                            //******* DOES NOTHING START REGION, FOR SOME REASON, ALLOWS BKGROUND PIC TO BE RENDERED?
                            QFont.Begin();
                            GL.PushMatrix();
                            GL.Translate(Globals.WindowWidth * 0.5f, noOffset, 0f);
                            nothing.Print("NO", QFontAlignment.Centre);
                            GL.PopMatrix();
                            QFont.End();
                            //******* DOES NOTHING END REGION

                            // render background
                            text2.renderTexture(1.0f, 0f, 0f);

                            QFont.Begin();
                            GL.PushMatrix();
                            GL.Translate(20f, yOffset, 0f);
                            heading2.Print("Story", QFontAlignment.Left);
                            yOffset += heading2.Measure("Story").Height;
                            GL.PopMatrix();

                            GL.PushMatrix();
                            GL.Translate(30f, yOffset + 50, 0f);
                            steveDescript.Print(steve, Globals.WindowWidth - 60, QFontAlignment.Justify);
                            GL.PopMatrix();
                            QFont.End();

                        }
                        break;

                    // third page
                    case 3:
                        {
                            float yOffset = 20;
                            float noOffset = 0;

                            //******* DOES NOTHING START REGION, FOR SOME REASON, ALLOWS BKGROUND PIC TO BE RENDERED?
                            QFont.Begin();
                            GL.PushMatrix();
                            GL.Translate(Globals.WindowWidth * 0.5f, noOffset, 0f);
                            nothing.Print("NO", QFontAlignment.Centre);
                            GL.PopMatrix();
                            QFont.End();
                            //******* DOES NOTHING END REGION

                            // render background
                            text3.renderTexture(1.0f, 0f, 0f);

                            // QFont Start
                            QFont.Begin();
                            GL.PushMatrix();
                            GL.Translate(20f, yOffset, 0f);
                            heading2.Print("About Us", QFontAlignment.Left);
                            yOffset += heading2.Measure("About Us").Height;
                            GL.PopMatrix();

                            GL.PushMatrix();
                            GL.Translate(20f, yOffset + 50, 0f);
                            content.Print(aboutUs, QFontAlignment.Left);
                            GL.PopMatrix();
                            QFont.End();

                        }
                        break;
                }

                // controls on bottom of all pages
                QFont.Begin();
                if (currentPage != lastPage)
                {
                    GL.PushMatrix();
                    GL.Translate(Globals.WindowWidth - 10 - 16 * (float)(1 + Math.Sin(cnt * 4)), Globals.WindowHeight - controlsText.Measure("P").Height - 10f, 0f);
                    controlsText.Options.Colour = new Color4(0.7f, 0.7f, 0.7f, 1.0f);
                    controlsText.Print("Next->", QFontAlignment.Right);
                    GL.PopMatrix();
                }
                if (currentPage != 1)
                {
                    GL.PushMatrix();
                    GL.Translate(10 + 16 * (float)(1 + Math.Sin(cnt * 4)), Globals.WindowHeight - controlsText.Measure("P").Height - 10f, 0f);
                    controlsText.Options.Colour = new Color4(0.3f, 0.5f, 0.5f, 1.0f);
                    controlsText.Print("<- Back", QFontAlignment.Left);
                    GL.PopMatrix();
                }
                QFont.End();

                GL.Disable(EnableCap.Texture2D);
                SwapBuffers();
                #endregion
            }
            
                // switch between the 2 buffers
            
        }


        // State of keys
        public void KeyState(object sender, KeyboardKeyEventArgs keyEventArgs)
        {

            switch (keyEventArgs.Key)
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

                case Key.Down:
                    {
                        if (currentPage == 1)
                        {
                            if (currentButton < 2)
                                currentButton++;
                        }
                    }
                    break;
                
                
                case Key.P:
                    displayPause = true;
                    break;
                
                case Key.I:
                    displayInv = true;
                    break;
                /*
                case Key.T:
                    testDisplay = true;
                    break;
                  */
                case Key.Escape:
                    {
                        displayPause = false;
                        displayInv = false;
                        displayStats = false;
                    }
                    break;
                 

                case Key.F9:
                    Exit();
                    break;

            }

            // navigate to pages
            if (currentPage > lastPage)
                currentPage = lastPage;

            if (currentPage < 1)
                currentPage = 1;
        }

        protected override void OnResize(EventArgs e) { }
    }
}