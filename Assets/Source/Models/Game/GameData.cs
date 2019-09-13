using Assets.Source.Models.Game.Actors;
using Assets.Source.Models.Game.Controllers;
using System.Collections.Generic;

namespace Assets.Source.Models.Game
{
    public class GameData
    {
        public IList<IEnemy> Enemies;
        public IList<IRock> Rocks;
        public List<IDestructible> Destructibles;
        public IPlayer Player;
    }
}
