using Assets.Source.Models.Game.Controllers;
using Assets.Source.Models.Game.Managers.Input;
using Assets.Source.Models.Game.Managers.States;

namespace Assets.Source.Models.Game
{
    public class InvaderGame
    {
        private readonly GameData _gameData;
        private readonly IStateManager _stateManager;
        private readonly IGameInputManager _inputManager;

        public InvaderGame(IEnemiesSpawner enemiesSpawner, IPlayerSpawner playerSpawner, IRockSpawner rockSpawner, 
            IStateManager state, IGameInputManager input, IEnemyController enemyController)
        {
            _gameData = new GameData
            {
                EnemiesSpawner = enemiesSpawner,
                PlayerSpawner = playerSpawner,
                RockSpawner = rockSpawner,
                EnemyController = enemyController
            };

            _stateManager = state;
            _inputManager = input;

            _stateManager.Initialize(_gameData);
        }

        public void UpdateGame()
        {
            var input = _inputManager.GetInput();
            _stateManager.Update(input);
        }
    }
}
