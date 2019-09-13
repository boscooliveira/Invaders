
namespace Assets.Source.Models.Game.Managers.States
{
    public class LoseGameState : IGameState
    {
        public EGameState State => EGameState.Lose;
        public EGameState NextState { get; private set; }

        public void EnterState(GameData data)
        {
            StateManager.ChangeUIState(EUIState.Lose);
        }

        public void LeaveState()
        {
        }

        public void Update(Input.EGameInput input)
        {
            if (input == Input.EGameInput.Enter)
            {
                NextState = EGameState.Menu;
            }
        }
    }
}
