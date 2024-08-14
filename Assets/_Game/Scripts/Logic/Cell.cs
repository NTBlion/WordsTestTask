using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game.Scripts.Logic
{
    public class Cell : MonoBehaviour, IDropHandler
    {
        private const char EMPTY_CELL = '0';
    
        public bool IsOccupied => Letter != EMPTY_CELL;
        public Vector2Int Index { get; private set; }
        public char Letter { get; private set; } = EMPTY_CELL;

        private GridCells _gridCells;

        public void Init(GridCells gridCells, Vector2Int index)
        {
            _gridCells = gridCells;
            Index = index;
        }
    
        public void SetLetter(char letter)
        {
            Letter = letter;
        }
    
        public void ClearLetter()
        {
            Letter = EMPTY_CELL;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.TryGetComponent(out Cluster cluster))
            {
                if (_gridCells.TryDrop(cluster, this))
                {
                    _gridCells.Drop(cluster, this);
                }
                else
                {
                    cluster.transform.SetParent(cluster.StartParent);
                }
            }
        }
    }
}