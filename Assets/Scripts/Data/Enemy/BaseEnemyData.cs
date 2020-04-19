using System.Collections.Generic;
using UnityEngine;

namespace Snake_box
{
    public class BaseEnemyData : ScriptableObject
    {
        public GameObject SpawnCenter;
        public GameObject prefab;
        public float hp;
        public float speed;
        public float damage;
        public float SpawnRadius;
        public float sizepack;
        public float packvalue;
    }
}
