using Assets.Source.Models;
using Assets.Source.Models.Configs;
using Assets.Source.Models.Game;
using Assets.Source.Models.Game.Controllers;
using Assets.Source.Models.Game.Managers.Input;
using Assets.Source.Models.Game.Managers.States;
using Assets.Source.Services.DI;
using UnityEngine;

namespace Assets.Source.Controllers
{
    /// <summary>
    /// This class controls the game states
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private const int _foregroundZ = -1;
        public GameConfigProvider GameConfig;
        public EnemiesViewController Enemies;
        public RockViewController Rocks;
        public UFOViewController UFOSpawner;
        public BulletSpawner BulletSpawner;
        public Player Player;
        public Camera GameCamera;

        private InvaderGame _game;

        private void Start()
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

            BulletSpawner.SetConfig(GameConfig.BulletConfig);

            Enemies.SetConfigs(GameConfig.EnemySpawnConfig, topLeftWorld, gameWidth);
            Player.SetConfigs(bottomLeftWorld, BulletSpawner, gameWidth);
            Rocks.SetConfigs(GameConfig.RockSpawnConfig, bottomLeftWorld, gameWidth);

            var controller = new EnemyController(GameConfig.EnemyBehaviourConfig, GameConfig.EnemySpawnConfig,
                BulletSpawner, topLeftWorld.x, bottomRightWorld.x);

            DIContainer.Instance.Bind<IEnemiesSpawner>(Enemies);
            DIContainer.Instance.Bind<IPlayerSpawner>(Player);
            DIContainer.Instance.Bind<IRockSpawner>(Rocks);
            DIContainer.Instance.Bind<IBulletSpawner>(BulletSpawner);
            DIContainer.Instance.Bind<IEnemyController>(controller);
            DIContainer.Instance.Bind<IBulletController>(new BulletController());

            _game = new InvaderGame();
        }

        private void Update()
        {
            _game.UpdateGame();
        }
    }
}
