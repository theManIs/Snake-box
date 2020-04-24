namespace Assets.Scripts.Model.Turrets
{
    public sealed class TurretProjectile : TurretProjectileAbs
    {
        #region Fields

        public float CarryingDamage = 10;
        public ArmorTypes PiercingArmor = ArmorTypes.Bare;
        private int _bulletSpeed = 10;

        #endregion


        #region TurretProjectileAbs

        public override ArmorTypes GetArmorType() => PiercingArmor;

        public override float GetCarryingDamage() => CarryingDamage;

        public override int GetBulletSpeed() => _bulletSpeed;

        public override void Execute() => MoveAutoTarget();

        #endregion
    }
}
