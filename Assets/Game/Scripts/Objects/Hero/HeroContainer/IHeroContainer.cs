using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public interface IHeroContainer
    {
        void AddHero(Hero i_Hero);
        void RemoveHero(Hero i_Hero);
        void StartShoot();
    }
}