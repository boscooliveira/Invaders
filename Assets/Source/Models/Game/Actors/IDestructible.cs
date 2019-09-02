
namespace Assets.Source.Models.Game.Actors
{
    public delegate void DestroyedDelegate(IDestructible destructible);
    public interface IDestructible
    {
        event DestroyedDelegate ObjectDestroyed;

        bool IsDestroyed { get; }
        void Destroy();
    }
}
