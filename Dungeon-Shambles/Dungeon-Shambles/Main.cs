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
        Enemy enemy;
        Dungeon dungeon;
        NewMainMenu MainMenu;
        PauseMenu pauseMenu;
        StoryMenu storyMenu;
        ControlsMenu controlMenu;
        HUD hud;

        string enemyPath = "Images/ghost.png";

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
            enemy = new Enemy(enemyPath, mainChar.getX() + 1.5f, mainChar.getY() + 1.5f);

            // create a new dungeon object
            dungeon = new Dungeon(11);
            // generate a new dungeon
            dungeon.generateDungeon();

            // create main menu
            MainMenu = new NewMainMenu(mainChar);
            pauseMenu = new PauseMenu(mainChar);
            storyMenu = new StoryMenu(mainChar);
            controlMenu = new ControlsMenu(mainChar);
            hud = new HUD(mainChar);

            // set the main character to the center of the dungeon
            mainChar.changeX(0.9f);
            mainChar.changeY(0.9f);
            GL.Translate(-0.9, -0.9, 0);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var keyboard = OpenTK.Input.Keyboard.GetState();
            // left key is pressed
            if (keyboard[OpenTK.Input.Key.A] && !Globals.displayMainMenu)
            {
                // change the main characters x position
                mainChar.changeX(-1 * mainChar.getSpeed());
                // move the scene around the character in the x position
                GL.Translate(mainChar.getSpeed(), 0, 0);
            }
            // right key is pressed
            else if (keyboard[OpenTK.Input.Key.D] && !Globals.displayMainMenu)
            {
                // decrease the main characters x position
                mainChar.changeX(mainChar.getSpeed());
                // move the scene around the character in the x position
                GL.Translate(mainChar.getSpeed() * -1, 0, 0);
            }
            // up key is pressed
            if (keyboard[OpenTK.Input.Key.W] && !Globals.displayMainMenu)
            {
                // change the main characters y position
                mainChar.changeY(mainChar.getSpeed());
                // move the scene around the character in the y position
                GL.Translate(0, mainChar.getSpeed() * -1, 0);
            }
            // down key is pressed
            else if (keyboard[OpenTK.Input.Key.S] && !Globals.displayMainMenu)
            {
                // decrease the main characters x position
                mainChar.changeY(-1 * mainChar.getSpeed());
                // move the scene around the character in the y position
                GL.Translate(0, mainChar.getSpeed(), 0);
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
                        Globals.storyPage = 1;
                        Globals.currentPage = 0;
                    }
                    if (Globals.countButton == 1) Exit();
                }
                if (Globals.pausePage == 1)
                {
                    if (Globals.countButton == 0) { Globals.pausePage = 0; Globals.displayPauseMenu = false; }
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
                Globals.pausePage = 1;
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
                if (Globals.storyPage == 1)
                {
                    Globals.displayStoryMenu = false;
                }
            }// left key is pressed
            else if (keyboard[OpenTK.Input.Key.Left])
            {
                Globals.currentPage--;
            }

            // boundaries for main menu pages
            if (Globals.currentPage > Globals.lastPage)
                Globals.currentPage = Globals.lastPage;

            if (Globals.currentPage < 1)
                Globals.currentPage = 1;

            enemy.chase(mainChar);
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
                    // render the main character
                    GL.Enable(EnableCap.Blend);
                    mainChar.renderCharacter();
                    enemy.renderEnemy();
                    GL.Disable(EnableCap.Blend);
                    if (Globals.displayPauseMenu == true)
                        pauseMenu.renderMenu();
                    
                    
                    hud.drawHUD(0);
                }
            }

            // switch between the two buffer
            SwapBuffers();
        }

        protected override void OnResize(EventArgs e) { }
    }
}