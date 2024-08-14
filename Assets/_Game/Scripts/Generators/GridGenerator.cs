using System.Collections;
using _Game.Scripts.Data;
using _Game.Scripts.Logic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Game.Scripts.Generators
{
    public class GridGenerator : MonoBehaviour, IFactory<Cell[,]>
    {
        [SerializeField] private Cell _cell;
        [SerializeField] private Transform _container;
        [SerializeField] private GridLayoutGroup _layout;
    
        private int _columnsCount;
        private int _rowsCount;
    
        [Inject]
        private void Init(LevelData levelData)
        {
            _columnsCount = levelData.columnsCount;
            _rowsCount = levelData.rowsCount;
        }

        private IEnumerator DisableLayout()
        {
            yield return new WaitForEndOfFrame();
            _layout.enabled = false;
        }

        public Cell[,] Create()
        {
            Cell[,] cells = new Cell[_columnsCount, _rowsCount]; 

            for (int i = 0; i < _columnsCount; i++)
            {
                for (int j = 0; j < _rowsCount; j++)
                {
                    var cell = Instantiate(_cell, _container);
                    cells[i, j] = cell;
                }
            }

            StartCoroutine(DisableLayout());
            return cells;
        }
    }
}