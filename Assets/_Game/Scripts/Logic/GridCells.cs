using System.Collections.Generic;
using _Game.Scripts.Infrastructure;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Logic
{
    public class GridCells : IInitializable
    {
        private GameAudio _gameAudio;

        private Cell[,] _grid;

        public GridCells(GameAudio gameAudio, Cell[,] grid)
        {
            _gameAudio = gameAudio;
            _grid = grid;
        }

        public void Initialize()
        {
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    _grid[i, j].Init(this, new Vector2Int(i, j));
                }
            }
        }

        public bool TryDrop(Cluster cluster, Cell cell)
        {
            Vector2Int cellIndex = cell.Index;
            int clusterSize = cluster.Size;

            if (cellIndex.y + clusterSize > _grid.GetLength(1))
                return false;

            for (int i = cellIndex.y; i < cellIndex.y + clusterSize; i++)
            {
                if (_grid[cellIndex.x, i].IsOccupied)
                {
                    return false;
                }
            }

            return true;
        }

        public void Drop(Cluster cluster, Cell cell)
        {
            Vector2Int cellIndex = cell.Index;
            int clusterSize = cluster.Size;
            string charsInCluster = cluster.GetClusterChars();

            List<Cell> occupiedCells = new List<Cell>();

            int index = 0;

            for (int i = cellIndex.y; i < clusterSize + cellIndex.y; i++)
            {
                occupiedCells.Add(_grid[cellIndex.x, i]);

                occupiedCells[index].SetLetter(charsInCluster[index]);
                index++;
            }

            cluster.OccupyCells(occupiedCells);
            cluster.transform.SetParent(cell.transform);
            cluster.transform.localPosition = Vector3.zero;

            cell.transform.SetAsLastSibling();

            _gameAudio.PlaySound();
        }

        public void Add(Cell cell, int i, int j)
        {
            _grid[i, j] = cell;
        }
    }
}