using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class Walls : MonoBehaviourBase, IWalls
    {
        [SerializeField]
        private Wall[] m_Walls;
        // Start is called before the first frame update
        void Start()
        {

        }
        public Wall GetWall(Wall.eType i_Type)
        {
            for(int i = 0; i< m_Walls.Length; i++)
            {
                if (m_Walls[i]!=null &&
                    m_Walls[i].Type == i_Type)
                {
                    return m_Walls[i];
                }
            }
            return null;
        }
        public Vector3 GetRandomInsidePosition(float i_Offset = 1)
        {
            float left = -1;
            float right = 1;
            float top = 1;
            float bottom = -1;
            Wall wall = GetWall(Wall.eType.Left);
            if (wall != null)
            {
                left = wall.transform.position.x;
            }
            wall = GetWall(Wall.eType.Right);
            if (wall != null)
            {
                right = wall.transform.position.x;
            }
            wall = GetWall(Wall.eType.Top);
            if (wall != null)
            {
                top = wall.transform.position.y;
            }
            wall = GetWall(Wall.eType.Bottom);
            if (wall != null)
            {
                bottom = wall.transform.position.y;
            }
            left += i_Offset;
            right -= i_Offset;
            top -= i_Offset;
            bottom += i_Offset;
            return new Vector3(
                Random.Range(left, right),
                Random.Range(top, bottom),
                0);
        }

        protected override void SetRefs()
        {
            base.SetRefs();
            m_Walls = GetComponentsInChildren<Wall>();
        }
    }
}