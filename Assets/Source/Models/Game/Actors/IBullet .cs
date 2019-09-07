using UnityEngine;

namespace Assets.Source.Models.Game.Actors
{
    public delegate void HitDestructibleDelegate(IBullet bullet, IShooter shooter, IDestructible destructible);

    public interface IBullet : IDestructible
    {
        event HitDestructibleDelegate OnHitDestructible;
        void FireBullet (IShooter shooter, Vector3 position, Vector3 direction);
        void UpdatePosition();
    }
}
