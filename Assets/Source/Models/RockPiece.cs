using Assets.Source.Models.Game.Actors;
using UnityEngine;

namespace Assets.Source.Models
{
    [RequireComponent(typeof(HitDetector))]
    public class RockPiece : DestructibleActor, IRock
    {
    }
}