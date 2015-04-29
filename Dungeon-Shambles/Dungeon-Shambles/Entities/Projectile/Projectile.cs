using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonShambles.Entities;

namespace DungeonShambles.Projectile
{
	public class Projectile : GameEntities
	{
		static String image = "ghost.png";
		public Projectile (GameEntities shooter) :
		base (image, shooter.getX(), shooter.getY())
		{
		}
	}
}

