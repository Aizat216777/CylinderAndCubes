using EasyButtons;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using MKSDK;

namespace MK.Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private GameConfig m_GameConfig;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IObjectResolver, Container>(Lifetime.Scoped);

            builder.RegisterComponentInHierarchy<Level>().
                As<ILevel>();
            builder.RegisterComponentInHierarchy<Walls>().
                As<IWalls>();
            builder.Register<CubeContainer>(Lifetime.Singleton)
                .As<ICubeContainer>();
            builder.Register<CubeSpawner>(Lifetime.Singleton)
                .As<ICubeSpawner>();
            builder.Register<HeroContainer>(Lifetime.Singleton)
                .As<IHeroContainer>();

            builder.RegisterInstance(m_GameConfig.spawnCubeData);
            builder.RegisterInstance(m_GameConfig.prefabsData);
            builder.RegisterInstance(m_GameConfig.cubeData);
            builder.RegisterInstance(m_GameConfig.heroData);
        }
        [Button]
        protected virtual void SetRefs()
        {
            // find all AutoInject and save only parents
            AutoInject[] autoInjects = FindObjectsByType<AutoInject>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            autoInjectGameObjects.Clear();
            for (int i = 0; i < autoInjects.Length; i++)
            {
                Transform parentAutoInject = autoInjects[i].transform;
                bool isCorrect = true;
                for (int j = i + 1; j < autoInjects.Length; j++)
                {
                    if (parentAutoInject.GetInstanceID() == autoInjects[j].transform.GetInstanceID())
                    {
                        isCorrect = false;
                        break;
                    }
                }
                parentAutoInject = parentAutoInject.parent;
                while (parentAutoInject != null &&
                    isCorrect)
                {
                    for (int j = 0; j < autoInjects.Length; j++)
                    {
                        if (parentAutoInject.GetInstanceID() == autoInjects[j].transform.GetInstanceID() &&
                            i != j)
                        {
                            isCorrect = false;
                            break;
                        }
                    }
                    parentAutoInject = parentAutoInject.parent;
                }
                if (isCorrect)
                {
                    autoInjectGameObjects.Add(autoInjects[i].gameObject);
                }
            }
        }
    }

}
