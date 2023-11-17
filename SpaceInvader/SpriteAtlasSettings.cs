using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
	public class SpriteAtlasSettings
	{
		public string TexturePath { get; }
		public int Columns { get; }
		public int Rows { get; }

		public SpriteAtlasSettings(string texturePath, int columns, int rows)
		{
			TexturePath = texturePath;
			Columns = columns;
			Rows = rows;
		}
	}
}
