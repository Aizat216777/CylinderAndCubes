using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class StateCubeStopped : StateCubeBase
    {
        public override eType Type => eType.Stopped;
        protected override void OnEnable()
        {
            base.OnEnable();
            if (Rigidbody != null)
            {
                Rigidbody.isKinematic = true;
            }
        }
    }
}