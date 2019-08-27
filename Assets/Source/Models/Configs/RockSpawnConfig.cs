using UnityEngine;

namespace Assets.Source.Models.Configs
{
    [CreateAssetMenu(fileName = "RockSpawnConfig", menuName = "ScriptableObjects/RockSpawnConfig", order = 1)]
    public class RockSpawnConfig : ScriptableObject
    {
        public int NumRocks = 3;
        public float RockHeight = 2;
        public float SpaceBetweenRocks = 4;
    }
}