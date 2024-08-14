using System;
using System.Collections.Generic;
using System.Text;
using _Game.Scripts.Data;
using UnityEngine;

namespace _Game.Scripts.Logic
{
    public class Validator
    {
        private LevelData _levelData;
        private Cell[,] _grid;

        public List<string> FoundWords { get; private set; }
    
        public event Action AnsweredCorrect;
    
        public Validator(Cell[,] grid, LevelData levelData)
        {
            _grid = grid;
            _levelData = levelData;
        }
    
        public void CheckAnswers()
        {
            FoundWords = new List<string>();
            bool allWordsCorrect = true;
        
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                StringBuilder stringBuilder = new();

                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    char letter = _grid[i, j].Letter;
                
                    if (letter != '0')
                        stringBuilder.Append(letter);
                }

                string word = stringBuilder.ToString();
            
                if (string.IsNullOrEmpty(word) == false)
                    FoundWords.Add(word);
            }
        
            foreach (string correctWord in _levelData.words)
            {
                if (FoundWords.Contains(correctWord) == false)
                {
                    allWordsCorrect = false;
                    Debug.Log($"Слово '{correctWord}' не найдено");
                }
            }

            if (allWordsCorrect)
            {
                Debug.Log("Все ответы правильные");
                AnsweredCorrect?.Invoke();
            }
            else
            {
                Debug.Log("Не все слова правильные");
            }
        }
    }
}