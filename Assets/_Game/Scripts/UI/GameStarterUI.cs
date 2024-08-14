using _Game.Scripts.Infrastructure;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Game.Scripts.UI
{
    public class GameStarterUI : MonoBehaviour
    {
        [SerializeField] private Button _playButton;

        private SceneLoader _sceneLoader;

        [Inject]
        private void Init(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
    
        private void OnEnable()
        {
            _playButton.onClick.AddListener(LunchGame);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(LunchGame);
        }

        private void LunchGame()
        {
            _sceneLoader.LoadGameScene();
        }
    }
}
