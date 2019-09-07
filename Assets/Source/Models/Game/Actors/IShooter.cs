
namespace Assets.Source.Models.Game.Actors
{
    public delegate void ShotDelegate(IShooter shooter);

    public interface IShooter
    {
        UnityEngine.Vector3 GunPosition { get; }
        event ShotDelegate Shot;
        IBullet Shoot(IBulletSpawner bulletSpawner);
    }
}
