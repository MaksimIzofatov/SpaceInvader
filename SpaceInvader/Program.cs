using SpaceInvader;

const string GAME_CONFIGURATION_JSON_PATH = "GameConfiguration.json";
var gameConfiguration = new GameConfiguration(GAME_CONFIGURATION_JSON_PATH);

var game = new Game(gameConfiguration);
game.Run();
game.ShowGameOverScreen();

