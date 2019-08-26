using Assets.Source.Models.Configs;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Controllers
{
    public class EnemiesController : MonoBehaviour
    {
        [SerializeField]
        private Enemy _enemyPrefab;

        private List<Enemy> _enemies = new List<Enemy>();

        public void DestroyEnemy(Enemy enemy)
        {
            Destroy(enemy);
            _enemies.Remove(enemy);
        }

        public void SpawnEnemies(EnemySpawnConfig config, Vector3 startPosition)
        {
            foreach(var enemy in _enemies)
            {
                DestroyEnemy(enemy);
            }

            _enemies.Clear();
            Vector3 enemyPosition;
            for(int i = 0; i < config.MaxLines; i++)
            {
                for(int j = 0; j < config.EnemiesPerLine; j++)
                {
                    enemyPosition = startPosition;
                    enemyPosition.x += j * config.SpaceBetweenEnemies;
                    enemyPosition.y -= i * config.SpaceBetweenLines;
                    var enemy = Instantiate(_enemyPrefab, enemyPosition, Quaternion.identity, transform);
                    _enemies.Add(enemy);
                }
            }
        }

        // Update is called once per frame
        public void MoveEnemies()
        {
        }
    }
}
