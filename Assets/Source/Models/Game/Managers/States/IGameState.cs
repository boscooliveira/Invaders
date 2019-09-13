namespace Assets.Source.Models.Game.Managers.States
{
    public enum EGameState
    {
        Undefined,
        Menu,
        StartNewGame,
        InGame,
        Win,
        Lose
    }

    public interface IGameState
    {
        EGameState State { get; }
        EGameState NextState { get; }
        void EnterState(GameData data);
        void LeaveState();
        void Update(Input.EGameInput input);
    }
}
