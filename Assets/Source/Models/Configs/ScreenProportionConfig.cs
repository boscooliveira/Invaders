using UnityEngine;

namespace Assets.Source.Models.Configs
{
    [CreateAssetMenu(fileName = "ScreenProportionConfig", menuName = "ScriptableObjects/ScreenProportionConfig", order = 1)]
    public class ScreenProportionConfig : ScriptableObject
    {
        public Vector2 TopLeftCorner = Vector2.zero;
        public Vector2 BottomRightCorner = Vector2.one;
    }
}
