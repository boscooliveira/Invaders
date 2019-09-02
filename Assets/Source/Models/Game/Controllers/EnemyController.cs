using Assets.Source.Models.Configs;
using Assets.Source.Models.Game.Actors;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Models.Game.Controllers
{
    public class EnemyController : IEnemyController
    {
        private readonly EnemyBehaviourConfig _enemyConfig;
        private readonly EnemySpawnConfig _enemySpawnConfig;
        private readonly float _minX;
        private readonly float _maxX;
        private float _timeToNextUpdate;
        private readonly List<IEnemy> _enemiesLeft;
        private IEnemy _mostLeft;
        private IEnemy _mostRight;
        private bool _moveLeft;
        private bool _moveDown;

        public EnemyController(EnemyBehaviourConfig enemyConfig, EnemySpawnConfig enemySpawnConfig, float minX, float maxX)
        {
            _moveLeft = true;
            _enemiesLeft = new List<IEnemy>(enemySpawnConfig.EnemiesPerLine * enemySpawnConfig.MaxLines);
            _enemyConfig = enemyConfig;
            _enemySpawnConfig = enemySpawnConfig;
            _minX = minX;
            _maxX = maxX;
        }

        public void UpdateEnemiesPositions(IList<IEnemy> enemies)
        {
            if (_timeToNextUpdate > 0)
            {
                _timeToNextUpdate -= Time.deltaTime;
                return;
            }

            UpdateEnemiesLeft(enemies);
            MoveEnemiesLines();
            ResetTimeToUpdate();
        }

        private void ResetTimeToUpdate()
        {
            int maxEnemies = _enemySpawnConfig.EnemiesPerLine * _enemySpawnConfig.MaxLines;
            float factor = Mathf.Exp((float)_enemiesLeft.Count/maxEnemies) / (float) Math.E;

            _timeToNextUpdate = _enemyConfig.MinTickTime + (_enemyConfig.MaxTickTime - _enemyConfig.MinTickTime) * factor;
        }

        private void UpdateEnemiesLeft(IList<IEnemy> enemies)
        {
            _moveDown = false;
            _mostLeft = null;
            _mostRight = null;

            _enemiesLeft.Clear();
            foreach (var enemy in enemies)
            {
                if (enemy.IsDestroyed)
                {
                    continue;
                }

                _enemiesLeft.Add(enemy);
                if (_mostLeft == null || enemy.Position.x < _mostLeft.Position.x)
                {
                    _mostLeft = enemy;
                }
                if (_mostRight == null || enemy.Position.x > _mostRight.Position.x)
                {
                    _mostRight = enemy;
                }
            }

            if (_moveLeft)
            {
                if(_mostLeft.Position.x - _enemyConfig.MoveSpeed < _minX)
                {
                    _moveDown = true;
                }
            }
            else
            {
                if (_mostRight.Position.x + _enemyConfig.MoveSpeed > _maxX)
                {
                    _moveDown = true;
                }
            }

            if(_moveDown)
            {
                _moveLeft = !_moveLeft;
            }
        }

        private void MoveEnemiesLines()
        {
            foreach (var enemy in _enemiesLeft)
            {
                Vector3 position = enemy.Position;
                position.x += _moveLeft ? -_enemyConfig.MoveSpeed : _enemyConfig.MoveSpeed;
                if(_moveDown)
                {
                    position.y -= _enemySpawnConfig.SpaceBetweenLines;
                }
                enemy.Position = position;
            }
        }

        public void Reset()
        {
            _moveLeft = true;
            _timeToNextUpdate = 0;
        }
    }
}
