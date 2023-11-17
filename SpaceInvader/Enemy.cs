using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
	public class Enemy
	{
		private readonly float _speed;
		private readonly Sprite _sprite;

		public Vector2f Position => _sprite.Position;

		public Enemy(float speed, Texture texture, Vector2f spawnPosirion)
		{
			_speed = speed;
			_sprite = new Sprite(texture);
			_sprite.Position = spawnPosirion;

		}

		private void Move()
		{
			_sprite.Position += new Vector2f(0, _speed);
		}

		public FloatRect GetGlobalBounds()
		{
			return _sprite.GetGlobalBounds();
		}

		public void Update()
		{
			Move();
		}

		public void Draw(RenderWindow window)
		{
			window.Draw(_sprite);
		}
	}
}
