using Assets.Source.Models.Game;
using Assets.Source.Models.Game.Managers.Input;
using Assets.Source.Services.DI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.Controllers
{
    public class GameInitializer : MonoBehaviour
    {
        private void Start()
        {
            // Initializing ui and input systems
            DIContainer.Instance.Bind<IGameInputManager>(new GameInputManager());
            DIContainer.Instance.Bind<IUIManager>(new UIManager());
            SceneManager.LoadScene("Game");
        }
    }
}