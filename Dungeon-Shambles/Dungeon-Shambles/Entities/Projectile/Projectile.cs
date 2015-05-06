using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonShambles.Entities;

namespace DungeonShambles
{
	public class Projectile : GameEntities
	{
		static String image = "meshes/Sword/sword.png";
		public Projectile (GameEntities shooter) :
		base (image, shooter.getX(), shooter.getY())
		{
		}
	}
}

