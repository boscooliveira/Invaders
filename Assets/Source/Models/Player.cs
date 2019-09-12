using Assets.Source.Controllers;
using Assets.Source.Models.Configs;
using Assets.Source.Models.Game;
using Assets.Source.Models.Game.Actors;
using Assets.Source.Models.Game.Managers.Input;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Models
{
    [RequireComponent(typeof(HitDetector))]
    public class Player : DestructibleActor, IPlayerSpawner, IPlayer
    {
        public Transform Gun;
        private Vector3 _bottomLeft;
        private float _gameWidth;
        private float _speed;
        private IBulletSpawner _bulletSpawner;

        public Vector3 GunPosition => Gun.position;

        public event ShotDelegate Shot;
        private List<IBullet> _bullets = new List<IBullet>();

        private BulletConfig _bulletConfig;

        public void SetConfigs(Vector3 bottomLeft, IBulletSpawner bulletSpawner, float gameWidth, float speed = 1)
        {
            _bottomLeft = bottomLeft;
            _gameWidth = gameWidth;
            _speed = speed;
            _bulletSpawner = bulletSpawner;
        }

        public IBullet Shoot(IBulletSpawner bulletSpawner)
        {
            Debug.Log($"Player is shooting");
            var bullet = bulletSpawner.SpawnBullet(this, EBulletDirection.Up);
            bullet.ObjectDestroyed += OnBulletDestroyed;
            Shot?.Invoke(this);
            return bullet;
        }

        private void OnBulletDestroyed(IDestructible destructible)
        {
            if (destructible is IBullet bullet)
            {
                bullet.ObjectDestroyed -= OnBulletDestroyed;
                _bullets.Remove(bullet);
            }
        }

        public List<IBullet> GetBullets()
        {
            return _bullets;
        }

        public void UpdatePosition(EGameInput input)
        {
            if (input.HasFlag(EGameInput.Fire) || input.HasFlag(EGameInput.Enter))
            {
                _bullets.Add( Shoot(_bulletSpawner) );
            }

            if (input.HasFlag(EGameInput.Right))
            {
                transform.Translate(Vector3.right * Time.deltaTime * _speed);
            } else if (input.HasFlag(EGameInput.Left))
            {
                transform.Translate(Vector3.left * Time.deltaTime * _speed);
            }
        }

        public IPlayer Spawn()
        {
            Vector3 playerPos = _bottomLeft;
            playerPos.x += _gameWidth * 0.5f;
            transform.position = playerPos;
            IsDestroyed = false;
            gameObject.SetActive(true);
            return this; 
        }
    }
}