
using UnityEngine;

namespace Assets.Source.Models.Game.Actors
{
    public interface IEnemy : IDestructible, IShooter, ICollidable
    {
        Vector3 Position { get; set; }
        Vector2 GridPosition { get; }
    }
}
