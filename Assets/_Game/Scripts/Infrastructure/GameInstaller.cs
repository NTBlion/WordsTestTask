using _Game.Scripts.Data;
using _Game.Scripts.Generators;
using _Game.Scripts.Logic;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private TextAsset _jsonFile;
        [SerializeField] private GridGenerator _gridGenerator;

        public override void InstallBindings()
        {
            BindLevelData();
            ResolveGameAudio();
            Container.BindInterfacesAndSelfTo<GridCells>().AsSingle();
            Container.Bind<Cell[,]>()
                .FromIFactory(x => x.To<GridGenerator>().FromInstance(_gridGenerator)).AsSingle();
            Container.Bind<Validator>().AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
        }

        private void ResolveGameAudio()
        {
            GameAudio gameAudio = Container.Resolve<GameAudio>();
            gameAudio.Assign(_audioSource);
        }

        public void BindLevelData()
        {
            string jsonString = _jsonFile.text;
            LevelData jsonData = JsonUtility.FromJson<LevelData>(jsonString);
            Container.Bind<LevelData>().FromInstance(jsonData).AsSingle();
        }
    }
}