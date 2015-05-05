using System;
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
		Dungeon dungeon;
        Room currentRoom;
        float offsetX;
        float offsetY;
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

			GL.BlendFunc (BlendingFactorSrc.One, BlendingFactorDest.DstAlpha);
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

			//TODO fix ghost
            //ghost = new Ghost(0.9f, 0.9f);
            //TODO Fix mainmenu and stats menu
            //mainMenu = new MainMenu();
            //statsMenu = new Stats();
			//projectiles
			//shot = new Projectile.Projectile(mainChar);
			//fired = false;
			// create a new dungeon object
			dungeon = new Dungeon (11, 4, 10);

			// generate a new dungeon
			dungeon.generateDungeon ();
            currentRoom = (Room)dungeon.getRooms().GetValue(0);
            mainChar = new Player(currentRoom);

            // set the main character to the center of the dungeon
            mainChar.setX(0.9f);
            offsetX = 0;
            mainChar.setY(0.9f);
            offsetY = 0;
            GL.Translate(-0.9, -0.9, 0);
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
                
                // change the main characters x position
                if (mainChar.changeX(-1, dungeon))
                {
                    // move the scene around the character in the x position
                    GL.Translate(mainChar.getSpeed(), 0, 0); 

                }
			}
            // right key is pressed
			else if (keyboard [OpenTK.Input.Key.D]) {

                // decrease the main characters x position
                if (mainChar.changeX(1, dungeon))
                {
                    // move the scene around the character in the x position
                    GL.Translate(mainChar.getSpeed() * -1, 0, 0);
                }
			}
            // up key is pressed
			else if (keyboard [OpenTK.Input.Key.W]) {
                
                // change the main characters y position
                if (mainChar.changeY(1, dungeon))
                {
                    
                    // move the scene around the character in the y position
                    GL.Translate(0, mainChar.getSpeed() * -1, 0);

                }
			}
            // down key is pressed
			else if (keyboard [OpenTK.Input.Key.S]) {
                collisionTests.setCurrentRoom(mainChar, 0, dungeon);
                // decrease the main characters x position
                if (mainChar.changeY(-1, dungeon))
                {
                    // move the scene around the character in the y position
                    GL.Translate(0, mainChar.getSpeed(), 0);
                }
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
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // clear the screen
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			dungeon.renderDungeon ();
			GL.Enable (EnableCap.Blend);
            // render the main character
            mainChar.renderCharacter();
			GL.Disable (EnableCap.Blend);

            //TODO fix ghost
            //ghost.renderCharacter();


			if (fired)
				shot.renderCharacter ();
			GL.Disable (EnableCap.Blend);
            // render menus
            if (displayMenu == true) mainMenu.RenderMenu();
            if (displayStats == true) statsMenu.RenderMenu();

            // switch between the 2 buffers
            SwapBuffers();
        }

        protected override void OnResize(EventArgs e) { }
    }
}