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
		MainCharacter mainChar;
		Dungeon dungeon;
        Room room;
        Rock rock1;
        Rock rock2;
        Target target1;
        Target target2;
        Door door;
        Door leverDoor;

        Lever lever1;
        Lever lever2;
        Lever lever3;
        bool solved = false;
        bool leverSolved = false;
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
				game.Run(20, 30);
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

			//dungeon = new Dungeon (9);

			//dungeon.generateDungeon ();

            room = new Room(Tilenames, 1);
            room.generateRoom(10,10, 2);

            rock1 = new Rock(.7f, .7f);
            rock2 = new Rock(.5f, .5f);

            target1 = new Target(.2f, .7f);
            target2 = new Target(.5f, .9f);

            RockCollision.addRock(rock1);
            RockCollision.addRock(rock2);

            TargetTest.addTarget(target1);
            TargetTest.addTarget(target2);

            door = new Door(.4f, 1.8f);
            leverDoor = new Door(1.6f, 1.8f);

            lever1 = new Lever(.8f, 1.8f);
            lever2 = new Lever(1f, 1.8f);
            lever3 = new Lever(1.2f, 1.8f);

            Levers.addLever(0, lever1);
            Levers.addLever(1, lever2);
            Levers.addLever(2, lever3);
		}

		protected override void OnUpdateFrame(FrameEventArgs e)
		{
            if (TargetTest.pressTest(RockCollision.getRocks()))
            {
                Console.WriteLine("Solved");
                solved = true;
            }

            

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
                Levers.flipLever(mainChar);
            }

            if (Levers.checkSolved())
            {
                Console.WriteLine("Got it");
                leverSolved = true;
            }
		}

		protected override void OnRenderFrame(FrameEventArgs e)
		{
			// clear the screen
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			//dungeon.renderDungeon ();
            room.renderRoom(0,0);

            target1.renderTarget();
            target2.renderTarget();

            rock1.renderRock();
            rock2.renderRock();

            lever1.renderLever();
            lever2.renderLever();
            lever3.renderLever();

            if (solved == true)
            {
                door.renderDoor();
            }
            
            if(leverSolved == true)
            {
                leverDoor.renderDoor();
            }
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