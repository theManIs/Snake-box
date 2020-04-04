using System.Collections.Generic;


namespace BottomlessCloset
{
    public static partial class ItemExtensions
    {
        #region Fields
        
        private static readonly List<ItemBehaviour> _items = new List<ItemBehaviour>(10);
        
        #endregion
        
        
        #region Properties

        public static List<ItemBehaviour> Items => _items;
        
        #endregion
        
        
        #region Methods

        public static void Add(this ItemBehaviour value)
        {
            if (_items.Contains(value))
            {
                return;
            }

            _items.Add(value);
        }

        public static void Remove(this ItemBehaviour value)
        {
            if (!_items.Contains(value))
            {
                return;
            }
            _items.Remove(value);
        }
        
        #endregion
    }
}
