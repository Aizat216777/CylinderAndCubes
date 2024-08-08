using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;
using VContainer;
using TMPro;

namespace MK.Game
{
    [RequireComponent(typeof(AutoInject))]
    public class Cube : MonoBehaviourBase
    {
        public delegate void IndexUpdatedEvent(Cube i_Cube, int i_Index);
        public event IndexUpdatedEvent OnIndexUpdated = delegate { };
        //public delegate void StopUpdatedEvent(Cube i_Cube, int i_Index);
        //public event IndexUpdatedEvent OnIndexUpdated = delegate { };

        [SerializeField]
        private MeshRenderer m_MeshRenderer;
        [SerializeField]
        private Rigidbody m_Rigidbody;
        [SerializeField]
        private BoxCollider m_BoxCollider;
        [SerializeField]
        private StateMachineCube m_StateMachine;
        [SerializeField]
        private SimpleCollisionDetector m_SimpleCollisionDetector;
        private int m_Index;
        private ICubeContainer m_CubeContainer;
        public Rigidbody Rigidbody => m_Rigidbody;
        public BoxCollider BoxCollider => m_BoxCollider;
        public SimpleCollisionDetector SimpleCollisionDetector => m_SimpleCollisionDetector;
        public bool IsStopped
        {
            get;
            private set;
        }
        public int Index
        {
            get => m_Index;
            set
            {
                m_Index = value;
                OnIndexUpdated(this, m_Index);
            }
        }
        [Inject]
        public void Constrcut(ICubeContainer i_CubeContainer)
        {
            m_CubeContainer = i_CubeContainer;
            Index = m_CubeContainer.GetNextIndex();
        }
        // Start is called before the first frame update
        void Start()
        {
            if(m_MeshRenderer != null &&
                m_MeshRenderer.material != null)
            {
                m_MeshRenderer.material.color = new Color(Random.value, Random.value, Random.value, 1);
            }
            StartState(StateCubeBase.eType.Simple);
        }
        private void OnEnable()
        {
            if (m_CubeContainer != null)
            {
                m_CubeContainer.AddCube(this);
            }
        }
        private void OnDisable()
        {
            if (m_CubeContainer != null)
            {
                m_CubeContainer.RemoveCube(this);
            }
        }
        public void StartRandomMovement()
        {
            IsStopped = false;
            StartState(StateCubeBase.eType.RandomMove);
        }
        public void SetHunter()
        {
            IsStopped = false;
            StartState(StateCubeBase.eType.Hunter);
        }
        public void Hit()
        {
            IsStopped = true;
            StartState(StateCubeBase.eType.Stopped);
        }
        private void StartState(StateCubeBase.eType i_Type)
        {
            if (m_StateMachine != null)
            {
                m_StateMachine.StartState(i_Type);
            }
        }
        protected override void SetRefs()
        {
            base.SetRefs();
            m_MeshRenderer = GetComponent<MeshRenderer>();
            m_BoxCollider = GetComponent<BoxCollider>();
            m_Rigidbody = GetComponent<Rigidbody>();
            m_StateMachine = GetComponentInChildren<StateMachineCube>();
            m_SimpleCollisionDetector = GetComponent<SimpleCollisionDetector>();
        }
    }
}