using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using DungeonShambles.Entities;

namespace DungeonShambles
{
    class Puzzles
    {
        GameEntities main;
        List<Keys> keys = new List<Keys>();
        List<Levers> levers = new List<Levers>();
        List<RockCollision> rocks = new List<RockCollision>();
        List<TargetTest> targets = new List<TargetTest>();
		List<int> roomValues = new List<int>();
		int LeversSolved = 0;
		int keysSolved = 0;
		int targetsSolved = 0;

        public Puzzles(GameEntities init, Dungeon dungeon)
        {
            main = init;
            Room[] rooms = dungeon.getRooms();

            List<Room> rockRooms = getRockPuzzleRooms(dungeon);
            List<Room> used = spawnRocks(rockRooms);
            Console.WriteLine("Done with rocks");

            List<Room> allRooms = new List<Room>();
            foreach (Room room in rooms)
            {
                allRooms.Add(room);
            }

            foreach (Room room in used)
            {
                allRooms.Remove(room);
            }

            used = spawnLevers(allRooms);
            Console.WriteLine("Done with levers");

            foreach (Room room in used)
            {
                allRooms.Remove(room);
            }

			for (int i = 1; i < 7; i++) {
				roomValues.Add (i);
			}

            spawnKeys(allRooms);
            Console.WriteLine("Done with keys");
        }


        public void spawnKeys(List<Room> destinations)
        {
            int keyRooms = destinations.Count();
            int count = 0;

            foreach (Room room in destinations)
            {
                if (count < keyRooms)
                {
                    Keys temp = new Keys(room, 1);
                    keys.Add(temp);
                    count++;
                }
            }
        }

        public List<Room> spawnLevers(List<Room> destinations)
        {
            int leverRooms;
            List<Room> used = new List<Room>();
            if (destinations.Count() < 4)
            {
                leverRooms = destinations.Count();
            }
            else
            {
                leverRooms = 3;
            }
            
            int count = 0;
            foreach (Room room in destinations)
            {
                if (room.getRoomWidth() < 6 || room.getRoomHeight() < 6)
                {
                    if (count < leverRooms)
                    {
                        Levers temp = new Levers(room, 1);
                        levers.Add(temp);
                        count++;
                        used.Add(room);
                    }
                }
                else if (room.getRoomWidth() < 8 || room.getRoomHeight() < 8)
                {
                    if (count < leverRooms)
                    {
                        Levers temp = new Levers(room, 2);
                        levers.Add(temp);
                        count++;
                        used.Add(room);
                    }
                }
                else if (room.getRoomWidth() < 12 || room.getRoomHeight() < 12)
                {
                    if (count < leverRooms)
                    {
                        Levers temp = new Levers(room, 3);
                        levers.Add(temp);
                        count++;
                        used.Add(room);
                    }
                }
            }
            return used;
        }

        //Gets all rooms of size 6*6 or greater
        public List<Room> getRockPuzzleRooms(Dungeon dungeon)
        {
            Room[] rooms = dungeon.getRooms(); 
            List<Room> rockRooms = new List<Room>();
            foreach (Room room in rooms)
            {
                if (room.getRoomHeight() > 5 && room.getRoomWidth() > 5)
                {
                    rockRooms.Add(room);
                }
            }

            return rockRooms;
        }

