﻿using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpaceInvader
{
	public class TextLabel
	{
		private const string FONT_PATH = "C:\\!projects\\SpaceInvader\\SpaceInvader\\Assets\\Fonts\\";
		private readonly Text _text;

		public TextLabel(string text, string fontName, uint fontSize, Color textColor, Vector2f textPosition)
		{
			var font = new Font(FONT_PATH + fontName + ".ttf");
			_text = new Text(text, font, fontSize);
			_text.FillColor = textColor;

			var bounds = _text.GetLocalBounds();
			var centerX = textPosition.X - bounds.Left - bounds.Width / 2f;
			var centerY = textPosition.Y - bounds.Top - bounds.Height / 2f;
			_text.Position = new Vector2f(centerX, centerY);
		}

		public void UpdateText(string text)
		{
			_text.DisplayedString = text;
		}

		public void Draw(RenderWindow window)
		{
			window.Draw(_text);
		}
	}
}
