using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;
using UnityEngine.UI;
using VContainer;

namespace MK.Game
{
    [RequireComponent(typeof(AutoInject))]
    public abstract class ButtonBase : MonoBehaviourBase
    {
        [SerializeField]
        private Button m_Button;
        void Start()
        {

        }
        protected virtual void OnEnable()
        {
            if (m_Button != null)
            {
                m_Button.onClick.AddListener(ButtonClickCallback);
            }
        }
        protected virtual void OnDisable()
        {
            if (m_Button != null)
            {
                m_Button.onClick.RemoveListener(ButtonClickCallback);
            }   
        }
        private void ButtonClickCallback()
        {
            m_Button.interactable = false;
            ButtonAction();
        }
        protected abstract void ButtonAction();
        protected override void SetRefs()
        {
            base.SetRefs();
            m_Button = GetComponent<Button>();
        }
    }
}