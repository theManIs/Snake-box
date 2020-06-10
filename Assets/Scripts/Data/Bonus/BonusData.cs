using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "BonusData", menuName = "Data/Bonus/BonusData")]
    public class BonusData : ScriptableObject
    {
        public Sprite Icon;// иконка
        public Transform Prefab;// префаб        
        public float LifeTime;//время исчезновения
    }
}
