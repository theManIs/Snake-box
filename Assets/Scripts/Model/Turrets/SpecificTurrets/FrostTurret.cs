namespace Snake_box
{
    public class FrostTurret : TurretInitializer
    {
        #region Methods

        protected override ProjectileBuilderAbs GetProjectile() => new ShotgunShellBuilder().SetProjectilePreferences(TurretPreferences.ProjectilePreferences);

        #endregion 
    }
}