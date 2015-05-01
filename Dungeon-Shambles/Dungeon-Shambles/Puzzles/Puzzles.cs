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
        public Puzzles(MainCharacter init)
        {
            keys = new Keys();
            levers = new Levers();
            rocks = new RockCollision();
            targets = new TargetTest();
            main = init;
        }

        public void renderPuzzles()
        {
            Keys.renderKeys();
            Levers.renderLevers();
            TargetTest.renderTargets();
            RockCollision.renderRocks();
            TargetTest.pressTest(RockCollision.getRocks());
        }

        public void puzzleActions()
        {
            Levers.flipLever(main);
            Keys.pickUpKey(main);
        }
    }
}
