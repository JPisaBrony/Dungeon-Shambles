<<<<<<< HEAD
﻿using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using DungeonShambles.UI;
using DungeonShambles.Entities;

namespace DungeonShambles
{
    class Game : GameWindow
    {
		// object references to pass between OnLoad and OnRenderFrame
		MainMenu mainMenu;
		Stats statsMenu;
        GameEntities mainChar;
		GameEntities ghost;
		GameEntities shot;
		bool fired;
		Room firstRoom;
        bool displayMenu = false;
        bool displayStats = false;

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
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // base setup
            init();
            // set the windows title
            Title = "Dungeon Shambles";
            // clear the color of the window to twilight sparkle's magenta
            GL.ClearColor(Color.FromArgb(204, 159, 213));
            // create the main character
            mainChar = new Player();
			ghost = new Ghost(0.9f, 0.9f);
            mainMenu = new MainMenu();
            statsMenu = new Stats();
			//projectiles
			shot = new Projectile.Projectile(mainChar);
			fired = false;
			//a room
			firstRoom = new Room ("tempTile.png", "tempTile.png", 1);

			firstRoom.generateRoom (10, 10);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
			ghost.chase(mainChar);
			if (collisionTests.collision (mainChar, ghost) == true)
				this.Close();
            // variable for checking keyboard input
            var keyboard = OpenTK.Input.Keyboard.GetState();
            // left key is pressed
			if (keyboard [OpenTK.Input.Key.A]) {
				if (!collisionTests.wallCollision (
					firstRoom, mainChar.getX () - Globals.TextureSize*2 - mainChar.getSpeed()/2, mainChar.getY ())) {
					// change the main characters x position
					mainChar.changeX (-1 * mainChar.getSpeed ());
					// move the scene around the character in the x position
					GL.Translate (mainChar.getSpeed (), 0, 0);
				}
			}
            // right key is pressed
			else if (keyboard [OpenTK.Input.Key.D]) {
				if (!collisionTests.wallCollision (
					firstRoom, mainChar.getX () + mainChar.getSpeed(), mainChar.getY ())) {
					// decrease the main characters x position
					mainChar.changeX (mainChar.getSpeed ());
					// move the scene around the character in the x position
					GL.Translate (mainChar.getSpeed () * -1, 0, 0);
				}
			}
            // up key is pressed
			if (keyboard [OpenTK.Input.Key.W]) {
				if (!collisionTests.wallCollision (firstRoom, mainChar.getX (), mainChar.getY () + mainChar.getSpeed())) {
					// change the main characters y position
					mainChar.changeY (mainChar.getSpeed ());
					// move the scene around the character in the y position
					GL.Translate (0, mainChar.getSpeed () * -1, 0);
				}
			}
            // down key is pressed
			else if (keyboard [OpenTK.Input.Key.S]) {
				if (!collisionTests.wallCollision (
					firstRoom, mainChar.getX (), mainChar.getY () - Globals.TextureSize*2 - mainChar.getSpeed()/2)) {
					// decrease the main characters x position
					mainChar.changeY (-1 * mainChar.getSpeed ());
					// move the scene around the character in the y position
					GL.Translate (0, mainChar.getSpeed (), 0);
				}
			}
			//Mouse events
			this.MouseDown += (object sender, MouseButtonEventArgs buttonEvent) => {
				fired = true;
			};

			if (fired)
				shot.chase (ghost);
			else
				shot.setX (mainChar.getX ());
			if (collisionTests.collision (shot, ghost) == true) {
				fired = false;
			}
			
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
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // clear the screen
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			firstRoom.renderRoom ();

            // render the main character
            mainChar.renderCharacter();

            ghost.renderCharacter();

			if (fired)
				shot.renderCharacter ();

            // render menus
            if (displayMenu == true) mainMenu.RenderMenu();
            if (displayStats == true) statsMenu.RenderMenu();

            // switch between the 2 buffers
            SwapBuffers();
        }

        protected override void OnResize(EventArgs e) { }
    }
=======
﻿using System;
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
		Dungeon dungeon;


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

			dungeon = new Dungeon (9);

			dungeon.generateDungeon ();
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

			dungeon.renderDungeon ();

			GL.Enable (EnableCap.Blend);
			// render the main character
			mainChar.renderCharacter ();
			GL.Disable (EnableCap.Blend);

			// switch between the 2 buffers
			SwapBuffers();
		}

		protected override void OnResize(EventArgs e) {}
	}
>>>>>>> origin/dungeon-generation
}