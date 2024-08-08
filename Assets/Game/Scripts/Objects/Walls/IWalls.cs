using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public interface IWalls
    {
        Vector3 GetRandomInsidePosition(float i_Offset = 1);
    }
}