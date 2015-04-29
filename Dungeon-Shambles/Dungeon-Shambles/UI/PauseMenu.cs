using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using QuickFont;
using System.Drawing;

namespace DungeonShambles.UI
{
    public class PauseMenu
    {
        // fields
        QFont title, buttonHighlight, button, nothing;
        List<string> buttons;

        int currentButton = 0;
        //double cnt = 0;

        OpenTK.Input.KeyboardKeyEventArgs oldState;

        TextureImporter text1;



        public PauseMenu()
        {

            oldState = new OpenTK.Input.KeyboardKeyEventArgs();

            // gray bkgd color
            GL.ClearColor(0.2f, 0.2f, 0.2f, 1.0f);

            text1 = new TextureImporter();
            text1.importTexture("Images/800x60.jpg");

            buttons = new List<string>();
            buttons.Add("Resume");
            buttons.Add("Save Game");
            buttons.Add("Quit");

            button = QFont.FromQFontFile("UI/Fonts/woodenFont.qfont", 1.0f, new QFontLoaderConfiguration(true));
            button.Options.DropShadowActive = true;
            buttonHighlight = QFont.FromQFontFile("UI/Fonts/woodenFont.qfont", 1.0f, new QFontLoaderConfiguration(true));
            buttonHighlight.Options.DropShadowActive = true;
            button.Options.Colour = new Color4(0.7f, 0.7f, 0.7f, 1.0f);

            title = new QFont("UI/Fonts/Dungeon.TTF", 80, FontStyle.Regular);
            title.Options.Colour = new Color4(0.7f, 0.7f, 0.7f, 1.0f);
            title.Options.DropShadowActive = true;

            nothing = new QFont("UI/Fonts/Rock.TTF", 1, FontStyle.Regular);

            GL.Disable(EnableCap.DepthTest);
        }


        public void Update()
        {
            KeyState();
        }


        public void RenderMenu()
        {
            // clear color and depth buffer
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);


            GL.ClearColor(0.3f, 0.5f, 0.5f, 1.0f);

            float yOffset = 25;
            float noOffset = 0;
            int count = 0;

            //******* DOES NOTHING START REGION, FOR SOME REASON, ALLOWS BKGROUND PIC TO BE RENDERED?
            QFont.Begin();
            GL.PushMatrix();
            GL.Translate(Globals.WindowWidth * 0.5f, noOffset, 0f);
            nothing.Print("NO", QFontAlignment.Centre);
            GL.PopMatrix();
            QFont.End();
            //******* DOES NOTHING END REGION

            text1.renderTexture(1.0f, 0f, 0f);

            QFont.Begin();
            // push current matrix stack
            GL.PushMatrix();
            GL.Translate(Globals.WindowWidth * 0.5f, yOffset, 0f);
            title.Print("Pause Menu", QFontAlignment.Centre);
            GL.PopMatrix();

            yOffset += 175;
            foreach (string s in buttons)
            {
                if (count == currentButton)
                {
                    GL.PushMatrix();
                    buttonHighlight.Options.Colour = new Color4(3.0f, 0.0f, 1.5f, 1.9f);
                    GL.Translate(Globals.WindowWidth * 0.5f, yOffset, 0f);
                    buttonHighlight.Print(s, QFontAlignment.Centre);

                    GL.PopMatrix();
                }
                else
                {
                    GL.PushMatrix();
                    button.Options.DropShadowActive = false;
                    button.Print(s, QFontAlignment.Centre, new Vector2(Globals.WindowWidth * 0.5f, yOffset));
                    GL.PopMatrix();
                }
                yOffset += button.Measure(s).Height + (50);
                count++;
            }

            QFont.End();

            GL.Disable(EnableCap.Texture2D);
        }


        private void KeyState()
        {
            OpenTK.Input.KeyboardKeyEventArgs newState = new KeyboardKeyEventArgs();

            switch (newState.Key)
            {
                case Key.Up:
                    {
                        if (currentButton != 0)
                            currentButton--;
                    }
                    break;


                case Key.Down:
                    {
                        if (currentButton < 2)
                            currentButton++;
                    }
                    break;
            }

            oldState = newState;
        }
    }
}
