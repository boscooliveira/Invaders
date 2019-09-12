using System;
using Assets.Source.Models.Game.Actors;
using UnityEngine;

namespace Assets.Source.Models
{
    public delegate void HitDelegate(GameObject obj1, GameObject obj2);

    [RequireComponent(typeof(Collider))]
    public class HitDetector : MonoBehaviour
    {
        private Collider _colliderInstance;
        private Collider _collider
        {
            get { return _colliderInstance ?? (_colliderInstance = GetComponent<Collider>()); }
        }

        public LayerMask LayersToDetect;
        public void Reset(Vector3 topLeft)
        {
            transform.position = topLeft;
        }

        private void OnHitObject(GameObject sender, GameObject hitObject)
        {
            Debug.Log("Colliding");
            var destructible = sender.GetComponent<IDestructible>();
            if (destructible != null && !destructible.IsDestroyed)
            {
                destructible.Destroy();
            }

            destructible = hitObject.GetComponent<IDestructible>();
            if (destructible != null && !destructible.IsDestroyed)
            {
                destructible.Destroy();
            }
        }

        public LayerMask GetCollisionLayerMask()
        {
            return LayersToDetect;
        }

        public Bounds GetCollisionBounds()
        {
            return _collider.bounds;
        }

        public bool IsColliding(ICollidable collidable)
        {
            var collidableLayer = 1 << collidable.GetLayer();
            if ((LayersToDetect & collidableLayer) == 0)
            {
                return false;
            }
            var bounds1 = _collider.bounds;
            var bounds2 = collidable.GetCollisionBounds();
            bool collides = bounds1.Intersects(bounds2);
            return collides;
        }

        private void OnTriggerEnter(Collider collider)
        {
            Debug.Log("Colliding");
            var collidedObject = collider.gameObject;
            if ((LayersToDetect & collidedObject.layer) == 0)
            {
                return;
            }

            OnHitObject(gameObject, collidedObject);
        }
    }
}