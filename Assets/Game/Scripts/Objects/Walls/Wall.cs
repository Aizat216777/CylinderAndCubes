using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class Wall : MonoBehaviourBase
    {
        public enum eType
        {
            Left,
            Right,
            Top,
            Bottom,
        }
        [SerializeField]
        private eType m_Type;
        public eType Type => m_Type;
    }
}