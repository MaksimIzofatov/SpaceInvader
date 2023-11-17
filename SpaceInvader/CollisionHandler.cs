using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
	public class CollisionHandler
	{
		private readonly Player _player;
		private readonly EnemyManager _enemyManager;

		public CollisionHandler(Player player, EnemyManager enemymanager)
		{
			_player = player;
			_enemyManager = enemymanager;
		}

		private bool HasCollisionEnemyWithBullet(Enemy enemy, out Bullet bullet)
		{
			var bullets = _player.GetBullets();

			for (int i = 0; i < bullets.Count; i++)
			{
				bullet = bullets[i];

				if (enemy.GetGlobalBounds().Intersects(bullet.GetGlobalBounds()))
				{
					return true;
				}
			}

			bullet = null;
			return false;
		}

		private bool HasCollisionEnemyWithPlayer(Enemy enemy)
		{
			return _player.GetGlobalBounds().Intersects(enemy.GetGlobalBounds());
		}

		private void HandleEnemiesCollision()
		{
			var enemies = _enemyManager.Enemies;

			for (int i = 0; i < enemies.Count; i++)
			{
				if (HasCollisionEnemyWithBullet(enemies[i], out Bullet bullet))
				{
					_player.DestroyBullet(bullet);
					_enemyManager.DestroyEnemy(enemies[i]);
					i--;
					continue;
				}

				if (HasCollisionEnemyWithPlayer(enemies[i]))
				{
					_player.Destroy();
				}
			}
		}

		public void Update()
		{
			HandleEnemiesCollision();
		}
	}
}
