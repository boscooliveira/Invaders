using Assets.Source.Models.Game.Managers.Input;
using System.Collections.Generic;

namespace Assets.Source.Models.Game.Managers.States
{
    public class StateManager : IStateManager
    {
        private GameData _data;
        private readonly Dictionary<int, IGameState> _stateDictionary;
        private IGameState _gameState;

        public EGameState CurrentState => _gameState?.State ?? EGameState.Undefined;

        public StateManager()
        {
            _stateDictionary = new Dictionary<int, IGameState>
            {
                { (int)EGameState.Menu, new MenuState() },
                { (int)EGameState.StartNewGame, new StartNewGameState() },
                { (int)EGameState.InGame, new InGameState() },
            };
        }

        private void ChangeToState(EGameState gameState)
        {
            _gameState?.LeaveState();
            _gameState = _stateDictionary[(int)gameState];
            _gameState.EnterState(_data);
        }

        public void Update(EGameInput input)
        {
            if (_gameState.NextState != EGameState.Undefined)
            {
                ChangeToState(_gameState.NextState);
                return;
            }

            _gameState.Update(input);
        }

        public void Initialize(GameData data)
        {
            _data = data;
            ChangeToState(EGameState.Menu);
        }
    }
}
