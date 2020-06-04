using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Data/Character/CharacterData")]
    public sealed class CharacterData : ScriptableObject
    {
        public float Hp; //здоровье змейки без блоков
        public float Armor;//силовое поле
        public float RegenerationArmor; //регенирация силового поля 
        public float SpeedRotation;// скорость поворота
        public float Speed;// скорость 
        public float Damage;
        public float SlowBlockSpeed;
    }
}