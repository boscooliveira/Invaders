using Assets.Source.Models.Game.Actors;
using System.Collections.Generic;

namespace Assets.Source.Models.Game.Controllers
{
    public interface IBulletController
    {
        void Reset();
        void UpdateBulletPositions(IList<IBullet> bullets);
    }
}
