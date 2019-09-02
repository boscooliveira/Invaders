using System.Collections.Generic;
using Assets.Source.Models.Game.Actors;

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
}
