using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public interface ICubeContainer 
    {
        void AddCube(Cube i_Cube);
        void RemoveCube(Cube i_Cube);
        Cube GetNotStoppedRandomCube();
        Cube GetCloseCube(Cube i_IgnoreCube);
        Cube GetRandomCube();
        int GetNextIndex();
        void StartRandomMove();

    }
}