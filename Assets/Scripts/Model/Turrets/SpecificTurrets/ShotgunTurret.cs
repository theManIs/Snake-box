namespace Snake_box
{
    public class ShotgunTurret : TurretInitializer
    {
        protected override ProjectileBuilderAbs GetProjectile() => new ShotgunShellBuilder().SetProjectilePreferences(TurretPreferences.ProjectilePreferences);
    }
}