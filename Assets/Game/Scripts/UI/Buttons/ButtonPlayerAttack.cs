using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace MK.Game
{
    public class ButtonPlayerAttack : ButtonBase
    {
        private IHeroContainer m_HeroContainer;
        [Inject]
        public void Construct(IHeroContainer i_HeroContainer)
        {
            m_HeroContainer = i_HeroContainer;
        }
        protected override void ButtonAction()
        {
            m_HeroContainer.StartShoot();
        }
    }
}