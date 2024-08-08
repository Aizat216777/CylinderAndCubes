using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class StateMachineHero : StateMachineSimple
    {
        public void StartState(StateHeroBase.eType i_Type)
        {
            StateHeroBase stateHero = null;
            for (int i = 0; i < m_States.Length; i++)
            {
                StateHeroBase checkState = m_States[i] as StateHeroBase;
                if (checkState != null &&
                    checkState.Type == i_Type)
                {
                    stateHero = checkState;
                    break;
                }
            }
            StartState(stateHero);
        }
    }
}