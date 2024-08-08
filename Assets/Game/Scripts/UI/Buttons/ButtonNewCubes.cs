using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace MK.Game
{
    public class ButtonNewCubes : ButtonBase
    {
        private ICubeSpawner m_CubeSpawner;
        private GameConfig.SpawnCubeData m_SpawnCubeData;
        [Inject]
        public void Construct(
            ICubeSpawner i_CubeSpawner, 
            GameConfig.SpawnCubeData i_SpawnCubeData)
        {
            m_CubeSpawner = i_CubeSpawner;
            m_SpawnCubeData = i_SpawnCubeData;
        }
        protected override void ButtonAction()
        {
            m_CubeSpawner.Spawn(Random.Range(m_SpawnCubeData.rangeAmount.x, m_SpawnCubeData.rangeAmount.y));
        }
    }
}