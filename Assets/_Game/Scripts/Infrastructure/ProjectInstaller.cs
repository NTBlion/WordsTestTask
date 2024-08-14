using Zenject;

namespace _Game.Scripts.Infrastructure
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameAudio>().AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
        }
    }
}