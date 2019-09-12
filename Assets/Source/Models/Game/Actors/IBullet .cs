using Assets.Source.Controllers;

namespace Assets.Source.Models.Game.Actors
{
    public interface IBullet : IDestructible, ICollidable
    {
        void SetProperties(EBulletDirection direction, float speed = 1f, float offScreenKillZone = 0);
        void UpdatePosition();
    }
}
