using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace DungeonShambles
{
	class Game: GameWindow
	{
		// object references to pass between OnLoad and OnRenderFrame
		MainCharacter mainChar;
		Room firstRoom;

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
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			// base setup
			init ();
			// set the windows title
			Title = "Dungeon Shambles";
			// clear the color of the window to twilight sparkle's magenta
			GL.ClearColor(Color.FromArgb (204, 159, 213));
			// create the main character
			mainChar = new MainCharacter ();

			firstRoom = new Room ("tempTile.png", "tempTile.png", 1);

			firstRoom.generateRoom (10, 10);
		}

		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			// variable for checking keyboard input
			var keyboard = OpenTK.Input.Keyboard.GetState();
			// left key is pressed
			if (keyboard [OpenTK.Input.Key.A]) {
				// increase the main characters x position
				mainChar.increaseX (-1 * mainChar.getSpeed ());
				// move the scene around the character in the x position
				GL.Translate (mainChar.getSpeed (), 0, 0);
			}
			// right key is pressed
			else if (keyboard [OpenTK.Input.Key.D]) {
				// decrease the main characters x position
				mainChar.increaseX (mainChar.getSpeed ());
				// move the scene around the character in the x position
				GL.Translate (mainChar.getSpeed() * -1, 0, 0);
			}
			// up key is pressed
			if (keyboard [OpenTK.Input.Key.W]) {
				// increase the main characters y position
				mainChar.increaseY (mainChar.getSpeed ());
				// move the scene around the character in the y position
				GL.Translate (0, mainChar.getSpeed () * -1, 0);
			}
			// down key is pressed
			else if (keyboard [OpenTK.Input.Key.S]) {
				// decrease the main characters x position
				mainChar.increaseY (-1 * mainChar.getSpeed ());
				// move the scene around the character in the y position
				GL.Translate (0, mainChar.getSpeed (), 0);
			}
		}

		protected override void OnRenderFrame(FrameEventArgs e)
		{
			// clear the screen
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			firstRoom.renderRoom ();

			// render the main character
			mainChar.renderCharacter ();

			// switch between the 2 buffers
			SwapBuffers();
		}

		protected override void OnResize(EventArgs e) {}
	}
}