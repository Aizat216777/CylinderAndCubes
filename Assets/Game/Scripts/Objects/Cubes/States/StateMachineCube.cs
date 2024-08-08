using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class StateMachineCube : StateMachineSimple
    {
        public void StartState(StateCubeBase.eType i_Type)
        {
            StateCubeBase stateCube = null;
            for(int i =0; i < m_States.Length; i++)
            {
                StateCubeBase checkState = m_States[i] as StateCubeBase;
                if(checkState != null &&
                    checkState.Type == i_Type)
                {
                    stateCube = checkState;
                    break;
                }
            }
            StartState(stateCube);
        }
    }
}
