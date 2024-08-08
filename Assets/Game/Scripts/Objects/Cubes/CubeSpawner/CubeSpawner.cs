using MKSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace MK.Game
{
    public class CubeSpawner : ICubeSpawner
    {
        private ILevel m_Level;
        private GameConfig.PrefabsData m_PrefabsData;
        private IObjectResolver m_ObjectResolver;
        private IWalls m_Walls;
        public CubeSpawner(
            ILevel i_Level,
            GameConfig.PrefabsData i_PrefabsData,
            IObjectResolver i_ObjectResolver,
            IWalls i_Walls)
        {
            m_Level = i_Level;
            m_PrefabsData = i_PrefabsData;
            m_ObjectResolver = i_ObjectResolver;
            m_Walls = i_Walls;
        }

        void ICubeSpawner.Spawn(int i_Amount)
        {
            for(int i = 0; i< i_Amount;i++)
            {
                m_ObjectResolver.InstantiateAndInject(
                    m_PrefabsData.cube,
                    m_Walls.GetRandomInsidePosition(),
                    Random.rotation,
                    m_Level.Root,
                    null);
            }
        }
    }
}