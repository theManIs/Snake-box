using UnityEngine;
using UnityEngine.AI;


namespace Snake_box
{
    public class BaseEnemyData : ScriptableObject
    {
        public ArmorType ArmorType;
        public GameObject Prefab;
        public float Hp;
        public float Speed;
        public float Damage;
        public float SizePack;
        public float PackValue;
        public float MeleeHitRange;
        public int KillReward;
    }
}
