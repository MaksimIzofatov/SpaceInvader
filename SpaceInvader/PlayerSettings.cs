using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
	public class PlayerSettings
	{
		public float Speed { get; init; }
		public Keyboard.Key MovingLeftButton { get; init; }
		public Keyboard.Key MovingRightButton { get; init; }
		public Keyboard.Key MovingUpButton { get; init; }
		public Keyboard.Key MovingDownButton { get; init; }
		public Keyboard.Key ShootingButton { get; init; }
		public float ShootingCooldown { get; init; }
	}
}
