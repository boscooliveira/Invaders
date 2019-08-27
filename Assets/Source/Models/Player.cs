using UnityEngine;

namespace Assets.Source.Models
{
    public class Player : MonoBehaviour
    {
        public void Reset(Vector3 bottomLeft, float gameWidth)
        {
            Vector3 playerPos = bottomLeft;
            playerPos.x += gameWidth * 0.5f;
            transform.position = playerPos;
        }
    }
}