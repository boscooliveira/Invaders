using UnityEngine;

namespace Assets.Source.Models.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObjects/EnemyConfig", order = 1)]
    public class EnemyConfig : ScriptableObject
    {
        public float ShootRate = 0.1f;
        public float MaxTickTime = 0.5f;
        public float MinTickTime = 0.1f;
        public float MoveSpeed = 0.1f;
    }
}