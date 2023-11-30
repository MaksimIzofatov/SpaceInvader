using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
	public class ScoreManagerSettings
	{
		public int ScorePerEnemy { get; init; }
		public float PositionX { get; init; }
		public float PositionY { get; init; }
		public string FontName { get; init; }
		public uint FontSize { get; init; }
		public Color FontColor { get; init; }
	}
}
