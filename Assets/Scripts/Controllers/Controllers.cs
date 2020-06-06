using System.Collections.Generic;


namespace Snake_box
{
    public sealed class Controllers : IInitialization, ICleanUp
    {
        #region Fields
        
        private readonly List<IExecute> _executeControllers;
        private readonly List<ICleanUp> _cleanUps;
        private readonly List<IInitialization> _initializations;

        #endregion


        #region Properties
        
        public int Length => _executeControllers.Count;

        public IExecute this[int index] => _executeControllers[index];

        #endregion


        #region ClassLifeCycles

        public Controllers()
        {
            _initializations = new List<IInitialization>();

            _executeControllers = new List<IExecute>();
            _executeControllers.Add(new TimeRemainingController());
            _executeControllers.Add(new InputController());
            _executeControllers.Add(new EnemySpawnControler());
            _executeControllers.Add(new EnemyController());
            _executeControllers.Add(new TurretController());
            _executeControllers.Add(new TurretProjectileController());
            _executeControllers.Add(new CharacterController());

            _cleanUps = new List<ICleanUp>();
            _cleanUps.Add(new TimeRemainingCleanUp());
        }
        
        #endregion


        #region IInitialization

        public void Initialization()
        {
            for (var i = 0; i < _initializations.Count; i++)
            {
                var initialization = _initializations[i];
                initialization.Initialization();
            }
            
            for (var i = 0; i < _executeControllers.Count; i++)
            {
                var execute = _executeControllers[i];
                if (execute is IInitialization initialization)
                {
                    initialization.Initialization();
                }
            }
        }
        
        #endregion
        
        
        #region ICleanUp

        public void Clean()
        {
            for (var index = 0; index < _cleanUps.Count; index++)
            {
                var cleanUp = _cleanUps[index];
                cleanUp.Clean();
            }

            for (var i = 0; i < _executeControllers.Count; i++)
            {
                var execute = _executeControllers[i];
                if (execute is ICleanUp cleanUp)
                {
                    cleanUp.Clean();
                }
            }
        }

        #endregion
    }
}
