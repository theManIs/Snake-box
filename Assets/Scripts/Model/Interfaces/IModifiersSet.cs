namespace Snake_box
{
    public interface IModifiersSet
    {
        void SetTurretLevel(int newTurretLevel);
        void SetFireRate(int newFireRate);
        void SetProjectileDamage(int newProjectileDamage);
        void SetDecreaseUpgradeCost(int newDecreaseUpgradeCost);
        void SetDecreaseBuyCost(int newDecreaseBuyCost);
        void SetTurretDistance(int newTurretDistance);
        void SetAbilityLevel(int newAbilityLevel);
    }
}