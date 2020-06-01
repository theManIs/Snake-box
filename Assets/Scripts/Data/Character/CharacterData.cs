using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Data/Character/CharacterData")]
    public sealed class CharacterData : ScriptableObject
    {
        [Range(0, 1000)] public float SlowSpeed; //Замедление
        [HideInInspector] public CharacterBehaviour CharacterBehaviour;  
        public float Hp; //здоровье змейки без блоков
        public float Armor;//силовое поле
        public float RegenerationArmor; //регенирация силового поля 
        public float SpeedRotation;// скорость поворота
        public float Speed;// скорость 
        public float Damage;

        public void Initialization()
        {
            Services.Instance.LevelService.IsSnakeAlive = true;
            var characterBehaviour = CustomResources.Load<CharacterBehaviour>
                (AssetsPathGameObject.GameObjects[GameObjectType.Character]);
            CharacterBehaviour = Instantiate(characterBehaviour);            
        }       
    }
}