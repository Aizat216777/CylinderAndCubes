using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;
using VContainer;
using TMPro;

namespace MK.Game
{
    [RequireComponent(typeof(AutoInject))]
    public class Hero : MonoBehaviourBase
    {
        private IHeroContainer m_HeroContainer;
        [SerializeField]
        private StateMachineHero m_StateMachine;
        [SerializeField]
        private TMP_Text m_Text;
        public TMP_Text Text => m_Text;
        [Inject]
        public void Construct(IHeroContainer i_HeroContainer)
        {
            m_HeroContainer = i_HeroContainer;
        }
        void Start()
        {
            StartState(StateHeroBase.eType.Simple);
        }
        private void OnEnable()
        {
            m_HeroContainer.AddHero(this);
        }
        private void OnDisable()
        {
            m_HeroContainer.RemoveHero(this);
        }
        public void StartShoot()
        {
            StartState(StateHeroBase.eType.Shoot);
        }
        public void StopShoot()
        {
            StartState(StateHeroBase.eType.Simple);
        }
        private void StartState(StateHeroBase.eType i_Type)
        {
            if (m_StateMachine != null)
            {
                m_StateMachine.StartState(i_Type);
            }
        }
        protected override void SetRefs()
        {
            base.SetRefs();
            m_StateMachine = GetComponentInChildren<StateMachineHero>();
            m_Text = GetComponentInChildren<TMP_Text>();
        }
    }
}