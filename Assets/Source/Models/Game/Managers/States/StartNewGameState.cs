
using Assets.Source.Models.Game.Actors;
using Assets.Source.Models.Game.Controllers;
using Assets.Source.Services.DI;
using System.Collections.Generic;
using UnityEngine.Assertions;

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

            var enemySpawner = DIContainer.Instance.Resolve<IEnemiesSpawner>();
            var rockSpawner = DIContainer.Instance.Resolve<IRockSpawner>();
            var playerSpawner = DIContainer.Instance.Resolve<IPlayerSpawner>();

            Assert.IsNotNull(enemySpawner);
            Assert.IsNotNull(rockSpawner);
            Assert.IsNotNull(playerSpawner);

            SpawnElement(enemySpawner, ref _gameData.Enemies);
            _gameData.Destructibles.AddRange(_gameData.Enemies);
            SpawnElement(rockSpawner, ref _gameData.Rocks);
            _gameData.Destructibles.AddRange(_gameData.Rocks);

            if (_gameData.Player != null)
            {
                _gameData.Player.Destroy();
            }
            _gameData.Player = playerSpawner.Spawn();

            _gameData.Destructibles.Add(_gameData.Player);
        }

        public void EnterState(GameData data)
        {
            _gameData = data;
            DIContainer.Instance.Resolve<IEnemyController>().Reset();
            SpawnGameElements();
            StateManager.ChangeUIState(EUIState.InGame);
        }

        public void LeaveState()
        {
        }

        public void Update(Input.EGameInput input)
        {
        }
    }
}
