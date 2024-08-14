using UnityEngine.SceneManagement;

namespace _Game.Scripts.Infrastructure
{
    public class SceneLoader
    {
        private const int GAME_SCENE = 1;
        private const int MENU_SCENE = 0;

        public void LoadGameScene()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadMenuScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}