using TMPro;
using UnityEngine;

namespace _Game.Scripts.UI
{
    public class Word : MonoBehaviour
    {
        [SerializeField] private TMP_Text _word;

        public void SetWord(string word)
        {
            _word.text = word;
        }
    }
}