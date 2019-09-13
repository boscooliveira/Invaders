
using Assets.Source.Models.Game.Actors;
using Assets.Source.Models.Game.Controllers;
using Assets.Source.Services.DI;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Assets.Source.Models.Game.Managers.States
{
    public class WinGameState : IGameState
    {
        public EGameState State => EGameState.Win;
        public EGameState NextState { get; private set; }

        public void EnterState(GameData data)
        {
            StateManager.ChangeUIState(EUIState.Win);
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