        //returns list of rooms used
        public List<Room> spawnRocks(List<Room> destinations)
        {
            int x;
            //Adjust divisor to control room frequency
            if (destinations.Count() < 3)
            {
                x = destinations.Count();
            }
            else
            {
                x = 2;
            }
            int count = 0;
            List<Room> used = new List<Room>();

            foreach (Room room in destinations)
            {
                if (room.getRoomHeight() < 7 || room.getRoomWidth() < 7)
                {
                    if (count < x)
                    {
                        RockCollision temp = new RockCollision(room, 1);
                        rocks.Add(temp);
                        int[] xValues = temp.getXValues();
                        int[] yValues = temp.getYValues();
                        targets.Add(new TargetTest(room, 1, xValues, yValues, temp));

                        count++;
                        used.Add(room);
                    }
                }
                else if (room.getRoomHeight() < 10 || room.getRoomWidth() < 10)
                {
                    if (count < x)
                    {
                        RockCollision temp = new RockCollision(room, 2);
                        rocks.Add(temp);
                        int[] xValues = temp.getXValues();
                        int[] yValues = temp.getYValues();
                        targets.Add(new TargetTest(room, 2, xValues, yValues, temp));

                        count++;
                        used.Add(room);
                    }
                }
                else if (room.getRoomHeight() <= 11 && room.getRoomWidth() <= 11)
                {
                    if (count < x)
                    {
                        RockCollision temp = new RockCollision(room, 3);
                        rocks.Add(temp);
                        int[] xValues = temp.getXValues();
                        int[] yValues = temp.getYValues();
                        targets.Add(new TargetTest(room, 3, xValues, yValues, temp));

                        count++;
                        used.Add(room);
                        
                    }

                }
            }

            return used;
        }


        public void renderPuzzles()
        {
            foreach (TargetTest test in targets)
            {
                test.renderTargets();
                test.pressTest();
            }
            foreach (RockCollision test in rocks)
            {
                test.renderRocks();
            }

            foreach (Levers test in levers)
            {
                test.renderLevers();
            }

            foreach (Keys test in keys)
            {
                test.renderKeys();
            }
        }

		public void puzzleActions()
        {
            foreach (Keys test in keys)
            {
                test.pickUpKey(main);
            }
            foreach (Levers test in levers)
            {
                test.flipLever(main);
            }
        }

		public void TargetActions(Dungeon dungeon) {
			foreach (TargetTest test in targets) 
			{
				if (test.pressTest ()) {
					openCorrectdoors (test.getRoom(), dungeon);
				}
			}

			int keysLocalSolved = 0;
			foreach (Keys test in keys) {
				if (test.checkKeys ()) {
					keysLocalSolved++;
				}
			}
			if (keysLocalSolved != keysSolved) 
			{

				openRandomizedDoor (dungeon);
				keysSolved++;
			}

			int leversLocalSolved = 0;
			foreach (Levers test in levers) {

				if (test.checkLeverFlips ()){
					leversLocalSolved++;
				}
			}
			if (leversLocalSolved != LeversSolved) {
				openRandomizedDoor (dungeon);
				LeversSolved++;
			}
		}

        public List<RockCollision> getRockCollision()
        {
            return rocks;
        }

		private void openRandomizedDoor(Dungeon dungeon) {
			Room one = dungeon.getRooms () [1];
			Room three = dungeon.getRooms () [3];
			Random rng = new Random ();
			int randomNum = rng.Next (0, roomValues.Count ());
			if (roomValues.Count != 0) {
				int index = roomValues [randomNum];
				switch (index) {
				case 1:
					one.setDoorAndAdjacentRoom (dungeon, 1, 5, 0);
					break;
				case 2:
					one.setDoorAndAdjacentRoom (dungeon, 2, 6, 0);
					break;
				case 3:
					one.setDoorAndAdjacentRoom (dungeon, 3, 7, 0);
					break;
				case 4:
					three.setDoorAndAdjacentRoom (dungeon, 1, 8, 0);
					break;
				case 5:
					three.setDoorAndAdjacentRoom (dungeon, 2, 9, 0);
					break;
				case 6:
					three.setDoorAndAdjacentRoom (dungeon, 3, 10, 0);
					break;
				}
				roomValues.Remove (index);
			}
		}

		private void openCorrectdoors(Room r, Dungeon dungeon)
		{
			if(r.getRoomNumber() == 0)
			{
				r.setDoorAndAdjacentRoom (dungeon, 1, 2, 0);
				r.setDoorAndAdjacentRoom (dungeon, 0, 1, 0);
				r.setDoorAndAdjacentRoom (dungeon, 2, 3, 0);
				r.setDoorAndAdjacentRoom (dungeon, 3, 4, 0);
			}
			if (r.getRoomNumber () == 2) {
				openRandomizedDoor (dungeon);
			}
		}
    }
}
