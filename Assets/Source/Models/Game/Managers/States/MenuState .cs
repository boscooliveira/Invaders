
using Assets.Source.Models.Game.Managers.Input;

namespace Assets.Source.Models.Game.Managers.States
{
    public class MenuState : IGameState
    {
        public EGameState State => EGameState.Menu;
        public EGameState NextState { get; private set; }

        public void EnterState(GameData data)
        {
            NextState = EGameState.Undefined;
            data.PlayerSpawner.Spawn();
        }

        public void LeaveState()
        {
        }

        public void Update(EGameInput input)
        {
            if (input.HasFlag(EGameInput.Enter))
            {
                NextState = EGameState.StartNewGame;
            }
        }
    }
}
