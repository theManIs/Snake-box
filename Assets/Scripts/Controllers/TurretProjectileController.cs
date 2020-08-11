using System.Collections.Generic;
using System.Linq;


namespace Snake_box
{
    public sealed class TurretProjectileController : IExecute, IInitialization
    {
        #region Fields
        
        private static List<TurretProjectileAbs> _turretProjectiles = new List<TurretProjectileAbs>(); 

        #endregion


        #region IInitialization

        public void Initialization() => CannonShellBuilder.SetTurretProjectileController(this);

        #endregion


        #region Methods

        public void AddShell(TurretProjectileAbs tpa) => _turretProjectiles.Add(tpa);

        #endregion


        #region IExecute

        public void Execute()
        {
            _turretProjectiles.ForEach(iExecutable => iExecutable.Execute());

            _turretProjectiles = _turretProjectiles.Where(x => !x.IsToDispose()).ToList();

            //            Debug.Log(new StackTrace(true).GetFrame(1).GetFileLineNumber() + ": to dispose " +_turretProjectiles.Count(x => !x.IsToDispose()));
            //            Debug.Log(new StackTrace(true).GetFrame(1).GetFileLineNumber() + ": whole count " +_turretProjectiles.Count);
        } 

        #endregion
    }
}