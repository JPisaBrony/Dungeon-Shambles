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
<<<<<<< HEAD
        // texture object reference
        TextureImporter text;
        // timmer for displaying text
        int textTimer = 0;

        
        MainMenu mainMenu;
        Stats statsMenu;
        bool displayMenu = false;
        bool displayStats = false;
=======
		// texture object reference
		TextureImporter text;
		// timmer for displaying text
		int textTimer = 0;
>>>>>>> f321ec3cbab46e5314b193787b5042e561502526

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
<<<<<<< HEAD
            // enable alpha blending
            GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.DstAlpha);
=======
			// enable alpha blending
			GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.DstAlpha);
>>>>>>> f321ec3cbab46e5314b193787b5042e561502526
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
<<<<<<< HEAD
            // create text object
            text = new TextureImporter();
            // draw the text
            text.drawText("Twilight Sparkle", new Font(FontFamily.GenericSerif, 24), Brushes.White);
            

            mainMenu = new MainMenu();
            statsMenu = new Stats();

=======
			// create text object
			text = new TextureImporter ();
			// draw the text
			text.drawText ("Twilight Sparkle", new Font (FontFamily.GenericSerif, 24), Brushes.White);
>>>>>>> f321ec3cbab46e5314b193787b5042e561502526
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


            // variable for checking mouse input
            var mouse = OpenTK.Input.Mouse.GetState();

            Vector2 pos = new Vector2(0.6f, -0.2f);



            if (mouse[OpenTK.Input.MouseButton.Button1])
            {
                displayMenu = false;
            }
            if (mouse[OpenTK.Input.MouseButton.Right])
            {
                //******TO DO********* probably want to save game before exit
                Dispose();
            }

        }

<<<<<<< HEAD


=======
>>>>>>> f321ec3cbab46e5314b193787b5042e561502526
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // clear the screen
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // render the main character
            if(displayMenu == false && displayStats == false) mainChar.renderCharacter();

<<<<<<< HEAD
            // check if the timer has timed out
            if (textTimer < 100)
            {
                // enable alpha blending
                // so that the background of the text is transparent
                GL.Enable(EnableCap.Blend);
                // render text
                text.renderTexture(1f, 0.5f, -0.3f);
                // disble alpha blending
                // this step is VERY important, if alpha blending is not disabled,
                // the rest of the images will get distorted
                GL.Disable(EnableCap.Blend);
            }
            // increament timer
            textTimer++;


            // render menus
            
            if (displayMenu == true) 
                mainMenu.RenderMenu();
               
            if (displayStats == true) 
                statsMenu.RenderMenu();

=======
			// check if the timer has timed out
			if (textTimer < 100) {
				// enable alpha blending
				// so that the background of the text is transparent
				GL.Enable (EnableCap.Blend);
				// render text
				text.renderTexture (1f, 0.5f, -0.3f);
				// disble alpha blending
				// this step is VERY important, if alpha blending is not disabled,
				// the rest of the images will get distorted
				GL.Disable (EnableCap.Blend);
			}
			// increament timer
			textTimer++;
>>>>>>> f321ec3cbab46e5314b193787b5042e561502526

            // switch between the 2 buffers
            SwapBuffers();
        }

        protected override void OnResize(EventArgs e) { }
    }
}