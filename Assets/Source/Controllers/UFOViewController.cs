using Assets.Source.Models;
using UnityEngine;

namespace Assets.Source.Controllers
{
    public class UFOViewController : MonoBehaviour
    {
        [SerializeField]
        private UFO _ufoPrefab = default(UFO);

        private UFO _spawnedUFO;

        public void SpawnUFO(Vector3 position, float gameWidth)
        {
            if (_spawnedUFO == null)
            {
                _spawnedUFO = Instantiate(_ufoPrefab, position, Quaternion.identity, transform);
            }

            _spawnedUFO.Reset(position);
        }
    }
}
