using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Threading;

namespace DungeonShambles
{
	class Game: GameWindow
	{
		// object references to pass between OnLoad and OnRenderFrame
		Dungeon dungeon;
        MainCharacter mainChar;
        Puzzles puzzles;
        
        string[] Tilenames = new string[] {
			"meshes/D1Tiles/D1Floor.png",
			"meshes/D1Tiles/D1WestWall.png",
			"meshes/D1Tiles/D1NorthWall.png",
			"meshes/D1Tiles/D1EastWall.png",
			"meshes/D1Tiles/D1SouthWall.png",
			"meshes/D1Tiles/SWCorner.png",
			"meshes/D1Tiles/NWCorner.png",
			"meshes/D1Tiles/NECorner.png",
			"meshes/D1Tiles/SECorner.png"
		};

		// setup the window width and height
		public Game() : base(Globals.WindowWidth, Globals.WindowHeight) {}

		public static void Main (string[] args)
		{
			using (Game game = new Game())
			{
				// run update and game at 30 frames per second
				game.Run(30, 30);
			}
		}

		private void init() {
			// clear the window to white
			GL.ClearColor (0.0f, 0.0f, 0.0f, 0.0f);

			GL.MatrixMode (MatrixMode.Modelview);

			GL.LoadIdentity ();
			// setup the view port
			GL.Ortho (100, 100, 100, 100, 0, 1);
			// enable textures to be rendered
			GL.Enable(EnableCap.Texture2D);

			GL.BlendFunc (BlendingFactorSrc.One, BlendingFactorDest.DstAlpha);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			// base setup
			init ();
			// set the windows title
			Title = "Dungeon Shambles";
			// clear the color of the window to black
			GL.ClearColor(Color.Black);
			// create the main character
			mainChar = new MainCharacter ();

            // create a new dungeon object
            dungeon = new Dungeon (11);
            // generate a new dungeon
            dungeon.generateDungeon();

			// set the main character to the center of the dungeon
			mainChar.increaseX (0.9f);
			mainChar.increaseY (0.9f);
			GL.Translate (-0.9f, -0.9f, 0);

            // create a new puzzle object
            puzzles = new Puzzles(mainChar);
		}

		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			// variable for checking keyboard input
			var keyboard = OpenTK.Input.Keyboard.GetState();
			// left key is pressed
			if (keyboard [OpenTK.Input.Key.A]) {
				// increase the main characters x position
				mainChar.increaseX (-1 * mainChar.getSpeed ());

                RockCollision.collisionTest(mainChar, 1);

				// move the scene around the character in the x position
				GL.Translate (mainChar.getSpeed (), 0, 0);
                
			}
			// right key is pressed
			else if (keyboard [OpenTK.Input.Key.D]) {
				// decrease the main characters x position
				mainChar.increaseX (mainChar.getSpeed ());
				// move the scene around the character in the x position

                RockCollision.collisionTest(mainChar, 2);

                GL.Translate (mainChar.getSpeed() * -1, 0, 0); 
			}
			// up key is pressed
			if (keyboard [OpenTK.Input.Key.W]) {
				// increase the main characters y position
				mainChar.increaseY (mainChar.getSpeed ());
				// move the scene around the character in the y position

                RockCollision.collisionTest(mainChar, 3);
                
                GL.Translate (0, mainChar.getSpeed () * -1, 0);
			}
			// down key is pressed
			else if (keyboard [OpenTK.Input.Key.S]) {
				// decrease the main characters x position
				mainChar.increaseY (-1 * mainChar.getSpeed ());
				// move the scene around the character in the y position

                RockCollision.collisionTest(mainChar, 4);

                GL.Translate (0, mainChar.getSpeed (), 0);
			}
            
            if (keyboard [OpenTK.Input.Key.Space])
            {
                Thread.Sleep(100);
                puzzles.puzzleActions();
            }

		}

		protected override void OnRenderFrame(FrameEventArgs e)
		{
			// clear the screen
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			dungeon.renderDungeon ();
            puzzles.renderPuzzles();

			GL.Enable (EnableCap.Blend);
			// render the main character
			mainChar.renderCharacter ();
			GL.Disable (EnableCap.Blend);

			// switch between the 2 buffers
			SwapBuffers();
		}

		protected override void OnResize(EventArgs e) {}
	}
}