using System.Collections.Generic;


namespace BottomlessCloset
{
    public sealed class AssetsPathItem
    {
        #region Fields

        public static readonly Dictionary<ItemType, string> Item = new Dictionary<ItemType, string>
        {
            {
                ItemType.Shirt, "Prefabs/Items/Prefabs_Items_Shirt"
            },
            {
                ItemType.Underpants, "Prefabs/Items/Prefabs_Items_Underpants"
            }
        };

        #endregion
    }
}
