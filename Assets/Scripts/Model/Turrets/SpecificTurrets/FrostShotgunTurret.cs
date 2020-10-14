namespace Snake_box
{
    public class FrostShotgunTurret : TurretInitializer
    {
        #region Methods

        protected override ProjectileBuilderAbs GetProjectile() => new ShotgunShellBuilder().SetProjectilePreferences(TurretPreferences.ProjectilePreferences);

        #endregion 
    }
}