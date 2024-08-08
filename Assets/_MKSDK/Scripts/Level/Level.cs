using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace MKSDK
{
    [RequireComponent(typeof(AutoInject))]
    public class Level : MonoBehaviourBase, ILevel
    {
        [SerializeField]
        private Transform m_Root;
        public Transform Root => m_Root != null ? m_Root : transform;

        [Inject]
        public void Construct()
        {
        }
    }
}