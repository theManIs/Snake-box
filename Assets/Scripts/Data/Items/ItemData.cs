using UnityEngine;


namespace BottomlessCloset
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Data/Items/ItemData")]
    public sealed class ItemData : ScriptableObject
    {
        public Color SelectColor;
        public Color CollisionColor;
    }
}
