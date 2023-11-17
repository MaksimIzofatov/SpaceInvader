using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
	public class ShoottingManager
	{
		private readonly float _bulletSpeed;
		private readonly float _bulletRadius;
		private readonly float _shootingCooldown;
		private readonly Clock _clock;

		public List<Bullet> Bullets { get; } = new();

		public ShoottingManager(float bulletSpeed, float bulletRadius, float shootingCooldown)
		{
			_bulletSpeed = bulletSpeed;
			_bulletRadius = bulletRadius;
			_shootingCooldown = shootingCooldown;

			_clock = new Clock();
		}

		public void TryShoot(Vector2f bulletSpawnPosition)
		{
			var lastShotTime = _clock.ElapsedTime.AsSeconds();
			if (lastShotTime >= _shootingCooldown)
			{
				var bullet = new Bullet(bulletSpawnPosition, _bulletSpeed, _bulletRadius);
				Bullets.Add(bullet);

				_clock.Restart();
			}
		}
		
		private bool IsBulletOutOfScreen(Bullet bullet)
		{
			return bullet.Position.Y < 0;
		}

		public void Update()
		{
			for (int i = 0; i < Bullets.Count; i++)
			{
				Bullets[i].Update();

				if (IsBulletOutOfScreen(Bullets[i]))
				{
					Bullets.RemoveAt(i);
					i--;
				}
			}
		}

		public void Draw(RenderWindow window)
		{
			for (int i = 0; i < Bullets.Count; i++)
			{
				Bullets[i].Draw(window);
			}
		}
	}
}
