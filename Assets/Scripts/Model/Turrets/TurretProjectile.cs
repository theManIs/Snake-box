namespace Assets.Scripts.Model.Turrets
{
    public sealed class TurretProjectile : TurretProjectileAbs
    {
        #region Fields

        public float CarryingDamage = 10;
        public ArmorTypes PiercingArmor = ArmorTypes.Bare; 

        #endregion


        #region TurretProjectileAbs

        public override ArmorTypes GetArmorType() => PiercingArmor;

        public override float GetCarryingDamage() => CarryingDamage; 

        #endregion
    }
}
