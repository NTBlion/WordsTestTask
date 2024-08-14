using _Game.Scripts.Data;
using _Game.Scripts.Logic;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Generators
{
    public class ClusterGenerator : MonoBehaviour
    {
        [SerializeField] private Cluster _cluster;
        [SerializeField] private Transform _container;

        private LevelData _levelData;

        [Inject]
        private void Init(LevelData levelData)
        {
            _levelData = levelData;
        }

        public void Generate()
        {
            for (int i = 0; i < _levelData.clusters.Length; i++)
            {
                Instantiate(_cluster, _container).InitCluster(_levelData.clusters[i], _container);
            }
        }
    }
}
