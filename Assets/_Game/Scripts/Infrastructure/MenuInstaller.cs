using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure
{
    public class MenuInstaller : MonoInstaller
    {
        [SerializeField] private AudioSource _audioSource;
    
        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().AsSingle();
            ResolveGameAudio();
        }
    
        private void ResolveGameAudio()
        {
            GameAudio gameAudio = Container.Resolve<GameAudio>();
            gameAudio.Assign(_audioSource);
            gameAudio.PlaySound();
        }
    }
}