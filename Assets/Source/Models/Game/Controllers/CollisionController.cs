using Assets.Source.Models.Game.Actors;
using System.Collections.Generic;

namespace Assets.Source.Models.Game.Controllers
{
    public class CollisionController
    {
        private readonly List<KeyValuePair<int, int>> _collisions;
        private readonly List<ICollidable> _collidables;

        public CollisionController()
        {
            _collisions = new List<KeyValuePair<int, int>>();
            _collidables = new List<ICollidable>();
        }

        private void UpdateCollisions(List<ICollidable> collidables)
        {
            _collisions.Clear();
            for (int i = 0; i < collidables.Count; i++)
            {
                var collidable1 = collidables[i];

                if (collidable1 is IDestructible destructible1 && destructible1.IsDestroyed)
                {
                    continue;
                }

                for (int j = i+1; j < collidables.Count; j++)
                {
                    var collidable2 = collidables[j];

                    if (collidable2 is IDestructible destructible2 && destructible2.IsDestroyed)
                    {
                        continue;
                    }

                    if (collidable1.IsColliding(collidable2))
                    {
                        UnityEngine.Debug.Log("Collided");
                        _collisions.Add(new KeyValuePair<int, int>(i,j));
                    }
                }
            }

            foreach (var value in _collisions)
            {
                TryDestroyCollidable(collidables[value.Key]);
                TryDestroyCollidable(collidables[value.Value]);
            }
        }

        private void TryDestroyCollidable(ICollidable collidable)
        {
            if(collidable is IDestructible destructible && !destructible.IsDestroyed)
            {
                destructible.Destroy();
            }
        }

        public void UpdateInGameCollisions(GameData gameData, List<IBullet> enemiesBullets, List<IBullet> playerBullets)
        {
            _collidables.Clear();
            _collidables.AddRange(enemiesBullets);
            _collidables.Add(gameData.Player);
            UpdateCollisions(_collidables);

            _collidables.Clear();
            _collidables.AddRange(playerBullets);
            _collidables.AddRange(gameData.Enemies);
            UpdateCollisions(_collidables);

            _collidables.Clear();
            _collidables.AddRange(gameData.Enemies);
            _collidables.Add(gameData.Player);
            UpdateCollisions(_collidables);

            _collidables.Clear();
            _collidables.AddRange(enemiesBullets);
            _collidables.AddRange(playerBullets);
            _collidables.AddRange(gameData.Rocks);
            UpdateCollisions(_collidables);
        }
    }
}
