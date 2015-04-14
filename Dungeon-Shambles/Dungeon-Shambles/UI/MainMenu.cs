using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles.UI
{
    class MainMenu
    {
        TextureImporter menu = new TextureImporter();

        public MainMenu()
        {
            menu.importTexture("Images\\download.jpg");            
        }

        public void RenderMenu()
        {
            menu.renderTexture(1,0,0);
        }
    }
}
