namespace Snake_box
{
    public sealed class TurretProjectile : TurretProjectileAbs
    {
        #region Fields

        private readonly float _carryingDamage;
        public ArmorTypes PiercingArmor = ArmorTypes.Bare;
        private readonly int _bulletSpeed;

        #endregion

        #region LifeCycleMethods

        public TurretProjectile()
        {
            _bulletSpeed = Data.Instance.ShellData.PlainShellSpeed;
            _carryingDamage = Data.Instance.ShellData.PlainShellDamage;
        }

        #endregion

        #region TurretProjectileAbs

        public override ArmorTypes GetArmorType() => PiercingArmor;

        public override float GetCarryingDamage() => _carryingDamage;

        public override int GetBulletSpeed() => _bulletSpeed;

        public override void Execute() => MoveAutoTarget();

        #endregion
    }
}
