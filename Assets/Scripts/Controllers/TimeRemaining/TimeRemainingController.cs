using System.Collections.Generic;


namespace ExampleTemplate
{
    public sealed class TimeRemainingController : IExecute
    {
        #region Fields
        
        private readonly List<ITimeRemaining> _timeRemainings;
        private readonly ITimeService _timeService;
        
        #endregion

        
        #region ClassLifeCycles

        public TimeRemainingController()
        {
            _timeRemainings = TimeRemainingExtensions.TimeRemainings;
            _timeService = Services.Instance.TimeService;
        }
        
        #endregion

        
        #region IExecute

        public void Execute()
        {
            var time = _timeService.DeltaTime();
            for (var i = 0; i < _timeRemainings.Count; i++)
            {
                var obj = _timeRemainings[i];
                obj.CurrentTime -= time;
                if (obj.CurrentTime <= 0.0f)
                {
                    obj?.Method?.Invoke();
                    if (!obj.IsRepeating)
                    {
                        obj.RemoveTimeRemaining();
                    }
                    else
                    {
                        obj.CurrentTime = obj.Time;
                    }
                }
            }
        }
        
        #endregion
    }
}
