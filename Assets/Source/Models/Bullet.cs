using System;
using Assets.Source.Controllers;
using Assets.Source.Models.Game.Actors;
using UnityEngine;

namespace Assets.Source.Models
{
    [RequireComponent(typeof(HitDetector))]
    public class Bullet : DestructibleActor, IBullet
    {
        private EBulletDirection _bulletDirection;
        private float _speed;
        private float _killZone;

        public void UpdatePosition()
        {
            if (IsDestroyed)
            {
                return;
            }

            Vector3 direction = _bulletDirection == EBulletDirection.Up ? Vector3.up : Vector3.down;
            transform.Translate( direction * _speed * Time.deltaTime );

            var newPositionY = transform.position.y; 
            if (newPositionY > _killZone || newPositionY < -_killZone)
            {
                Destroy();
                return;
            }
        }

        public void SetProperties(EBulletDirection direction, float speed = 1f, float killZone = 0)
        {
            _bulletDirection = direction;
            _speed = speed;
            _killZone = killZone;
            IsDestroyed = false;
        }
    }
}