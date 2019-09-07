using Assets.Source.Models.Game.Actors;
using Assets.Source.Models.Game.Controllers;
using System.Collections.Generic;

namespace Assets.Source.Models.Game
{
    public class GameData
    {
        public IBulletSpawner BulletSpawner;
        public IEnemiesSpawner EnemiesSpawner;
        public IPlayerSpawner PlayerSpawner;
        public IRockSpawner RockSpawner;
        public IList<IEnemy> Enemies;
        public IList<IRock> Rocks;
        public List<IDestructible> Destructibles;
        public IPlayer Player;
        public IEnemyController EnemyController;
        public IBulletController BulletController;
    }
}
