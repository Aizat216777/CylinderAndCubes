using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace MK.Game
{
    public class ButtonCubeHunter : ButtonBase
    {
        private ICubeContainer m_CubeContainer;
        [Inject]
        public void Construct(ICubeContainer i_CubeContainer)
        {
            m_CubeContainer = i_CubeContainer;
        }
        protected override void ButtonAction()
        {
            m_CubeContainer.StartRandomMove();
            Cube cube = m_CubeContainer.GetRandomCube();
            if (cube != null)
            {
                cube.SetHunter();
            }
        }
    }
}