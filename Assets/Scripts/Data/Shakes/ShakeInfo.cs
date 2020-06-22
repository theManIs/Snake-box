using System;
using UnityEngine;


namespace Snake_box
{
    [Serializable]
    public struct ShakeInfo
    {
        public float Duration;
        public float Strength;
        public int Vibrato;

        [Range(0.0f, 90.0f)]
        public float Randomness;
    }
}
