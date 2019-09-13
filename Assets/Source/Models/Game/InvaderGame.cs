using Assets.Source.Models.Game.Managers.Input;
using Assets.Source.Models.Game.Managers.States;
using Assets.Source.Services.DI;

namespace Assets.Source.Models.Game
{
    public class InvaderGame
    {
        private readonly GameData _gameData;
        private readonly StateManager _stateManager;
        private readonly IGameInputManager _inputManager;

        public InvaderGame()
        {
            _gameData = new GameData();
            _stateManager = new StateManager();
            _inputManager = DIContainer.Instance.Resolve<IGameInputManager>();
            _stateManager.Initialize(_gameData);
        }

        public void UpdateGame()
        {
            var input = _inputManager.GetInput();
            _stateManager.Update(input);
        }
    }
}
