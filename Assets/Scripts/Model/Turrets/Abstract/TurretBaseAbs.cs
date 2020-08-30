using UnityEngine;

namespace Snake_box
{
    public abstract class TurretBaseAbs : IExecute, IModifiersSet
    {
        #region Fields

        protected int TurretLevel = 1;
        protected float FireRateMod = 1;
        protected float ProjectileDamageMod = 1;
        protected float DecreaseUpgradeCost = 1;
        protected float DecreaseBuyCost = 1;
        protected float TurretDistanceMod = 1;
        protected int AbilityLevel = 1; 

        #endregion


        #region Methods

        public abstract void Execute();
        public abstract void SetParentTransform(Transform transform);
        public abstract Transform GetParentTransform();

        public abstract void ReleaseTurret();

        public abstract TurretBaseAbs Build(TurretPreferences turretPreferences);

        public void SetTurretLevel(int newTurretLevel) => TurretLevel = newTurretLevel;
        public void SetFireRate(int newFireRate) => FireRateMod = newFireRate;
        public void SetProjectileDamage(int newProjectileDamage) => ProjectileDamageMod = newProjectileDamage;
        public void SetDecreaseUpgradeCost(int newDecreaseUpgradeCost) => DecreaseUpgradeCost = newDecreaseUpgradeCost;
        public void SetDecreaseBuyCost(int newDecreaseBuyCost) => DecreaseBuyCost = newDecreaseBuyCost;
        public void SetTurretDistance(int newTurretDistance) => TurretDistanceMod = newTurretDistance;
        public void SetAbilityLevel(int newAbilityLevel) => AbilityLevel = newAbilityLevel;

        #endregion
    }
}