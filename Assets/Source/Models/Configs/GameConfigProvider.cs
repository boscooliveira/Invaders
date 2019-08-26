using UnityEngine;

namespace Assets.Source.Models.Configs
{
    [CreateAssetMenu(fileName = "GameConfigProvider", menuName = "ScriptableObjects/GameConfigProvider", order = 1)]
    public class GameConfigProvider : ScriptableObject
    {
        public ScreenProportionConfig ScreenProportion;
        public EnemySpawnConfig EnemySpawn;
    }
}
