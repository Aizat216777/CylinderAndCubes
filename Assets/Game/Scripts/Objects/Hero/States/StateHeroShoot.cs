using MKSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace MK.Game
{
    [RequireComponent(typeof(AutoInject))]
    public class StateHeroShoot : StateHeroBase
    {
        private ICubeContainer m_CubeContainer;
        private GameConfig.HeroData.ShootData m_ShootData;
        private float m_DelayToShootNow;
        private Cube m_CurrentCube;
        private IObjectResolver m_ObjectResolver;
        private GameConfig.PrefabsData m_PrefabsData;
        private ILevel m_Level;
        public override eType Type => eType.Shoot;
        [Inject]
        public void Construct(
            ICubeContainer i_CubeContainer,
            IObjectResolver i_ObjectResolver,
            GameConfig.HeroData i_HeroData,
            GameConfig.PrefabsData i_PrefabsData,
            ILevel i_Level)
        {
            m_CubeContainer = i_CubeContainer;
            m_ObjectResolver = i_ObjectResolver;
            m_ShootData = i_HeroData.shootData;
            m_PrefabsData = i_PrefabsData;
            m_Level = i_Level;
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            if (HeroText != null)
            {
                HeroText.gameObject.SetActive(true);
                HeroText.text = "";
            }
        }
        private void Update()
        {
            if(m_CurrentCube == null ||
                m_CurrentCube.IsStopped)
            {
                m_CurrentCube = m_CubeContainer.GetNotStoppedRandomCube();
                if (m_CurrentCube != null)
                {
                    if (HeroText != null)
                    {
                        HeroText.text = m_CurrentCube.Index.ToString();
                    }
                }
                else if(m_Hero != null)
                {
                    m_Hero.StopShoot();
                }
            }
            if (m_CurrentCube == null)
            {
                return;
            }
            m_DelayToShootNow -= Time.deltaTime;
            if (m_DelayToShootNow < 0)
            {
                m_DelayToShootNow = m_ShootData.delayToShoot;
                Bullet bullet = m_ObjectResolver.InstantiateAndInject(
                    m_PrefabsData.bullet,
                    transform.position,
                    Quaternion.LookRotation(m_CurrentCube.transform.position - transform.position),
                    m_Level.Root,
                    null);
                bullet.Init(m_CurrentCube.Index, m_ShootData.force);
            }
        }
    }
}