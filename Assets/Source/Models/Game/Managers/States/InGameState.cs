
using Assets.Source.Models.Game.Actors;
using Assets.Source.Models.Game.Controllers;
using System.Collections.Generic;

namespace Assets.Source.Models.Game.Managers.States
{
    public class InGameState : IGameState
    {
        public EGameState State => EGameState.InGame;
        public EGameState NextState { get; private set; }
        private GameData _gameData;
        private int _totalEnemies;
        private CollisionController _collisionController;

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
        }

        public void OnDestroy(IDestructible destructible)
        {
            destructible.ObjectDestroyed -= OnDestroy;
            switch (destructible)
            {
                case IPlayer player:
                    NextState = EGameState.Menu;
                    break;
                case IEnemy enemy:
                    if (--_totalEnemies == 0)
                    {
                        NextState = EGameState.Menu;
                    }
                    else
                    {
                        //TODO: update enemies speed
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
            _gameData.EnemyController.UpdateEnemiesPositions(_gameData.Enemies);
            var enemiesBullets = _gameData.EnemyController.GetEnemiesBullets();
            _gameData.BulletController.UpdateBulletPositions(enemiesBullets);

            _gameData.Player.UpdatePosition(input);
            var playerBullets = _gameData.Player.GetBullets();
            _gameData.BulletController.UpdateBulletPositions(playerBullets);

            _collisionController.UpdateInGameCollisions(_gameData, enemiesBullets, playerBullets);
        }
    }
}
