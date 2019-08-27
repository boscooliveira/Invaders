using UnityEngine;

namespace Assets.Source.Models
{
    public class UFO : MonoBehaviour
    {
        public void Reset(Vector3 topLeft)
        {
            transform.position = topLeft;
        }
    }
}