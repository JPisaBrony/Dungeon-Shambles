using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using DungeonShambles.UI;
using DungeonShambles.Entities;
using System.Collections.Generic;

namespace DungeonShambles
{
    class Game : GameWindow
    {
        // object references to pass between OnLoad and OnRenderFrame
        GameEntities mainChar;
		GameEntities enemy;
        Dungeon dungeon;
        NewMainMenu MainMenu;
        PauseMenu pauseMenu;
        StoryMenu storyMenu;
        ControlsMenu controlMenu;
        HUD hud;
        EndScreen endScreen;

        Puzzles puzzles;
        List<RockCollision> collisions;
        
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
			mainChar = new Player ();
            
            // create a new dungeon object
			dungeon = new Dungeon (11, 4, 10);
            // generate a new dungeon
            dungeon.generateDungeon();

			// set initial room
			mainChar.setCurrentRoom ((Room)dungeon.getRooms().GetValue(0));

            // create main menu
            MainMenu = new NewMainMenu(mainChar);
            pauseMenu = new PauseMenu(mainChar);
            storyMenu = new StoryMenu(mainChar);
            controlMenu = new ControlsMenu(mainChar);
            hud = new HUD(mainChar);
            endScreen = new EndScreen(mainChar);

            puzzles = new Puzzles(mainChar, dungeon);
            collisions = puzzles.getRockCollision();
            //currentRoom = (Room)dungeon.getRooms().GetValue(0);
            //mainChar = new Player(currentRoom);

            // set the main character to the center of the dungeon
            mainChar.setX(0.9f);
            //offsetX = 0;
            mainChar.setY(0.9f);
            //offsetY = 0;
            GL.Translate(-0.9, -0.9, 0);
			enemy = new Ghost(mainChar.getX(), mainChar.getY());
			enemy.setCurrentRoom (mainChar.getCurrentRoom());
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var keyboard = OpenTK.Input.Keyboard.GetState();
            // left key is pressed
            if (keyboard[OpenTK.Input.Key.A] && !Globals.displayMainMenu)
            {
                // change the main characters x position
				if (mainChar.changeX (-1, dungeon)) {
					// set the rotation of the player
					mainChar.setRotation (2);
					// set the player to be moving
					mainChar.setMoving (true);

					foreach (RockCollision test in collisions) {
						test.collisionTest (mainChar, 1);
					}

					// move the scene around the character in the x position
					GL.Translate (mainChar.getSpeed (), 0, 0);
				}
			}
            // right key is pressed
            else if (keyboard[OpenTK.Input.Key.D] && !Globals.displayMainMenu)
            {
                // decrease the main characters x position
				if (mainChar.changeX (1, dungeon)) {
					// set the rotation of the player
					mainChar.setRotation (3);
					// set the player to be moving
					mainChar.setMoving (true);

					foreach (RockCollision test in collisions) {
						test.collisionTest (mainChar, 2);
					}

					// move the scene around the character in the x position
					GL.Translate (mainChar.getSpeed () * -1, 0, 0);
				}
			}
            // up key is pressed
            else if (keyboard[OpenTK.Input.Key.W] && !Globals.displayMainMenu)
            {
                // change the main characters y position
				if (mainChar.changeY (1, dungeon)) {
					// set the rotation of the player
					mainChar.setRotation (1);
					// set the player to be moving
					mainChar.setMoving (true);

					foreach (RockCollision test in collisions) {
						test.collisionTest (mainChar, 3);
					}

					// move the scene around the character in the y position
					GL.Translate (0, mainChar.getSpeed () * -1, 0);
				}
			}
            // down key is pressed
            else if (keyboard[OpenTK.Input.Key.S] && !Globals.displayMainMenu)
            {
                // decrease the main characters x position
				if (mainChar.changeY (-1, dungeon)) {
					// set the rotation of the player
					mainChar.setRotation (0);
					// set the player to be moving
					mainChar.setMoving (true);

					foreach (RockCollision test in collisions) {
						test.collisionTest (mainChar, 4);
					}

					// move the scene around the character in the y position
					GL.Translate (0, mainChar.getSpeed (), 0);
				}
                // temporary key presses
            // enter key is pressed
            }
            else if (keyboard[OpenTK.Input.Key.Enter])
            {
                if (Globals.currentPage == 1)
                {
                    if (Globals.countButton == 0)
                    {
                        Globals.displayMainMenu = false;
                        Globals.displayStoryMenu = true;
                        Globals.currentPage = 0;
                    }
                    if (Globals.countButton == 1) Exit();
                }
                if (Globals.displayPauseMenu == true) // changed here
                {
                    if (Globals.countButton == 0) { Globals.displayPauseMenu = false; }
                    if (Globals.countButton == 1) Exit();
                }
            // esc key is pressed
            }
            else if (keyboard[OpenTK.Input.Key.F4])
            {
                Exit();
            // p key is pressed
            }
            else if (keyboard[OpenTK.Input.Key.P])
            {
                Globals.displayPauseMenu = true;
            }
            // down key if pressed
            else if (keyboard[OpenTK.Input.Key.Down])
            {
                if (Globals.currentPage == 1) Globals.countButton = 1;
                if (Globals.displayPauseMenu) Globals.countButton = 1;
            }// up key if pressed
            else if (keyboard[OpenTK.Input.Key.Up])
            {
                if (Globals.currentPage == 1) Globals.countButton = 0;
                if (Globals.displayPauseMenu) Globals.countButton = 0;
            }
            // right key is pressed
            else if (keyboard[OpenTK.Input.Key.Right])
            {
                Globals.currentPage++;
                if (Globals.displayStoryMenu == true) 
                {
                    Globals.displayStoryMenu = false;
                    Globals.displayEndMenu = false;
                }
                
            }// left key is pressed
            else if (keyboard[OpenTK.Input.Key.Left])
            {
                Globals.currentPage--;
            }
            else if (keyboard[OpenTK.Input.Key.Y])
            {
                Globals.displayEndMenu = false;
                Globals.displayMainMenu = true;
                Globals.currentPage = 1;
            }

