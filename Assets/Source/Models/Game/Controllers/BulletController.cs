﻿using Assets.Source.Models.Configs;
using Assets.Source.Models.Game.Actors;
using System.Collections.Generic;

namespace Assets.Source.Models.Game.Controllers
{
    public class BulletController : IBulletController
    {
        private readonly List<IBullet> _bullets;

        public BulletController()
        {
            _bullets = new List<IBullet>(10);
        }

        public void Reset()
        {
            foreach(var bullet in _bullets)
            {
                bullet.Destroy();
            }
            _bullets.Clear();
        }

        public void UpdateBulletPositions(IList<IBullet> bullets)
        {
            foreach (var bullet in bullets)
            {
                bullet.UpdatePosition();
            }
        }
    }
}