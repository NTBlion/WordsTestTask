using _Game.Scripts.Generators;
using _Game.Scripts.Logic;
using _Game.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Game.Scripts.Infrastructure
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField] private ClusterGenerator clusterGenerator;
        [SerializeField] private GridGenerator _gridGenerator;
        [SerializeField] private Button _validateButton;
        [SerializeField] private EndGameWindowUI _endGameWindowTemplate;

        private Validator _validator;

        [Inject]
        private void Init(Validator validator)
        {
            _validator = validator;
        }

        private void OnEnable()
        {
            _validateButton.onClick.AddListener(Clicked);
        }

        private void OnDisable()
        {
            _validateButton.onClick.RemoveListener(Clicked);
            _validator.AnsweredCorrect -= OnAnsweredCorrect;
        }

        private void Awake()
        {
            clusterGenerator.Generate();
            _validator.AnsweredCorrect += OnAnsweredCorrect;
        }

        private void OnAnsweredCorrect()
        {
            _endGameWindowTemplate.gameObject.SetActive(true);
            _endGameWindowTemplate.ShowWords();
        }

        private void Clicked()
        {
            _validator.CheckAnswers();
        }
    }
}