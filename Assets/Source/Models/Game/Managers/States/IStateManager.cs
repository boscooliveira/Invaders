using Assets.Source.Models.Game.Managers.Input;

namespace Assets.Source.Models.Game.Managers.States
{
    public interface IStateManager
    {
        EGameState CurrentState { get; }
        void Initialize(GameData data);
        void Update(EGameInput input);
    }
}