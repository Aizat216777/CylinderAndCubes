using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class StateHeroSimple : StateHeroBase
    {
        public override eType Type => eType.Simple;
        protected override void OnEnable()
        {
            base.OnEnable();
            if (HeroText != null)
            {
                HeroText.gameObject.SetActive(false);
            }
        }
    }
}