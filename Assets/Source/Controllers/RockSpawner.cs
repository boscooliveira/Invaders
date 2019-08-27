using System;
using System.Collections.Generic;
using Assets.Source.Models.Configs;
using UnityEngine;

namespace Assets.Source.Controllers
{
    public class RockSpawner : MonoBehaviour
    {
        [SerializeField]
        private Rock _rockPrefab = null;
        private List<Rock> _rocks = new List<Rock>();

        public void SpawnRocks(RockSpawnConfig config, Vector3 gameBottomLeft, float gameWidth)
        {
            foreach (Rock rock in _rocks)
            {
                DestroyRock(rock);
            }

            // making them start in the middle of the screen
            float lineWidth = (config.NumRocks - 1) * config.SpaceBetweenRocks;
            float initialPos = (gameWidth - lineWidth) * 0.5f;
            gameBottomLeft.x += initialPos;

            _rocks.Clear();
            Vector3 position;
            float heightPosition = gameBottomLeft.y + config.RockHeight;

            for (int j = 0; j < config.NumRocks; j++)
            {
                position = gameBottomLeft;
                position.x += j * config.SpaceBetweenRocks;
                position.y = heightPosition;
                Rock rock = Instantiate(_rockPrefab, position, Quaternion.identity, transform);
                _rocks.Add(rock);
            }
        }

        private void DestroyRock(Rock rock)
        {
            Destroy(rock);
            _rocks.Remove(rock);
        }
    }
}