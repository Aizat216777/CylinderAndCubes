using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace MK.Game
{
    public class ButtonRandomMove : ButtonBase
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
        }
    }
}
