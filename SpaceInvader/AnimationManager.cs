using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
	public class AnimationManager
	{
		private readonly List<SpriteAnimation> _animations = new();

		public void Update()
		{
			for (int i = 0; i < _animations.Count; i++)
			{
				_animations[i].Update();

				if (_animations[i].IsAnimationFinished)
				{
					_animations.RemoveAt(i);
					i--;
				}
			}
		}

		public void Draw(RenderWindow window)
		{
			foreach (var animation in _animations)
			{
				animation.Draw(window);
			}
		}

		public void AddAnimation(SpriteAnimation animation)
		{
			_animations.Add(animation);
		}
	}
}
