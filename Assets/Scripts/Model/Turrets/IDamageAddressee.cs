namespace Assets.Scripts.Model.Turrets
{
    public interface IDamageAddressee
    {
        void RegisterDamage(float damageAmount, ArmorTypes damageType);
    }
}