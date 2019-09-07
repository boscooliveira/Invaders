using Assets.Source.Controllers;
using Assets.Source.Models.Configs;
using Assets.Source.Models.Game;
using Assets.Source.Models.Game.Actors;
using UnityEngine;

namespace Assets.Source.Models
{
    public class Player : MonoBehaviour, IPlayerSpawner, IPlayer
    {
        public Transform Gun;
        private Vector3 _bottomLeft;
        private float _gameWidth;

        public bool IsDestroyed => false;

        public Vector3 GunPosition => Gun.position;

        public event DestroyedDelegate ObjectDestroyed;
        public event ShotDelegate Shot;

        private BulletConfig _bulletConfig;

        public void Destroy()
        {
            ObjectDestroyed?.Invoke(this);
        }

        public void SetConfigs(Vector3 bottomLeft, float gameWidth)
        {
            _bottomLeft = bottomLeft;
            _gameWidth = gameWidth;
        }

        public IBullet Shoot(IBulletSpawner _bulletSpawner)
        {
            Debug.Log($"Player is shooting");
            var bullet = _bulletSpawner.SpawnBullet(this, EBulletDirection.Up);
            Shot?.Invoke(this);
            return bullet;
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