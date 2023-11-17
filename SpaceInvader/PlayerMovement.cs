using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
	public class PlayerMovement
	{
		private readonly float _playerSpeed;
		private readonly Keyboard.Key _leftButton;
		private readonly Keyboard.Key _downButton;
		private readonly Keyboard.Key _upButton;
		private readonly Keyboard.Key _rightButton;

		public PlayerMovement(PlayerSettings playerSettings)
		{
			_playerSpeed = playerSettings.Speed;
			_leftButton = playerSettings.MovingLeftButton;
			_downButton = playerSettings.MovingDownButton;
			_upButton = playerSettings.MovingUpButton;
			_rightButton = playerSettings.MovingRightButton;
		}

		public Vector2f GetNewPosition(Vector2f position)
		{
			var movement = new Vector2f();
			if (Keyboard.IsKeyPressed(_leftButton))
			{
				movement.X -= 1;
			}

			if (Keyboard.IsKeyPressed(_rightButton))
			{
				movement.X += 1;
			}

			if (Keyboard.IsKeyPressed(_upButton))
			{
				movement.Y -= 1;
			}

			if (Keyboard.IsKeyPressed(_downButton))
			{
				movement.Y += 1;
			}

			position += movement.Normalize() * _playerSpeed;
			return position;
		}
	}
}
