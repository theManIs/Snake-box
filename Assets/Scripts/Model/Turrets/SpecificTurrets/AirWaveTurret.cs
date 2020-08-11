namespace Snake_box
{
    public class AirWaveTurret : TurretInitializer
    {
        #region Methods

        protected override ProjectileBuilderAbs GetProjectile() => new SphereShellBuilder().SetProjectilePreferences(TurretPreferences.ProjectilePreferences);

        #endregion
    }
}