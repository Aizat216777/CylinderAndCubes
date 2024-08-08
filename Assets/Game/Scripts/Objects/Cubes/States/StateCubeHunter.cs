using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;
using VContainer;

namespace MK.Game
{
    [RequireComponent(typeof(AutoInject))]
    public class StateCubeHunter : StateCubeBase
    {
        private Cube m_Target;
        private ICubeContainer m_CubeContainer;
        private GameConfig.CubeData.HunterData m_HunterData;
        public override eType Type => eType.Hunter;
        [Inject]
        public void Construct(ICubeContainer i_CubesContainer, GameConfig.CubeData i_CubeData)
        {
            m_CubeContainer = i_CubesContainer;
            m_HunterData = i_CubeData.hunterData;
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            if (m_Cube != null)
            {
                m_Cube.transform.localScale = Vector3.one * 2.0f;                
            }
            if(m_Cube!=null &&
                m_Cube.SimpleCollisionDetector != null)
            {
                m_Cube.SimpleCollisionDetector.OnEnter += CollisionEnterCallback;
            }
        }
        protected override void OnDisable()
        {
            base.OnDisable();
            if (m_Cube != null &&
                m_Cube.SimpleCollisionDetector != null)
            {
                m_Cube.SimpleCollisionDetector.OnEnter -= CollisionEnterCallback;
            }
        }
        private void FixedUpdate()
        {
            if(m_Target == null)
            {
                m_Target = m_CubeContainer.GetCloseCube(m_Cube);
            }
            if (m_Target != null &&
                Rigidbody != null)
            {
                Rigidbody.AddForce((m_Target.transform.position - transform.position).normalized * m_HunterData.force);
            }
            
        }
        private void CollisionEnterCallback(SimpleCollisionDetector i_SimpleCollisionDetector, Collision i_Collision)
        {
            if (i_Collision.collider.CompareTag(nameof(eTags.Cube)))
            {
                if(i_Collision.collider.TryGetComponent(out Cube cube))
                {
                    Destroy(cube.gameObject);
                }
            }
        }
    }
}