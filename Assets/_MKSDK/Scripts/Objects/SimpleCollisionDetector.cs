using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MKSDK
{
    public class SimpleCollisionDetector : MonoBehaviour
    {
        public delegate void EnterEvent(SimpleCollisionDetector i_SimpleCollisionDetector, Collision i_Collision);
        public event EnterEvent OnEnter = delegate { };
        void Start()
        {

        }
        private void OnCollisionEnter(Collision i_Collision)
        {
            OnEnter(this, i_Collision);
        }
    }
}