using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
	public class Player
	{
		private readonly Sprite _sprite;
		private readonly ShoottingManager _shootingManager;
		private readonly Keyboard.Key _shootingButton;
		private readonly PlayerMovement _playerMovement;

		public bool IsPlayerDead { get; private set; }

		public Player(ShoottingManager shoottingManager, Keyboard.Key shootingButton, Texture texture, Vector2f playerPosition, PlayerMovement playerMovement)
		{
			_sprite = new Sprite(texture);
			_sprite.Position = playerPosition;
			_shootingManager = shoottingManager;
			_shootingButton = shootingButton;
			_playerMovement = playerMovement;
		}

		public FloatRect GetGlobalBounds()
		{
			return _sprite.GetGlobalBounds();
		}

		public void Destroy()
		{
			IsPlayerDead = true;
		}

		public List<Bullet> GetBullets()
		{
			return _shootingManager.Bullets;
		}

		public void DestroyBullet(Bullet bullet)
		{
			_shootingManager.Bullets.Remove(bullet);
		}

		private Vector2f GetBulletSpawnPosition()
		{
			var halfSizeSprite = new Vector2f(_sprite.TextureRect.Width / 2f, 0f);
			var bulletPosition = _sprite.Position + halfSizeSprite;
			return bulletPosition;
		}

		public void Draw(RenderWindow window)
		{
			window.Draw(_sprite);
			_shootingManager.Draw(window);
		}

		private void Move()
		{
			var position = _playerMovement.GetNewPosition(_sprite.Position);

			_sprite.Position = position;
		}

		public void Update()
		{
			Move();

			if (Keyboard.IsKeyPressed(_shootingButton))
			{
				_shootingManager.TryShoot(GetBulletSpawnPosition());
			}

			_shootingManager.Update();
				
		}
	}

	
}
