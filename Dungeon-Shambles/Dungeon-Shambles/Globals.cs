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
		// game time variable
		public static int time = 0;
        // boolean for checking if the story menu should be displayed
        public static bool displayStoryMenu = false;
        // boolean for checking if the pause menu should be displayed
        public static bool displayPauseMenu = false;
        // boolean for checking if the end screen should be displayed
        public static bool displayEndMenu = false;
        // boolean for checking if the win screen should be displayed
        public static bool displayWinMenu = false;
        
        // current button for menu
        public static int currentButton = 0;
        public static int countButton = 0;
        
        // pages of menu
        public static int currentPage = 1;
        public static int lastPage = 2;

        public static double maxHealth = 100;
	}
}

