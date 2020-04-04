using System.Collections.Generic;


namespace BottomlessCloset
{
    public sealed class TimeRemainingCleanUp : ICleanUp
    {      
        #region Fields
                   
        private readonly List<ITimeRemaining> _timeRemainings;
                   
        #endregion
           
                   
        #region ClassLifeCycles
           
        public TimeRemainingCleanUp()
        {
            _timeRemainings = TimeRemainingExtensions.TimeRemainings;
        }
                   
        #endregion
        
        
        #region ICleanUp

        public void Cleaner()
        {
            _timeRemainings.Clear();
        }

        #endregion
    }
}