using System.Collections.Generic;
using System.Linq;
using ExampleTemplate;

namespace Snake_box
{
    public sealed class TurretController : IExecute, IInitialization
    {
        #region Fields

        private static TurretController _hiddenInstance;
        private TurretInitializer _newTurret;
        private List<TurretBaseAbs> _turretList = new List<TurretBaseAbs>();

        #endregion


        #region IInitializaion

        public void Initialization()
        {
            _hiddenInstance = this;
        }

        #endregion


        #region Execute

        public void Execute()
        {
            _turretList = _turretList.Where(x => x != null ? true : false).ToList();

            _turretList.ForEach(iExecutable => iExecutable.Execute());
        }

        #endregion


        #region Methods

        public void SetTurretList(List<TurretBaseAbs> tl) => _turretList = tl;

        public static TurretController GetInstance() => _hiddenInstance;

        #endregion
    }
}