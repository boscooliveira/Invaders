
namespace Assets.Source.Models.Game
{
    public class UIManager : IUIManager
    {
        public event UIStateChangedDelegate UIStateChanged;
        public EUIState CurrentUIState { get; private set; }

        public void ChangeUIState(EUIState uiState)
        {
            if (CurrentUIState == uiState)
            {
                return;
            }

            CurrentUIState = uiState;
            UIStateChanged?.Invoke(uiState);
        }
    }
}
