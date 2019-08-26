using UnityEngine;

namespace Assets.Source.Models.Configs
{
    [CreateAssetMenu(fileName = "EnemySpawnConfig", menuName = "ScriptableObjects/EnemySpawnConfig", order = 1)]
    public class EnemySpawnConfig : ScriptableObject
    {
        public int EnemiesPerLine = 6;
        public int MaxLines = 6;
        public float SpaceBetweenEnemies = 2;
        public float SpaceBetweenLines = 2;
    }
}
