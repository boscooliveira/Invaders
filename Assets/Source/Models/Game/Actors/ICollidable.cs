
namespace Assets.Source.Models.Game.Actors
{
    public interface ICollidable
    {
        int GetLayer();
        UnityEngine.LayerMask GetCollisionLayerMask();
        UnityEngine.Bounds GetCollisionBounds();
        bool IsColliding(ICollidable collidable);
    }
}
