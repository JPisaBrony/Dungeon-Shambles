using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DungeonShambles.UI
{
    class MainMenu
    {
        //TextureImporter menu = new TextureImporter();
        TextureImporter newGame = new TextureImporter();
        TextureImporter loadGame = new TextureImporter();
        TextureImporter quitGame = new TextureImporter();
        //public string text;

        // public Game gameEng;
        List<string> buttons = new List<string>();

        Font mono = new Font(FontFamily.GenericMonospace, 24);


        public MainMenu()
        {
            //menu.importTexture("Images\\download.jpg");
            /*
            buttons.Add("Play Game");
            buttons.Add("Load Game");
            buttons.Add("Quit Game");
             */

            this.RenderMenu();
        }


        public void RenderMenu()
        {
            //menu.renderTexture(0.8f, 0, 0);
           
            
            newGame.drawText("New Game", mono, Brushes.DimGray);
            loadGame.drawText("Load Game", mono, Brushes.White);
            quitGame.drawText("Quit Game", mono, Brushes.Green);


            GL.ClearColor(0f, 0f, 0f, 0f);
            GL.Enable(EnableCap.Blend);
            // render text
            newGame.renderTexture(0.95f, 0.6f, -0.2f);
            loadGame.renderTexture(0.95f, 0.6f, -0.7f);
            quitGame.renderTexture(0.95f, 0.6f, -1.2f);

            GL.Disable(EnableCap.Blend);
            
        }



    }
}
