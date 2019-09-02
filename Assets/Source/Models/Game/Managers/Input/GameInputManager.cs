namespace Assets.Source.Models.Game.Managers.Input
{
    public class GameInputManager : IGameInputManager
    {
        public EGameInput GetInput()
        {
            EGameInput input = EGameInput.None;
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Return))
            {
                input |= EGameInput.Enter;
            }
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Space))
            {
                input |= EGameInput.Fire;
            }

            bool left = false;
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.LeftArrow) ||
                UnityEngine.Input.GetKey(UnityEngine.KeyCode.A))
            {
                left = true;
            }
            bool right = false;
            if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.RightArrow) ||
                UnityEngine.Input.GetKey(UnityEngine.KeyCode.D))
            {
                right = true;
            }

            if (left == right)
            {
                return input;
            }

            if (left)
            {
                input |= EGameInput.Left;
            }
            else
            {
                input |= EGameInput.Right;
            }

            return input;
        }
    }
}
