
using UnityEngine;

namespace Assets.Source.Models.Game.Actors
{

    public interface IPlayer : IDestructible, IShooter
    {
    }

    public interface IEnemy : IDestructible, IShooter
    {
        Vector3 Position { get; set; }
    }

    public interface IUFO : IDestructible
    {
    }

    public interface IRock : IDestructible
    {
    }
}
