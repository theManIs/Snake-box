﻿using System;
using UnityEngine;
 

namespace Snake_box
{
    public sealed class UnityTimeService : Service, ITimeService
    {
        #region Fields

        private int _deltaTimeResetFrame;
        private float _levelStartTime;

        #endregion

        #region ClassLifeCycles

        public UnityTimeService()
        {
            Services.Instance.LevelLoadService.LevelLoaded += ResetLevelStartTime;
        }

        #endregion

        #region Methods

        public float DeltaTime() => _deltaTimeResetFrame == Time.frameCount ? 0.0f : Time.deltaTime;
        public float UnscaledDeltaTime() => _deltaTimeResetFrame == Time.frameCount ? 0.0f : Time.unscaledDeltaTime;
        public float FixedDeltaTime() => _deltaTimeResetFrame == Time.frameCount ? 0.0f : Time.fixedDeltaTime;
        public float RealtimeSinceStartup() => Time.realtimeSinceStartup;
        public float GameTime() => Time.time;
        public long Timestamp() => DateTime.Now.ToUnixTimestamp(); //todo UtcNow
        public void SetTimeScale(float timeScale) => Time.timeScale = timeScale;
        public void ResetDeltaTime() => _deltaTimeResetFrame = Time.frameCount;
        public float TimeSinceLevelStart() => Time.time - _levelStartTime;

        private void ResetLevelStartTime() => _levelStartTime = Time.time;

        #endregion
    }
}
