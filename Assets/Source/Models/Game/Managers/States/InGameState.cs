
using Assets.Source.Models.Game.Actors;

namespace Assets.Source.Models.Game.Managers.States
{
    public class InGameState : IGameState
    {
        public EGameState State => EGameState.InGame;
        public EGameState NextState { get; private set; }
        private GameData _gameData;
        private int _totalEnemies;

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
                    NextState = EGameState.GameOver;
                    break;
                case IEnemy enemy:
                    if (--_totalEnemies == 0)
                    {
                        NextState = EGameState.NewStage;
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
            //TODO: Update Enemies/Player/Bullets
            //TODO: Check Pause
            _gameData.EnemyController.UpdateEnemiesPositions(_gameData.Enemies);
            var bullets = _gameData.EnemyController.GetEnemiesBullets();
            _gameData.BulletController.UpdateBulletPositions(bullets);
            _gameData.Player.UpdatePosition(input);
            _gameData.BulletController.UpdateBulletPositions(_gameData.Player.GetBullets());
        }
    }
}
