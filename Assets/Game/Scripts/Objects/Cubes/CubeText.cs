using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;
using TMPro;

namespace MK.Game
{
    public class CubeText : MonoBehaviourBase
    {
        [SerializeField]
        private Cube m_Cube;
        [SerializeField]
        private TMP_Text m_Text;
        // Start is called before the first frame update
        void Start()
        {

        }
        private void OnEnable()
        {
            if (m_Cube != null)
            {
                m_Cube.OnIndexUpdated += CubeIndexUpdatedCallback;
                CubeIndexUpdatedCallback(m_Cube, m_Cube.Index);
            }
        }
        private void OnDisable()
        {
            if (m_Cube != null)
            {
                m_Cube.OnIndexUpdated -= CubeIndexUpdatedCallback;
            }
        }
        private void CubeIndexUpdatedCallback(Cube i_Cube, int i_Index)
        {
            if (m_Text != null)
            {
                m_Text.text = i_Index.ToString();
            }
        }
        protected override void SetRefs()
        {
            base.SetRefs();
            m_Text = GetComponent<TMP_Text>();
            m_Cube = GetComponentInParent<Cube>();
        }
    }
}