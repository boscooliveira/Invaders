using Assets.Source.Controllers;
using Assets.Source.Models.Game;
using Assets.Source.Models.Game.Actors;
using UnityEngine;

namespace Assets.Source.Models
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        public Transform Gun;
        public Vector3 Position { get => transform.position; set => transform.position = value; }

        public bool IsDestroyed => false;

        public Vector2 GridPosition { get; set; }

        public Vector3 GunPosition => Gun.position;

        public event DestroyedDelegate ObjectDestroyed;
        public event ShotDelegate Shot;

        public void Destroy()
        {
            ObjectDestroyed?.Invoke(this);
        }

        public IBullet Shoot(IBulletSpawner _bulletSpawner)
        {
            Debug.Log($"Enemy at position {Position} is shooting");
            var bullet = _bulletSpawner.SpawnBullet(this, EBulletDirection.Down);
            Shot?.Invoke(this);
            return bullet;
        }
    }
}
