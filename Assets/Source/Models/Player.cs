using Assets.Source.Controllers;
using Assets.Source.Models.Configs;
using Assets.Source.Models.Game;
using Assets.Source.Models.Game.Actors;
using Assets.Source.Models.Game.Managers.Input;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Models
{
    public class Player : MonoBehaviour, IPlayerSpawner, IPlayer
    {
        public Transform Gun;
        private Vector3 _bottomLeft;
        private float _gameWidth;
        private float _speed;
        private IBulletSpawner _bulletSpawner;

        public bool IsDestroyed => false;

        public Vector3 GunPosition => Gun.position;

        public event DestroyedDelegate ObjectDestroyed;
        public event ShotDelegate Shot;
        private List<IBullet> _bullets = new List<IBullet>();

        private BulletConfig _bulletConfig;

        public void Destroy()
        {
            ObjectDestroyed?.Invoke(this);
        }

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
            Shot?.Invoke(this);
            return bullet;
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

            var position = transform.position;
            if (input.HasFlag(EGameInput.Left))
            {
                position.x -= Time.deltaTime * _speed;
            }
            else if (input.HasFlag(EGameInput.Right))
            {
                position.x += Time.deltaTime * _speed;
            }
            transform.position = position;
        }

        public IPlayer Spawn()
        {
            Vector3 playerPos = _bottomLeft;
            playerPos.x += _gameWidth * 0.5f;
            transform.position = playerPos;
            return this; 
        }
    }
}