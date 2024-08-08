using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class CubeContainer : ICubeContainer
    {
        private List<Cube> m_Cubes = new List<Cube>();
        private int m_Index;
        public void AddCube(Cube i_Cube)
        {
            m_Cubes.Add(i_Cube);
        }
        public void RemoveCube(Cube i_Cube)
        {
            m_Cubes.Remove(i_Cube);
        }

        public Cube GetCloseCube(Cube i_Cube)
        {
            Cube closeCube = null;
            float distanceSquareMin = 0;
            if (i_Cube != null)
            {
                for (int i = 0; i < m_Cubes.Count; i++)
                {
                    if (m_Cubes[i] != null &&
                        m_Cubes[i].GetInstanceID() != i_Cube.GetInstanceID())
                    {
                        float distanceSquare = ExtensionMethodsV2.DistanceSquare(m_Cubes[i].transform.position, i_Cube.transform.position);
                        if (distanceSquare < distanceSquareMin ||
                            closeCube == null)
                        {
                            closeCube = m_Cubes[i];
                            distanceSquareMin = distanceSquare;
                        }
                    }
                }
            }
            return closeCube;
        }
        public Cube GetNotStoppedRandomCube()
        {
            List<Cube> notStopedCubes = new List<Cube>();
            for (int i = 0; i < m_Cubes.Count; i++)
            {
                if (m_Cubes[i] != null &&
                    !m_Cubes[i].IsStopped)
                {
                    notStopedCubes.Add(m_Cubes[i]);
                }
            }
            return notStopedCubes.GetRandomItem();
        }

        public int GetNextIndex() => m_Index++;
        public Cube GetRandomCube()
        {
            return m_Cubes.GetRandomItem();
        }

        public void StartRandomMove()
        {
            for (int i = 0; i < m_Cubes.Count; i++)
            {
                if (m_Cubes[i] != null)
                {
                    m_Cubes[i].StartRandomMovement();
                }
            }
        }
    }
}