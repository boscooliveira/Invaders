
using Assets.Source.Models.Game.Actors;
using System.Collections.Generic;

namespace Assets.Source.Models.Game.Managers.States
{
    public class StartNewGameState : IGameState
    {
        public EGameState State => EGameState.StartNewGame;
        public EGameState NextState => EGameState.InGame;

        private GameData _gameData;

        private void SpawnElement<T>(IListSpawner<T> spawner, ref IList<T> list) where T : IDestructible
        {
            if (list != null)
            {
                foreach (var destructible in list)
                {
                    destructible.Destroy();
                }
            }
            list = spawner.Spawn();
        }

        private void SpawnGameElements()
        {
            if(_gameData.Destructibles == null)
            {
                _gameData.Destructibles = new List<IDestructible>();
            }
            
            _gameData.Destructibles.Clear();

            SpawnElement(_gameData.EnemiesSpawner, ref _gameData.Enemies);
            _gameData.Destructibles.AddRange(_gameData.Enemies);
            SpawnElement(_gameData.RockSpawner, ref _gameData.Rocks);
            _gameData.Destructibles.AddRange(_gameData.Rocks);

            if (_gameData.Player != null)
            {
                _gameData.Player.Destroy();
            }
            _gameData.Player = _gameData.PlayerSpawner.Spawn();

            _gameData.Destructibles.Add(_gameData.Player);
        }

        public void EnterState(GameData data)
        {
            _gameData = data;
            _gameData.EnemyController.Reset();
            SpawnGameElements();
        }

        public void LeaveState()
        {
        }

        public void Update(Input.EGameInput input)
        {
        }
    }
}
