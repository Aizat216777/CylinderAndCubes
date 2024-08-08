using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public abstract class StateCubeBase : StateBase
    {
        public enum eType
        {
            Simple,
            RandomMove,
            Stopped, 
            Hunter,
        }
        [SerializeField]
        protected Cube m_Cube;
        public abstract eType Type { get; }
        protected Rigidbody Rigidbody => m_Cube != null ? m_Cube.Rigidbody : null;
        protected BoxCollider BoxCollider => m_Cube != null ? m_Cube.BoxCollider : null;
        protected override void SetRefs()
        {
            base.SetRefs();
            m_Cube = GetComponentInParent<Cube>();
        }
    }


}