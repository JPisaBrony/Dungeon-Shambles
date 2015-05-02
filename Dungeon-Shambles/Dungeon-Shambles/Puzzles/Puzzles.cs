using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Room[] rooms = dungeon.getRooms();
            keys = new Keys(rooms[1]);
            levers = new Levers(rooms[3]);
            rocks = new RockCollision(rooms[2]);
            targets = new TargetTest(rooms[2]);
            main = init;
        }

        public void renderPuzzles()
        {
            keys.renderKeys();
            levers.renderLevers();
            targets.renderTargets();
            rocks.renderRocks();
            targets.pressTest(RockCollision.getRocks());
        }

        public void puzzleActions()
        {
            levers.flipLever(main);
            keys.pickUpKey(main);
        }
    }
}
