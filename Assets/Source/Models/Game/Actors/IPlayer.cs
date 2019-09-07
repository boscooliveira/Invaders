using System.Collections.Generic;

namespace Assets.Source.Models.Game.Actors
{
    public interface IPlayer : IDestructible, IShooter
    {
        void SetConfigs(UnityEngine.Vector3 bottomLeft, IBulletSpawner bulletSpawner, float gameWidth, float speed = 1);
        void UpdatePosition(Managers.Input.EGameInput input);
        List<IBullet> GetBullets();
    }
}
