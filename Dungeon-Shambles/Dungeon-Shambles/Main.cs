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


        // Menus
        PauseMenu pauseMenu;
        Menu mmenu;
        //Inventory invMenu;
        //Stats statsMenu;

        bool displayMenu = true;
        bool displayStats = false;
        bool displayDungeon = false;
        bool displayPause = false;
        //bool displayInv = false;

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
			//TODO fix ghost
            //ghost = new Ghost(0.9f, 0.9f);
            //TODO Fix mainmenu and stats menu
            
			//projectiles
			shot = new Projectile.Projectile(mainChar);
			fired = false;
			// create a new dungeon object
			dungeon = new Dungeon (11);
            // generate a new dungeon
            dungeon.generateDungeon();

            // set the main character to the center of the dungeon
            mainChar.changeX(0.9f);
            mainChar.changeY(0.9f);
            GL.Translate(-0.9, -0.9, 0);
            
            pauseMenu = new PauseMenu();
            mmenu = new Menu();            /*
            invMenu = new Inventory();
            statsMenu = new Stats();
            */
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
			
			if(keyboard[OpenTK.Input.Key.E]) displayDungeon = true;
			if(keyboard[OpenTK.Input.Key.Escape]) displayDungeon = false;

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

            
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // clear the screen
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (displayDungeon == true)
            {
                dungeon.renderDungeon();
                // render the main character
                if (displayMenu == false && displayStats == false)
                {
                    GL.Enable(EnableCap.Blend);
                    mainChar.renderCharacter();
                    GL.Disable(EnableCap.Blend);
                }
            }
            else
            {
                mmenu.RenderMenu();
            }
            //TODO fix ghost
            //ghost.renderCharacter();

            if (fired)
                shot.renderCharacter();
            //GL.Disable(EnableCap.Blend);
            
            

             // render menus
            //if (displayMenu == true) 
            //if (displayStats == true) 
            //    statsMenu.RenderMenu();
            if (displayPause == true)
                pauseMenu.RenderMenu();
            //if (displayInv == true)
            //    invMenu.RenderMenu();
           
            // switch between the two buffer
            SwapBuffers();
        }


        protected override void OnResize(EventArgs e) { }
    }
}