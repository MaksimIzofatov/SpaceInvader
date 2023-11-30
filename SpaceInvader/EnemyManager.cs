using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
	public class EnemyManager
	{
		private readonly float _spawnCooldown;
		private readonly Clock _clock = new();
		private readonly float _enemySpeed;
		private readonly Vector2f _screenSize;
		private readonly Random _random = new();
		private readonly AnimationManager _animatorManager;

		public List<Enemy> Enemies { get; } = new();

		public EnemyManager(float spawnCooldown, float enemySpeed, Vector2f screenSize, AnimationManager animatorManager)
		{
			_spawnCooldown = spawnCooldown;
			_enemySpeed = enemySpeed;
			_screenSize = screenSize;
			_animatorManager = animatorManager;
		}

		private void SpanwEnemy()
		{
			var lastEnemySpawn = _clock.ElapsedTime.AsSeconds();

			if(lastEnemySpawn < _spawnCooldown)
			{
				return;
			}

			var randomPositionX = _random.Next(0, (int)_screenSize.X);
			var enemyTexture = TextureManager.EnemyTexture;
			var spawnPosition = new Vector2f(randomPositionX, -enemyTexture.Size.Y);
			var enemy = new Enemy(_enemySpeed, enemyTexture, spawnPosition, _animatorManager);
			Enemies.Add(enemy);
			_clock.Restart();
		} 

		public void Update()
		{
			SpanwEnemy();
			UpdateEnemies();
		}

		private void UpdateEnemies()
		{
			for (int i = 0; i < Enemies.Count; i++)
			{
				Enemies[i].Update();

				if (IsEnemyOutOfScreen(Enemies[i]))
				{
					Enemies.RemoveAt(i);
					i--;
				}
			}
		}

		public void Draw(RenderWindow window)
		{
			foreach (var enemy in Enemies)
			{
				enemy.Draw(window);
			}
		}

		private bool IsEnemyOutOfScreen(Enemy enemy)
		{
			return _screenSize.Y < enemy.Position.Y;
		}

		public void DestroyEnemy(Enemy enemy)
		{
			enemy.PlayDeathAnimation();
			Enemies.Remove(enemy);
		}
	}
}
