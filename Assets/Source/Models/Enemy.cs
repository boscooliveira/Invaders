using Assets.Source.Models.Game.Actors;
using UnityEngine;

namespace Assets.Source.Models
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        public Vector3 Position { get => transform.position; set => transform.position = value; }

        public bool IsDestroyed => false;

        public Vector2 GridPosition { get; set; }

        public event DestroyedDelegate ObjectDestroyed;
        public event ShotDelegate Shot;

        public void Destroy()
        {
            ObjectDestroyed?.Invoke(this);
        }

        public void Shoot()
        {
            Shot?.Invoke(this);
        }
    }
}
