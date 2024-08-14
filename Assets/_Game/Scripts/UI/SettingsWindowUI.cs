using _Game.Scripts.Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Game.Scripts.UI
{
    public class SettingsWindowUI : MonoBehaviour
    {
        [SerializeField] private Button _settings;
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _soundButton;
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _soundText;

        private GameAudio _gameAudio;

        private string _soundOn = "Sound: On";
        private string _soundOff = "Sound: Off";

        [Inject]
        private void Init(GameAudio gameAudio)
        {
            _gameAudio = gameAudio;
        }

        private void Awake()
        {
            _settingsPanel.SetActive(false);
            _slider.value = _gameAudio.Volume;
            _soundText.text = _soundText.text = _gameAudio.IsMuted ? _soundOff : _soundOn;
        }

        private void OnEnable()
        {
            _settings.onClick.AddListener(OnClickSettings);
            _backButton.onClick.AddListener(OnClickBack);
            _soundButton.onClick.AddListener(OnClickSound);
            _slider.onValueChanged.AddListener(OnValueChange);
        }

        private void OnDisable()
        {
            _settings.onClick.RemoveListener(OnClickSettings);
            _backButton.onClick.RemoveListener(OnClickBack);
            _soundButton.onClick.RemoveListener(OnClickSound);
        }

        private void OnValueChange(float value)
        {
            _gameAudio.ChangeVolume(value);
        }

        private void OnClickBack()
        {
            _settingsPanel.SetActive(false);
        }

        private void OnClickSound()
        {
            _gameAudio.ToggleSound();
            ChangeText();
        }

        private void OnClickSettings()
        {
            _settingsPanel.SetActive(true);
        }

        private void ChangeText()
        {
            _soundText.text = _soundText.text == _soundOn ? _soundOff : _soundOn;
        }
    }
}