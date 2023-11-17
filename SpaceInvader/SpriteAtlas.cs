using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
	public class SpriteAtlas
	{
		private readonly Texture _atlasTexture;
		private readonly int _columns;
		private readonly int _singleSpriteWidth;
		private readonly int _singleSpriteHeight;


		public SpriteAtlas(SpriteAtlasSettings atlasSettings)
		{
			_atlasTexture = new Texture(atlasSettings.TexturePath);
			_columns = atlasSettings.Columns;
			var rows = atlasSettings.Rows;

			_singleSpriteWidth = (int)(_atlasTexture.Size.X / rows);
			_singleSpriteHeight = (int)(_atlasTexture.Size.Y / _columns);
		}

		public Sprite GetSprite(int currentIndex)
		{
			var rowIndex = currentIndex / _columns;
			var columnIndex = currentIndex % _columns;
			var intRect = new IntRect(columnIndex * _singleSpriteWidth, rowIndex * _singleSpriteHeight, _singleSpriteWidth, _singleSpriteHeight);
			return new Sprite(_atlasTexture, intRect);
		}
	}
}
