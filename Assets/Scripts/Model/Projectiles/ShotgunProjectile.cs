namespace Snake_box
{
    public sealed class ShotgunProjectile : TurretProjectileAbs
    {
        #region TurretProjectileAbs

        public override void Execute() => MoveInCone();

        #endregion
    }
}
