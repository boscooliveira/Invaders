using Assets.Source.Models.Game.Actors;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Models
{
    public class RockGroup : MonoBehaviour
    {
        private List<IRock> _rocks;
        public List<IRock> GetRockPieces()
        {
            if(_rocks == null)
            {
                _rocks = new List<IRock>();
                GetComponentsInChildren<IRock>(_rocks);
            }
            return _rocks;
        }
    }
}