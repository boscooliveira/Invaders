using System.Collections.Generic;
using Assets.Source.Models;
using Assets.Source.Models.Configs;
using Assets.Source.Models.Game;
using Assets.Source.Models.Game.Actors;
using UnityEngine;

namespace Assets.Source.Controllers
{
    public class RockViewController : MonoBehaviour, IRockSpawner
    {
        [SerializeField]
        private RockGroup _rockPrefab = default(RockGroup);
        private List<IRock> _rocks = new List<IRock>();
        private RockSpawnConfig _config;
        private Vector3 _gameBottomLeft;
        private float _gameWidth;

        public IList<IRock> Spawn()
        {
            foreach (IRock rock in _rocks)
            {
                rock.Destroy();
            }

            // making them start in the middle of the screen
            float lineWidth = (_config.NumRocks - 1) * _config.SpaceBetweenRocks;
            float initialPos = (_gameWidth - lineWidth) * 0.5f;
            var gameBottomLeft = _gameBottomLeft;
            gameBottomLeft.x += initialPos;

            _rocks.Clear();
            Vector3 position;
            float heightPosition = gameBottomLeft.y + _config.RockHeight;

            for (int j = 0; j < _config.NumRocks; j++)
            {
                position = gameBottomLeft;
                position.x += j * _config.SpaceBetweenRocks;
                position.y = heightPosition;
                RockGroup rock = Instantiate(_rockPrefab, position, Quaternion.identity, transform);
                _rocks.AddRange(rock.GetRockPieces());
            }

            return _rocks;
        }

        public void SetConfigs(RockSpawnConfig config, Vector3 gameBottomLeft, float gameWidth)
        {
            _config = config;
            _gameBottomLeft = gameBottomLeft;
            _gameWidth = gameWidth;
        }
    }
}