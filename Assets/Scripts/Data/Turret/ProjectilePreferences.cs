using System;
using UnityEngine;

namespace Snake_box
{
    [Serializable]
    public class ProjectilePreferences
    {
        public GameObject ProjectilePrefab;
        public GameObject ShootingVfxPrefab;
        public int ProjectileSpeed = 50;
        public float ProjectileDamage = 10;
        public bool ProjectileFollowsTarget = true;
        public Vector3 AngleLock = new Vector3(90, 0, 0);
        public ArmorTypes ArmorPiercing = ArmorTypes.None;
        public int NumberOfPeaces = 10;
        public float ActivationDistance = 0.1f;
        public float SelfDestructAfter = 5;
        public Transform ExplosionEffect;
    }
}