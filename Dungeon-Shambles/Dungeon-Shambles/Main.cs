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
		Dungeon dungeon;
		NewMainMenu MainMenu;

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

			// create a new dungeon object
			dungeon = new Dungeon (11, 4, 10);
            // generate a new dungeon
            dungeon.generateDungeon();

			// create main menu
			MainMenu = new NewMainMenu (mainChar);

            // set the main character to the center of the dungeon
            mainChar.changeX(0.9f);
            mainChar.changeY(0.9f);
            GL.Translate(-0.9, -0.9, 0);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var keyboard = OpenTK.Input.Keyboard.GetState();
            // left key is pressed
			if (keyboard [OpenTK.Input.Key.A] && !Globals.displayMainMenu) {
				// change the main characters x position
				mainChar.changeX (-1 * mainChar.getSpeed ());
				// move the scene around the character in the x position
				GL.Translate (mainChar.getSpeed (), 0, 0);
			}
            // right key is pressed
			else if (keyboard [OpenTK.Input.Key.D] && !Globals.displayMainMenu) {
				// decrease the main characters x position
				mainChar.changeX (mainChar.getSpeed ());
				// move the scene around the character in the x position
				GL.Translate (mainChar.getSpeed () * -1, 0, 0);
			}
            // up key is pressed
			if (keyboard [OpenTK.Input.Key.W] && !Globals.displayMainMenu) {
				// change the main characters y position
				mainChar.changeY (mainChar.getSpeed ());
				// move the scene around the character in the y position
				GL.Translate (0, mainChar.getSpeed () * -1, 0);
			}
            // down key is pressed
			else if (keyboard [OpenTK.Input.Key.S] && !Globals.displayMainMenu) {
				// decrease the main characters x position
				mainChar.changeY (-1 * mainChar.getSpeed ());
				// move the scene around the character in the y position
				GL.Translate (0, mainChar.getSpeed (), 0);
			// temporary key presses
			// e key is pressed
			} else if (keyboard [OpenTK.Input.Key.E]) {
				Globals.displayMainMenu = false;
			// esc key is pressed
			} else if (keyboard [OpenTK.Input.Key.Escape]) {
				Globals.displayMainMenu = true;
			}
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // clear the screen
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			// check to see if the menu should be rendered
			if (Globals.displayMainMenu) {
				// display the main menu
				MainMenu.renderMenu();
            }
            else {
				// render the dungeon
				dungeon.renderDungeon();
				// render the main character
				//GL.Enable(EnableCap.Blend);
				mainChar.renderCharacter();
				//GL.Disable(EnableCap.Blend);
            }

            // switch between the two buffer
            SwapBuffers();
        }

        protected override void OnResize(EventArgs e) { }
    }
}