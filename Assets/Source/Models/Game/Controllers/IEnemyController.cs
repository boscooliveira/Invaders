using Assets.Source.Models.Game.Actors;
using System.Collections.Generic;

namespace Assets.Source.Models.Game.Controllers
{
    public interface IEnemyController
    {
        void Reset();
        void UpdateEnemiesPositions(IList<IEnemy> enemies);
    }
}
