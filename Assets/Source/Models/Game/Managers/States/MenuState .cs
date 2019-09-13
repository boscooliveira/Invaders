
using Assets.Source.Models.Game.Managers.Input;
using Assets.Source.Services.DI;
using UnityEngine.Assertions;

namespace Assets.Source.Models.Game.Managers.States
{
    public class MenuState : IGameState
    {
        public EGameState State => EGameState.Menu;
        public EGameState NextState { get; private set; }

        public void EnterState(GameData data)
        {
            NextState = EGameState.Undefined;
            var playerSpawner = DIContainer.Instance.Resolve<IPlayerSpawner>();
            Assert.IsNotNull(playerSpawner);
            playerSpawner.Spawn();

            StateManager.ChangeUIState(EUIState.Menu);
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
