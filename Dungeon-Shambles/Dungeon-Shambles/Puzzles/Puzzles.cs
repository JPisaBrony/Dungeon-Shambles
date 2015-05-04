using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DungeonShambles
{
    class Puzzles
    {
        MainCharacter main;
        Keys keys;
        Levers levers;
        RockCollision rocks;
        TargetTest targets;
        public Puzzles(MainCharacter init, Dungeon dungeon)
        {
            main = init;
            Room[] rooms = dungeon.getRooms();

            List <Room> rockTargetRooms = new List <Room> ();
            foreach (Room room in rooms)
            {
                if (room.getRoomHeight() > 7 && room.getRoomWidth() > 7)
                {
                    rockTargetRooms.Add(room);
                }
            }

            Random rand = new Random();

            int rockTargetRoom = rand.Next(0, rockTargetRooms.Count);
            rocks = new RockCollision(rockTargetRooms[rockTargetRoom]);
            targets = new TargetTest(rockTargetRooms[rockTargetRoom]);


            List<Room> leverRooms = new List<Room>();
            foreach (Room room in rooms)
            {
                if (room.getRoomWidth() > 5 && !(room.Equals(rockTargetRooms[rockTargetRoom])))
                {
                    leverRooms.Add(room);
                }
            }
            
            int leverRoom = rand.Next(0, leverRooms.Count);
            levers = new Levers(leverRooms[leverRoom]);


            List<Room> keyRooms = new List<Room>();
            foreach (Room room in rooms)
            {
                if (!(room.Equals(leverRooms[leverRoom]))&& !(room.Equals(rockTargetRooms[rockTargetRoom])))
                {
                    keyRooms.Add(room);
                }
            }

            int keyRoom = rand.Next(0, keyRooms.Count);
            keys = new Keys(keyRooms[keyRoom]);

            

            
          
        }

        public void renderPuzzles()
        {
            keys.renderKeys();
            levers.renderLevers();
            targets.renderTargets();
            rocks.renderRocks();
            targets.pressTest(rocks.getRocks());
        }

        public void puzzleActions()
        {
            levers.flipLever(main);
            keys.pickUpKey(main);
        }

        public RockCollision getRockCollision()
        {
            return rocks;
        }
    }
}
