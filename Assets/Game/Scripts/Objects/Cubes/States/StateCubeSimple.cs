using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MK.Game
{
    public class StateCubeSimple : StateCubeBase
    {
        public override eType Type => eType.Simple;
        protected override void OnEnable()
        {
            base.OnEnable();
            if (Rigidbody != null)
            {
                Rigidbody.isKinematic = false;
            }
            if (BoxCollider != null)
            {
                BoxCollider.enabled = true;
            }
        }
    }
}