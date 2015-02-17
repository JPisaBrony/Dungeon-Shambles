using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using DungeonShambles.UI;

namespace DungeonShambles
{
    class Game : GameWindow
    {
        // object reference to pass between OnLoad and OnRenderFrame
        MainCharacter mainChar;
        MainMenu mainMenu;
        Stats statsMenu;
        bool displayMenu = false;
        bool displayStats = false;

        // setup the window width and height
        public Game() : base(Globals.WindowWidth, Globals.WindowHeight) { }

        public static void Main(string[] args)
        {
            using (Game game = new Game())
            {
                // run the game at 30 frames per second
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
            mainChar = new MainCharacter();
            mainMenu = new MainMenu();
            statsMenu = new Stats();

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // variable for checking keyboard input
            var keyboard = OpenTK.Input.Keyboard.GetState();
            // left key is pressed
            if (keyboard[OpenTK.Input.Key.A])
                // increase the main characters x position
                mainChar.increaseX(-0.01f);
            // right key is pressed
            else if (keyboard[OpenTK.Input.Key.D])
                // decrease the main characters x position
                mainChar.increaseX(0.01f);
            // up key is pressed
            if (keyboard[OpenTK.Input.Key.W])
                // increase the main characters y position
                mainChar.increaseY(0.01f);
            // down key is pressed
            else if (keyboard[OpenTK.Input.Key.S])
                // decrease the main characters x position
                mainChar.increaseY(-0.01f);
            // if e key is pressed, opens menu; escape to close
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

            // render the main character
            mainChar.renderCharacter();

            // render menus
            if (displayMenu == true) mainMenu.RenderMenu();
            if (displayStats == true) statsMenu.RenderMenu();

            // switch between the 2 buffers
            SwapBuffers();
        }

        protected override void OnResize(EventArgs e) { }
    }
}