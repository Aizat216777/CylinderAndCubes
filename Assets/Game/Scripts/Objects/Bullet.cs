using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class Bullet : MonoBehaviourBase
    {
        [SerializeField]
        private Rigidbody m_Rigidbody;
        private int m_CubeIndex;
        // Start is called before the first frame update
        void Start()
        {

        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.tag == nameof(eTags.Cube))
            {
                if (collision.collider.TryGetComponent(out Cube cube))
                {
                    if (cube.Index == m_CubeIndex)
                    {
                        cube.Hit();
                        Destroy(gameObject);
                    }
                }
            }
        }
        public void Init(int i_IndexCube, float i_Force)
        {
            m_CubeIndex = i_IndexCube;
            if(m_Rigidbody != null)
            {
                m_Rigidbody.AddForce(transform.forward * i_Force, ForceMode.Impulse);
            }

        }
        protected override void SetRefs()
        {
            base.SetRefs();
            m_Rigidbody = GetComponent<Rigidbody>();
        }
    }
}
