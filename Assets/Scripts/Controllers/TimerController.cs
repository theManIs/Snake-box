using System;
using UnityEngine;

namespace Snake_box
{
    public class TimerController : IInitialization
    {
        public static TimerController Instance { get; private set; }

        private float _levelStartTime;

        public float TimeSinceLevelStart => Time.time - _levelStartTime;

        public void Initialization()
        {
            if (Instance == null)
                Instance = this;
            else
                throw new InvalidOperationException();

            _levelStartTime = Time.time;
        }
    } 
}
