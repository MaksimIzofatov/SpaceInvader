using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
	public static class TextureManager
	{
		private const string ASSETS_PATH = "C:\\!projects\\SpaceInvader\\SpaceInvader\\Assets";
		private const string BACKGROUND_TEXTURE_PATH = "\\Backgrounds\\greenBG.png";
		private const string PLAYER_TEXTURE_PATH = "\\Ships\\playerShip3_blue.png";
		private const string ENEMY_TEXTURE_PATH = "\\Enemies\\enemyGreen1.png";
		private const string EXPLOSIONS_SPRITE_ATLAS_PATH = "\\Explosions\\explosionsAtlas.png";

		public static readonly Texture BackgroundTexture;
		public static readonly Texture PlayerTexture;
		public static readonly Texture EnemyTexture;
		public static readonly SpriteAtlas ExplosionAtlas;

		private static readonly SpriteAtlasSettings ExplosionAtlasSettings = new(ASSETS_PATH + EXPLOSIONS_SPRITE_ATLAS_PATH, 4, 4);

		static TextureManager()
		{
			BackgroundTexture = new Texture(ASSETS_PATH + BACKGROUND_TEXTURE_PATH);
			PlayerTexture = new Texture(ASSETS_PATH + PLAYER_TEXTURE_PATH);
			EnemyTexture = new Texture(ASSETS_PATH + ENEMY_TEXTURE_PATH);
			ExplosionAtlas = new SpriteAtlas(ExplosionAtlasSettings);
		}
	}
}
