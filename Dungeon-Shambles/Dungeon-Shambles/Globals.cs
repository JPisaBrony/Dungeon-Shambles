using System;

namespace DungeonShambles
{
	public abstract class Globals
	{
		// the windows width and height
		public static int WindowWidth = 800, WindowHeight = 640;
		// size of all textures
		public static float TextureSize = 0.1f;
		
        // boolean for checking if the main menu should be displayed
        public static bool displayMainMenu = true;
        // boolean for checking if the story menu should be displayed
        public static bool displayStoryMenu = false;
        // boolean for checking if the pause menu should be displayed
        public static bool displayPauseMenu = false;
        
        // current button for menu
        public static int currentButton = 0;
        public static int countButton = 0;
        
        // pages of menu
        public static int currentPage = 1;
        public static int lastPage = 2;
        public static int pausePage = 0;
	}
}

