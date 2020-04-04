using System.Collections.Generic;


namespace BottomlessCloset
{
    public sealed class AssetsPathGameObject
    {
        #region Fields

        public static readonly Dictionary<GameObjectType, string> GameObjects = new Dictionary<GameObjectType, string>
        {
            {
                GameObjectType.Canvas, "GUI/GUI_Canvas"
            }
        };

        #endregion
    }
}
