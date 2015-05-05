using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonShambles.Entities;

namespace DungeonShambles.Projectile
{
	public class Melee : Projectile
	{
		const String image = "melee.jpg";
		public Melee () : base (image)
		{
		}
	}
}

