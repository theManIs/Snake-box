using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Data/Character/CharacterData")]
    public sealed class CharacterData : ScriptableObject
    {
        [SerializeField] private float _hp; //здоровье змейки без блоков
        [SerializeField] private float _armor;//силовое поле
        [SerializeField] private float _regenerationArmor; //регенирация силового поля 
        [SerializeField] private float _speedRotation;// скорость поворота
        [SerializeField] private float _speed;// скорость 
        [SerializeField] private float _damage;
        [Range(0, 1000)] [SerializeField] private float _slowSpeed; //Замедление
        [HideInInspector] public CharacterBehaviour CharacterBehaviour;  
        private ITimeService _timeService;

        public void Initialization()
        {
            var characterBehaviour = CustomResources.Load<CharacterBehaviour>
                (AssetsPathGameObject.GameObjects[GameObjectType.Character]);
            CharacterBehaviour = Instantiate(characterBehaviour);
            _timeService = Services.Instance.TimeService;
        }
        
        public float GetSpeed()
        { 
            return _speed * _timeService.DeltaTime();
        }       

        public float GetSlow()
        {
            return _slowSpeed;
        }
        
        public float GetSpeedRotation()
        {
            return _speedRotation;
        }

        public float GetHp()
        {
            return _hp;
        }

        public float GetArmor()
        {
            return _armor;
        }
        public float GetDamage()
        {
            return _damage;
        }
    }
}