using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Game.Scripts.Logic
{
    public class Cluster : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private Image[] _images;
        [SerializeField] private TMP_Text[] _texts;
        [SerializeField] private CanvasGroup _canvasGroup;

        public int Size { get; private set; }
        public Transform StartParent { get; private set; }

        private List<Cell> _occupiedCells;

        public void InitCluster(string cluster, Transform parent)
        {
            for (int i = 0; i < _images.Length; i++)
            {
                _images[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < cluster.Length; i++)
            {
                _images[i].gameObject.SetActive(true);
                _texts[i].text = cluster[i].ToString();
                Size++;
            }
        
            _occupiedCells = new List<Cell>();
            StartParent = parent;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            foreach (var cell in _occupiedCells)
                cell.ClearLetter();

            _occupiedCells.Clear();

            _canvasGroup.blocksRaycasts = false;
            transform.SetParent(transform.root, true);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;

            if (transform.parent == transform.root)
                transform.SetParent(StartParent);
        }

        public void OccupyCells(List<Cell> cells)
        {
            _occupiedCells = cells;
        }

        public string GetClusterChars()
        {
            return string.Concat(_texts.Where(text => text.gameObject.activeSelf).Select(text => text.text));
        }
    }
}