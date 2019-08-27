using Assets.Source.Models.Configs;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Controllers
{
    public class EnemiesController : MonoBehaviour
    {
        [SerializeField]
        private Enemy _enemyPrefab = null;

        private List<Enemy> _enemies = new List<Enemy>();

        public void DestroyEnemy(Enemy enemy)
        {
            Destroy(enemy);
            _enemies.Remove(enemy);
        }

        public void SpawnEnemies(EnemySpawnConfig config, Vector3 gameTopLeft, float gameWidth)
        {
            foreach(var enemy in _enemies)
            {
                DestroyEnemy(enemy);
            }

            // making them start in the middle of the screen
            float lineWidth = (config.EnemiesPerLine-1) * config.SpaceBetweenEnemies;
            float initialPos = (gameWidth - lineWidth) * 0.5f;
            gameTopLeft.x += initialPos;

            _enemies.Clear();
            Vector3 enemyPosition = new Vector3();
            for(int i = 0; i < config.MaxLines; i++)
            {
                enemyPosition.y = gameTopLeft.y - (i * config.SpaceBetweenLines + config.FirstLinePadding);
                for (int j = 0; j < config.EnemiesPerLine; j++)
                {
                    enemyPosition.x = gameTopLeft.x + j * config.SpaceBetweenEnemies;
                    Enemy enemy = Instantiate(_enemyPrefab, enemyPosition, Quaternion.identity, transform);
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
