using UnityEngine;

namespace Assets.Source.Models.Configs
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "ScriptableObjects/BulletConfig", order = 1)]
    public class BulletConfig : ScriptableObject
    {
        public float OffScreenKillZone = -1f;
        public float MoveSpeed = 0.1f;
    }
}