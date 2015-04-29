using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonShambles.Entities;

namespace DungeonShambles.Projectile
{
	public class Magic : Projectile
	{
		const String image = "magic.jpg";
		public Magic () : base (image)
		{
		}
	}
}

