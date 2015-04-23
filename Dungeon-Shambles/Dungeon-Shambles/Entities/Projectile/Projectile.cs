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

		public void track ()
		{
			if (getX() > x)
				changeX(speed);
			if (getX() < x)
				changeX(speed*-1);
			if (getY() > y)
				changeY(speed);
			if (getY() < y)
				changeY(speed*-1);
		}


	}
}