            else if (keyboard[OpenTK.Input.Key.Space])
            {
                puzzles.puzzleActions();
            }
            // boundaries for main menu pages
            if (Globals.currentPage > Globals.lastPage)
                Globals.currentPage = Globals.lastPage;

            if (Globals.currentPage < 1)
                Globals.currentPage = 1;

			enemy.chase(mainChar, dungeon);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // clear the screen
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // check to see if the menu should be rendered
            if (Globals.displayMainMenu)
            {
                // display menus
                switch (Globals.currentPage)
                {
                    case 1:
                        MainMenu.renderMenu();
                        break;
                    case 2:
                        controlMenu.renderMenu();
                        break;
                }
            }
            else
            {
                if (Globals.displayStoryMenu == true)
                {
                    Globals.currentPage = 0;
                    storyMenu.renderMenu();
                }
                else
                {
                    // not on main menu
                    Globals.currentPage = 0;
                    // render the dungeon
                    dungeon.renderDungeon();
					// render the puzzles
                	puzzles.renderPuzzles();
                    // render the main character
					//GL.Enable(EnableCap.Blend);
					// render the main characters animations
					mainChar.renderAnimation (mainChar.getRotation(), Globals.TextureSize, mainChar.getX (), mainChar.getY (), mainChar.getMoving());
					enemy.renderCharacter();
					// set the character to be not moving
					mainChar.setMoving (false);

                    if (Globals.displayPauseMenu == true)
                        pauseMenu.renderMenu();
                    if (Globals.displayPauseMenu == false)
                    {
                        float currentHealth = (float)((Globals.maxHealth - mainChar.getHealth()) / Globals.maxHealth) / 2;
                        hud.drawHUD(currentHealth);

                        if (currentHealth == 0.5)
                        {
                            Globals.displayEndMenu = true;
                            endScreen.renderMenu();
                        }
                    }
					Globals.time++;
                }
            }
            // switch between the two buffer
            SwapBuffers();
        }

        protected override void OnResize(EventArgs e) { }
    }
}