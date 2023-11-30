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
		private const float DEATH_ANIMATION_TIME = 0.2f;

		private readonly float _speed;
		private readonly Sprite _sprite;
		private readonly AnimationManager _animatorManager;
		public Vector2f Position => _sprite.Position;

		public Enemy(float speed, Texture texture, Vector2f spawnPosirion, AnimationManager animatorManager)
		{
			_speed = speed;
			_sprite = new Sprite(texture);
			_sprite.Position = spawnPosirion;
			_animatorManager = animatorManager;
		}

		public void PlayDeathAnimation()
		{
			var spriteHalfSize = (Vector2f)_sprite.Texture.Size / 2;
			var animationPosition = _sprite.Position - spriteHalfSize;

			var explosionAnimation = new SpriteAnimation(animationPosition, TextureManager.ExplosionAtlas, DEATH_ANIMATION_TIME);
			_animatorManager.AddAnimation(explosionAnimation);
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
