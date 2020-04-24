using System.Collections.Generic;

namespace Snake_box
{
    public static partial class TurretExtension
    {
        private static List<TurretBaseAbs> _turretList = new List<TurretBaseAbs>();

        public static TurretBaseAbs AddNewTurret(this TurretController value)
        {
            TurretBaseAbs newTurret = new TurretInitializer();

            _turretList.Add(newTurret);
            value.SetTurretList(_turretList);

            return newTurret;
        }
    }
}