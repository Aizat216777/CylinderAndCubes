using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class HeroContainer : IHeroContainer
    {
        private List<Hero> m_Heroes = new List<Hero>();
        public void AddHero(Hero i_Hero)
        {
            m_Heroes.Add(i_Hero);
        }

        public void RemoveHero(Hero i_Hero)
        {
            m_Heroes.Remove(i_Hero);
        }

        public void StartShoot()
        {
            for(int i = 0;i< m_Heroes.Count;i++)
            {
                if (m_Heroes[i] != null)
                {
                    m_Heroes[i].StartShoot();
                }
            }
        }
    }
}