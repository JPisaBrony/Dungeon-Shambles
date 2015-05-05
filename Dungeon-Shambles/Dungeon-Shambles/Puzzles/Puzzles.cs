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

            spawnKeys(allRooms);
            Console.WriteLine("Done with keys");
        }


        public void spawnKeys(List<Room> destinations)
        {
            int keyRooms = destinations.Count() / 2;
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

        public List<RockCollision> getRockCollision()
        {
            return rocks;
        }
    }
}
