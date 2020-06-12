namespace Snake_box
{
    public sealed class CannonProjectile : TurretProjectileAbs
    {
        #region TurretProjectileAbs

        public override void Execute() => MoveAutoTarget();
//        public override void Execute() => MoveInCone();

        #endregion
    }
}
