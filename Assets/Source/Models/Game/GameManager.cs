using Assets.Source.Controllers;
using Assets.Source.Models.Configs;
using UnityEngine;

namespace Assets.Source.Models.Game
{
    /// <summary>
    /// This class controls the game states and stores the configs 
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public GameConfigProvider GameConfig;
        public EnemiesController Enemies;
        public RockSpawner Rocks;
        public Player Player;
        public Camera GameCamera;

        // Start is called before the first frame update
        void Start()
        {
            Vector2 topLeft = GameConfig.ScreenProportion.TopLeftCorner;
            Vector2 bottomRight = GameConfig.ScreenProportion.BottomRightCorner;

            var topLeftWorld = GameCamera.ViewportToWorldPoint(new Vector3(topLeft.x, topLeft.y, 0));
            var topRightWorld = GameCamera.ViewportToWorldPoint(new Vector3(bottomRight.x, topLeft.y, 0));
            var bottomLeftWorld = GameCamera.ViewportToWorldPoint(new Vector3(topLeft.x, bottomRight.y, 0));
            var bottomRightWorld = GameCamera.ViewportToWorldPoint(new Vector3(bottomRight.x, bottomRight.y, 0));

            topLeftWorld.z = 0;
            Enemies.SpawnEnemies(GameConfig.EnemySpawn, topLeftWorld);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
