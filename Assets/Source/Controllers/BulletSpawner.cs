using Assets.Source.Models;
using Assets.Source.Models.Configs;
using Assets.Source.Models.Game;
using Assets.Source.Models.Game.Actors;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Controllers
{
    public class BulletSpawner : MonoBehaviour, IBulletSpawner
    {
        [SerializeField]
        private Bullet _bulletPrefab = default(Bullet);
        private BulletConfig _bulletConfig;

        public void SetConfig(BulletConfig bulletConfig)
        {
            _bulletConfig = bulletConfig;
        }

        public IBullet SpawnBullet(IShooter shooter, EBulletDirection direction)
        {
            Debug.Log("Shooter fired!!!! Spawning a bullet");
            Bullet newBullet = Instantiate(_bulletPrefab);
            newBullet.transform.position = shooter.GunPosition;
            newBullet.SetProperties(shooter, direction, _bulletConfig.MoveSpeed, _bulletConfig.OffScreenKillZone);
            return newBullet;
        }
    }
}
