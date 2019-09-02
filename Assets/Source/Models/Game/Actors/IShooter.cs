
namespace Assets.Source.Models.Game.Actors
{
    public delegate void ShotDelegate(IShooter shooter);

    public interface IShooter
    {
        event ShotDelegate Shot;
        void Shoot();
    }
}
