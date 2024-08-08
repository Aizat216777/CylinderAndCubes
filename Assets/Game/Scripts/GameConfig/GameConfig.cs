using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "MKGames/GameConfig"), System.Serializable]
    public class GameConfig : ScriptableObject
    {
        public SpawnCubeData spawnCubeData;
        public PrefabsData prefabsData;
        public CubeData cubeData;
        public HeroData heroData;
        [System.Serializable]
        public class SpawnCubeData
        {
            public Vector2Int rangeAmount;
        }
        [System.Serializable]
        public class PrefabsData
        {
            public Cube cube;
            public Bullet bullet;
        }
        [System.Serializable]
        public class CubeData
        {
            public RandomMoveData randomMoveData;
            public HunterData hunterData;
            [System.Serializable]
            public class RandomMoveData
            {
                public float delayToChangeDirection;
                public float force;
            }
            [System.Serializable]
            public class HunterData
            {
                public float force;
            }
        }
        [System.Serializable]
        public class HeroData
        {
            public ShootData shootData;
            [System.Serializable]
            public class ShootData
            {
                public float delayToShoot;
                public float force;
            }
        }
    }
}