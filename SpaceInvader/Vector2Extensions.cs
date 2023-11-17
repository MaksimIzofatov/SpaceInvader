using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
	public static class Vector2Extensions
	{
		public static Vector2f Normalize(this Vector2f vector)
		{
			var length = (float)Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
			if (length != 0)
			{
				vector /= length; 
			}

			return vector;
		}
	}
}
