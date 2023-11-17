using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
	public class Bullet
	{
		private readonly float _bulletSpeed;
		private readonly CircleShape _bulletShape;

		public Vector2f Position => _bulletShape.Position;

		public Bullet(Vector2f position, float bulletSpeed, float bulletRadius)
		{
			_bulletSpeed = bulletSpeed;
			_bulletShape = new CircleShape(bulletRadius);
			_bulletShape.FillColor = Color.Yellow;
			_bulletShape.Position = position;
		}

		public FloatRect GetGlobalBounds()
		{
			return _bulletShape.GetGlobalBounds();
		}

		public void Update()
		{
			var currentPosition = _bulletShape.Position;
			currentPosition.Y -= _bulletSpeed;
			_bulletShape.Position = currentPosition;
		}

		public void Draw(RenderWindow window)
		{
			window.Draw(_bulletShape);
		}
	}
}
