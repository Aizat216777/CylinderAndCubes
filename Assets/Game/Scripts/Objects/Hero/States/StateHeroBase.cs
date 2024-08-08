using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;
using TMPro;

namespace MK.Game
{
    public abstract class StateHeroBase : StateBase
    {
        public enum eType
        {
            Simple,
            Shoot,
        }
        [SerializeField]
        protected Hero m_Hero;
        public abstract eType Type { get; }
        protected TMP_Text HeroText => m_Hero != null ? m_Hero.Text : null;

        protected override void SetRefs()
        {
            base.SetRefs();
            m_Hero = GetComponentInParent<Hero>();
        }
    }
}