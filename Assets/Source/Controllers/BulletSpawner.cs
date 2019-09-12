using Assets.Source.Models;
using Assets.Source.Models.Configs;
using Assets.Source.Models.Game;
using Assets.Source.Models.Game.Actors;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Controllers
{
    public class BulletSpawner : MonoBehaviour, IBulletSpawner
    {
        [SerializeField]
        private Bullet _bulletPrefab = default;
        private BulletConfig _bulletConfig;

        private Stack<Bullet> _pool = new Stack<Bullet>();

        public void SetConfig(BulletConfig bulletConfig)
        {
            _bulletConfig = bulletConfig;
        }

        private Bullet CreateBullet()
        {
            if(_pool.Count == 0)
            {
                return Instantiate(_bulletPrefab);
            }
            var bullet = _pool.Pop();
            bullet.gameObject.SetActive(true);
            return bullet;
        }

        public IBullet SpawnBullet(IShooter shooter, EBulletDirection direction)
        {
            Debug.Log("Shooter fired!!!! Spawning a bullet");
            Bullet newBullet = CreateBullet();
            newBullet.transform.position = shooter.GunPosition;
            newBullet.SetProperties(direction, _bulletConfig.MoveSpeed, _bulletConfig.OffScreenKillZone);
            newBullet.GetComponent<IDestructible>().ObjectDestroyed += OnObjectDestroyed;
            return newBullet;
        }

        private void OnObjectDestroyed(IDestructible destructible)
        {
            if (destructible is Bullet bullet)
            {
                bullet.ObjectDestroyed -= OnObjectDestroyed;
                bullet.gameObject.SetActive(false);
                _pool.Push(bullet);
                return;
            }

            Debug.LogError("Could not recycle bullet. Destroying gameObject");
            if(destructible is DestructibleActor obj)
            {
                Destroy(obj);
            }
        }
    }
}
