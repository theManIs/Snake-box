namespace Snake_box
{
    public class ShotgunTurret : TurretInitializer
    {
        #region Methods

        protected override ProjectileBuilderAbs GetProjectile() => new ShotgunShellBuilder().SetProjectilePreferences(TurretPreferences.ProjectilePreferences); 

        #endregion
    }
}