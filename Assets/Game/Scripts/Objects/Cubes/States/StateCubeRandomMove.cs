using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace MK.Game
{
    public class StateCubeRandomMove : StateCubeBase
    {
        private float m_DelayToChangeDirection;
        private Vector3 m_Force;
        private GameConfig.CubeData.RandomMoveData m_RandomMoveData;
        public override eType Type => eType.RandomMove;
        [Inject]
        public void Construct(GameConfig.CubeData i_CubeData)
        {
            m_RandomMoveData = i_CubeData.randomMoveData;
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            m_DelayToChangeDirection = -1;
            if (Rigidbody != null)
            {
                Rigidbody.isKinematic = false;
            }
            if (BoxCollider != null)
            {
                BoxCollider.enabled = true;
            }
        }
        private void FixedUpdate()
        {
            m_DelayToChangeDirection -= Time.fixedDeltaTime;
            if (m_DelayToChangeDirection < 0)
            {
                m_DelayToChangeDirection = m_RandomMoveData.delayToChangeDirection;
                float angle = Random.value* 2.0f * Mathf.PI;
                m_Force.x = Mathf.Cos(angle) * m_RandomMoveData.force;
                m_Force.y = Mathf.Sin(angle) * m_RandomMoveData.force;
            }
            if (Rigidbody != null)
            {
                Rigidbody.AddForce(m_Force);
            }
        }
    }
}