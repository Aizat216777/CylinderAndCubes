using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MKSDK
{
    public class StateMachineSimple : MonoBehaviourBase
    {
        [SerializeField]
        protected StateBase[] m_States;
        // Start is called before the first frame update
        void Start()
        {

        }
        public void StartState(StateBase i_State)
        {
            if (i_State != null)
            {
                //disable other states
                for(int i = 0; i< m_States.Length; i++)
                {
                    if (m_States[i] != null &&
                        m_States[i].GetInstanceID()!= i_State.GetInstanceID())
                    {
                        m_States[i].enabled = false;
                    }
                }
                //enable correct state
                for (int i = 0; i < m_States.Length; i++)
                {
                    if (m_States[i] != null &&
                        m_States[i].GetInstanceID() == i_State.GetInstanceID())
                    {
                        m_States[i].enabled = true;
                        break;
                    }
                }
            }
        }

        protected override void SetRefs()
        {
            base.SetRefs();
            m_States = GetComponentsInChildren<StateBase>();
        }
    }
}