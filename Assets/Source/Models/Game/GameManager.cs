using Assets.Source.Controllers;
using Assets.Source.Models.Configs;
using UnityEngine;

namespace Assets.Source.Models.Game
{
    /// <summary>
    /// This class controls the game states
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private const int _foregroundZ = -1;
        public GameConfigProvider GameConfig;
        public EnemiesController Enemies;
        public RockSpawner Rocks;
        public UFOSpawner UFOSpawner;
        public Player Player;
        public Camera GameCamera;

        void Start()
        {
            Vector2 topLeft = GameConfig.ScreenProportionConfig.TopLeftCorner;
            Vector2 bottomRight = GameConfig.ScreenProportionConfig.BottomRightCorner;

            var topLeftWorld = GameCamera.ViewportToWorldPoint(new Vector3(topLeft.x, topLeft.y, 0));
            var topRightWorld = GameCamera.ViewportToWorldPoint(new Vector3(bottomRight.x, topLeft.y, 0));
            var bottomLeftWorld = GameCamera.ViewportToWorldPoint(new Vector3(topLeft.x, bottomRight.y, 0));
            var bottomRightWorld = GameCamera.ViewportToWorldPoint(new Vector3(bottomRight.x, bottomRight.y, 0));

            topLeftWorld.z = _foregroundZ;
            topRightWorld.z = _foregroundZ;
            bottomLeftWorld.z = _foregroundZ;
            bottomRightWorld.z = _foregroundZ;

            float gameWidth = bottomRightWorld.x - topLeftWorld.x;
            Enemies.SpawnEnemies(GameConfig.EnemySpawnConfig, topLeftWorld, gameWidth);
            Rocks.SpawnRocks(GameConfig.RockSpawnConfig, bottomLeftWorld, gameWidth);
            Player.Reset(bottomLeftWorld, gameWidth);
            UFOSpawner.SpawnUFO(topRightWorld, gameWidth);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
