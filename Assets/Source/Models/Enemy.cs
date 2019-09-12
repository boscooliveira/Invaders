using Assets.Source.Controllers;
using Assets.Source.Models.Game;
using Assets.Source.Models.Game.Actors;
using UnityEngine;

namespace Assets.Source.Models
{
    public class Enemy : DestructibleActor, IEnemy
    {
        public Transform Gun;
        public Vector3 Position { get => transform.position; set => transform.position = value; }

        public Vector2 GridPosition { get; set; }

        public Vector3 GunPosition => Gun.position;

        public event ShotDelegate Shot;

        public IBullet Shoot(IBulletSpawner _bulletSpawner)
        {
            var bullet = _bulletSpawner.SpawnBullet(this, EBulletDirection.Down);
            Shot?.Invoke(this);
            return bullet;
        }
    }
}
