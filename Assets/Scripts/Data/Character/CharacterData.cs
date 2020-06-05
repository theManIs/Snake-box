using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Data/Character/CharacterData")]
    public sealed class CharacterData : ScriptableObject
    {
        public float _hp; //здоровье змейки без блоков
        public float _armor;//силовое поле
        public float _regenerationArmor; //регенирация силового поля 
        public float _speedRotation;// скорость поворота
        public float _speed;// скорость 
        public float _damage;
        public float _ramCooldown;
        [Range(0, 1000)] public float _slowSpeed; //Замедление
        [HideInInspector] public CharacterBehaviour _characterBehaviour;  

        public void Initialization()
        {
            Services.Instance.LevelService.IsSnakeAlive = true;
            var characterBehaviour = CustomResources.Load<CharacterBehaviour>
                (AssetsPathGameObject.GameObjects[GameObjectType.Character]);
            _characterBehaviour = Instantiate(characterBehaviour);
            
        }       
    }
}