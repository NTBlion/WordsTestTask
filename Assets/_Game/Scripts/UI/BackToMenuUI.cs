using _Game.Scripts.Infrastructure;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Game.Scripts.UI
{
    public class BackToMenuUI : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuButton;
    
        private SceneLoader _sceneLoader;

        [Inject]
        private void Init(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void OnEnable()
        {
            _mainMenuButton.onClick.AddListener(LunchGame);
        }

        private void OnDisable()
        {
            _mainMenuButton.onClick.RemoveListener(LunchGame);
        }

        private void LunchGame()
        {
            _sceneLoader.LoadMenuScene();
        }
    }
}