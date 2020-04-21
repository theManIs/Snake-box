using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Snake_box
{
    public class BaseEnemyData : ScriptableObject
    {
        public GameObject SpawnCenter;
        public GameObject Prefab;
        public float Hp;
        public float Speed;
        public float Damage;
        public float SpawnRadius;
        public float SizePack;
        public float PackValue;
    }
}
