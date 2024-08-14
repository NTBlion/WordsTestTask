using _Game.Scripts.Logic;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.UI
{
    public class EndGameWindowUI : MonoBehaviour
    {
        [SerializeField] private Word _word;
        [SerializeField] private Transform _container;

        private Validator _validator;

        [Inject]
        private void Init(Validator validator)
        {
            _validator = validator;
        }

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void ShowWords()
        {
            for (int i = 0; i < _validator.FoundWords.Count; i++)
                Instantiate(_word, _container).SetWord(_validator.FoundWords[i]);
        }
    }
}