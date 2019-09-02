using System;

namespace Assets.Source.Models.Game.Managers.Input
{
    [Flags]
    public enum EGameInput
    {
        None  = 0,
        Enter = 1 << 0,
        Left  = 1 << 1,
        Right = 1 << 2,
        Fire  = 1 << 3
    }
}
