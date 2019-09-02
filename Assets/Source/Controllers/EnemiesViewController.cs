using Assets.Source.Models;
using Assets.Source.Models.Configs;
using Assets.Source.Models.Game;
using Assets.Source.Models.Game.Actors;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Controllers
{
    public class EnemiesViewController : MonoBehaviour, IEnemiesSpawner
    {
        [SerializeField]
        private Enemy _enemyPrefab = default(Enemy);

        private List<IEnemy> _enemies = new List<IEnemy>();
        private EnemySpawnConfig _config;
        private Vector3 _topLeft;
        private float _width;

        public void DestroyEnemy(Enemy enemy)
        {
            Destroy(enemy);
            _enemies.Remove(enemy);
        }

        private void SpawnEnemies()
        {
            foreach(var enemy in _enemies)
            {
                enemy.Destroy();
            }

            // making them start in the middle of the screen
            float lineWidth = (_config.EnemiesPerLine-1) * _config.SpaceBetweenEnemies;
            float initialPos = (_width - lineWidth) * 0.5f;
            Vector3 topLeft = _topLeft;
            topLeft.x += initialPos;

            _enemies.Clear();
            Vector3 enemyPosition = new Vector3();
            for(int i = 0; i < _config.MaxLines; i++)
            {
                enemyPosition.y = topLeft.y - (i * _config.SpaceBetweenLines + _config.FirstLinePadding);
                for (int j = 0; j < _config.EnemiesPerLine; j++)
                {
                    enemyPosition.x = topLeft.x + j * _config.SpaceBetweenEnemies;
                    Enemy enemy = Instantiate(_enemyPrefab, enemyPosition, Quaternion.identity, transform);
                    _enemies.Add(enemy);
                }
            }
        }

        public void SetConfigs(EnemySpawnConfig config, Vector3 gameTopLeft, float gameWidth)
        {
            _config = config;
            _topLeft = gameTopLeft;
            _width = gameWidth;
        }

        public IList<IEnemy> Spawn()
        {
            SpawnEnemies();
            return _enemies;
        }
    }
}
