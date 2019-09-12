using Assets.Source.Models.Game.Actors;
using UnityEngine;

namespace Assets.Source.Models
{
    [RequireComponent(typeof(HitDetector))]
    public class DestructibleActor : MonoBehaviour, IDestructible, ICollidable
    {
        private static readonly Vector3 _limbo = new Vector3(-50, -50, 1);
        public bool IsDestroyed { get; protected set; }
        public event DestroyedDelegate ObjectDestroyed;
        private HitDetector _hitDetectorInstance;

        private HitDetector _hitDetector
        {
            get
            {
                return _hitDetectorInstance ?? (_hitDetectorInstance = GetComponent<HitDetector>());
            }
        }

        public void Destroy()
        {
            IsDestroyed = true;
            gameObject.SetActive(false);
            transform.position = _limbo;
            ObjectDestroyed?.Invoke(this);
        }

        public Bounds GetCollisionBounds()
        {
            return _hitDetector.GetCollisionBounds();
        }

        public bool IsColliding(ICollidable collidable)
        {
            return _hitDetector.IsColliding(collidable);
        }

        public LayerMask GetCollisionLayerMask()
        {
            return _hitDetector.GetCollisionLayerMask();
        }

        public int GetLayer()
        {
            return gameObject.layer;
        }
    }
}