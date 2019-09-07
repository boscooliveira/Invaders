using System.Collections.Generic;
using Assets.Source.Controllers;
using Assets.Source.Models.Configs;
using Assets.Source.Models.Game.Actors;
using UnityEngine;

namespace Assets.Source.Models.Game
{
    public interface IListSpawner<T>
    {
        IList<T> Spawn();
    }

    public interface IEnemiesSpawner : IListSpawner<IEnemy>
    {
    }

    public interface IPlayerSpawner
    {
        IPlayer Spawn();
    }

    public interface IRockSpawner : IListSpawner<IRock>
    {
    }

    public interface IBulletSpawner
    {
        IBullet SpawnBullet(IShooter shooter, EBulletDirection direction);
    }
}
