using Assets.Source.Models.Game;
using Assets.Source.Models.Game.Actors;
using UnityEngine;

namespace Assets.Source.Models
{
    public class Player : MonoBehaviour, IPlayerSpawner, IPlayer
    {
        private Vector3 _bottomLeft;
        private float _gameWidth;

        public bool IsDestroyed => false;

        public event DestroyedDelegate ObjectDestroyed;
        public event ShotDelegate Shot;

        public void Destroy()
        {
            ObjectDestroyed?.Invoke(this);
        }

        public void SetConfigs(Vector3 bottomLeft, float gameWidth)
        {
            _bottomLeft = bottomLeft;
            _gameWidth = gameWidth;
        }

        public void Shoot()
        {
            Shot?.Invoke(this);
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