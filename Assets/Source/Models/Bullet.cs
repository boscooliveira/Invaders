using System;
using Assets.Source.Controllers;
using Assets.Source.Models.Game.Actors;
using UnityEngine;

namespace Assets.Source.Models
{
    public class Bullet : MonoBehaviour, IBullet
    {
        private EBulletDirection _bulletDirection;
        private IShooter _shooter;
        private float _speed;

        public bool IsDestroyed => throw new System.NotImplementedException();

        public event HitDestructibleDelegate OnHitDestructible;
        public event DestroyedDelegate ObjectDestroyed;

        public void Destroy()
        {
            Destroy(this);
        }

        public void FireBullet(IShooter shooter, Vector3 position, Vector3 direction)
        {
        }

        private void OnCollide(Collider c)
        {
            var shooter = c.GetComponent<IShooter>();
            if (shooter == _shooter)
            {
                return;
            }

            var destructible = c.GetComponent<IDestructible>();
            if (destructible != null)
            {
                destructible.Destroy();
                Destroy();
            }
        }

        public void Reset(Vector3 topLeft)
        {
            transform.position = topLeft;
        }

        public void UpdatePosition()
        {
            var newPosition = transform.position;
            if(_bulletDirection == EBulletDirection.Up)
            {
                newPosition.y += (_speed * Time.deltaTime);
            }
            else
            {
                newPosition.y -= (_speed * Time.deltaTime);
            }
            transform.position = newPosition;
        }

        public void SetProperties(IShooter shooter, EBulletDirection direction, float speed = 1f, float offScreenKillZone = 0)
        {
            _bulletDirection = direction;
            _shooter = shooter;
            _speed = speed;
        }
    }
}