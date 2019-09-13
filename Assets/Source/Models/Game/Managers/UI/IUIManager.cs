namespace Assets.Source.Models.Game
{
    public enum EUIState
    {
        Undefined = 0,
        Menu,
        InGame,
        Pause,
        Win,
        Lose
    }

    public delegate void UIStateChangedDelegate(EUIState state);

    public interface IUIManager
    {
        event UIStateChangedDelegate UIStateChanged;
        EUIState CurrentUIState { get; }
        void ChangeUIState(EUIState uiState);
    }
}
