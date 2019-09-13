
using Assets.Source.Models.Game.Actors;
using Assets.Source.Models.Game.Controllers;
using Assets.Source.Services.DI;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Assets.Source.Models.Game.Managers.States
{
    public class InGameState : IGameState
    {
        public EGameState State => EGameState.InGame;
        public EGameState NextState { get; private set; }
        private GameData _gameData;
        private int _totalEnemies;
        private CollisionController _collisionController;
        private bool _pause;

        public InGameState()
        {
            _collisionController = new CollisionController();
        }

        public void EnterState(GameData data)
        {
            _gameData = data;
            NextState = EGameState.Undefined;

            _totalEnemies = 0;
            foreach (var enemy in data.Enemies)
            {
                if(!enemy.IsDestroyed)
                {
                    _totalEnemies++;
                }
            }

            foreach (var destructible in data.Destructibles)
            {
                if(!destructible.IsDestroyed)
                {
                    destructible.ObjectDestroyed += OnDestroy;
                }
            }
            StateManager.ChangeUIState(EUIState.InGame);
        }

        public void OnDestroy(IDestructible destructible)
        {
            destructible.ObjectDestroyed -= OnDestroy;
            switch (destructible)
            {
                case IPlayer player:
                    NextState = EGameState.Lose;
                    break;
                case IEnemy enemy:
                    if (--_totalEnemies == 0)
                    {
                        NextState = EGameState.Win;
                    }
                    break;
            }
        }

        public void LeaveState()
        {
            foreach (var destructible in _gameData.Destructibles)
            {
                destructible.ObjectDestroyed -= OnDestroy;
            }
        }

        public void Update(Input.EGameInput input)
        {
            if(input == Input.EGameInput.Enter)
            {
                _pause = !_pause;
                StateManager.ChangeUIState(_pause ? EUIState.Pause : EUIState.InGame);
            }

            if(_pause)
            {
                return;
            }

            var enemyController = DIContainer.Instance.Resolve<IEnemyController>();
            var bulletController = DIContainer.Instance.Resolve<IBulletController>();
            Assert.IsNotNull(enemyController);
            Assert.IsNotNull(bulletController);

            enemyController.UpdateEnemiesPositions(_gameData.Enemies);
            var enemiesBullets = enemyController.GetEnemiesBullets();
            bulletController.UpdateBulletPositions(enemiesBullets);

            _gameData.Player.UpdatePosition(input);
            var playerBullets = _gameData.Player.GetBullets();
            bulletController.UpdateBulletPositions(playerBullets);

            _collisionController.UpdateInGameCollisions(_gameData, enemiesBullets, playerBullets);
        }
    }
}
