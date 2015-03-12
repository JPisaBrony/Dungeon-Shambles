using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles.UI
{
    class Stats
    {
        TextureImporter statsMenu = new TextureImporter();

        public Stats()
        {
            statsMenu.importTexture("Images\\Luffy.jpg");            
        }

        public void RenderMenu()
        {
            statsMenu.renderTexture(1,0,0);
        }
    }
}
