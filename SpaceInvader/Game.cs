using Newtonsoft.Json;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceInvader
{
	public class Game
	{
		private readonly RenderWindow _window;
		private readonly Sprite _background;
		private readonly Player _player;
		private readonly EnemyManager _enemyManager;
		private readonly CollisionHandler _collisionHandler;

		public Game(GameConfiguration gameConfiguration)
		{
			var mode = new VideoMode((uint)gameConfiguration.Width, (uint)gameConfiguration.Height);
			_window = new RenderWindow(mode, gameConfiguration.Title);
			_window.SetVerticalSyncEnabled(true);

			_window.Closed += (_, _) => _window.Close();

			_background = new Sprite(TextureManager.BackgroundTexture);


			_player = CreatePlayer(gameConfiguration);

			var screenSize = new Vector2f(gameConfiguration.Width, gameConfiguration.Height);
			_enemyManager = new EnemyManager(gameConfiguration.EnemySpawnCooldown, gameConfiguration.EnemySpeed, screenSize);

			_collisionHandler = new CollisionHandler(_player, _enemyManager);
			//var gameJson = JsonConvert.SerializeObject(this);
			//File.WriteAllText(@"C:\!projects\SpaceInvader\SpaceInvader\GameConfiguration.json", gameJson);
		}

		public void Run()
		{
			while (_window.IsOpen && !_player.IsPlayerDead)
			{
				HandleEvents();
				Update();
				Draw();
				
			}
		}

		public void ShowGameOverScreen()
		{
			while (_window.IsOpen)
			{
				HandleEvents();
				_window.Clear(Color.Black);
				_window.Display();
			}
		}

		private Player CreatePlayer(GameConfiguration gameConfiguration)
		{
			var shootingManager = new ShoottingManager(gameConfiguration.BulletSpeed, gameConfiguration.BulletRadius, gameConfiguration.PlayerSettings.ShootingCooldown);
			var playerPosition = GetPlayerSpawnPosition(gameConfiguration, TextureManager.PlayerTexture);
			var playerMovement = new PlayerMovement(gameConfiguration.PlayerSettings);
			var shootingButton = gameConfiguration.PlayerSettings.ShootingButton;
				return new Player(shootingManager, shootingButton, TextureManager.PlayerTexture, playerPosition, playerMovement);
		}

		private Vector2f GetPlayerSpawnPosition(GameConfiguration gameConfiguration, Texture texture)
		{
			var screenCenter = new Vector2f(gameConfiguration.Width / 2f, gameConfiguration.Height / 2f);
			var playerSpawnPosition = screenCenter - (Vector2f)texture.Size / 2f;
			return playerSpawnPosition;
		}

		private void HandleEvents()
		{
			_window.DispatchEvents();
		}

		private void Update()
		{
			_player.Update();
			_enemyManager.Update();
			_collisionHandler.Update();
		}

		private void Draw()
		{
			_window.Draw(_background);
			_player.Draw(_window);
			_enemyManager.Draw(_window);

			_window.Display();
		}
	}


}
