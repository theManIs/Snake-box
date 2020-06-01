using System.Collections.Generic;

namespace Snake_box
{
    public static class TagManager
    {
        private static readonly Dictionary<TagType, string> _tags;

        static TagManager()
        {
            _tags = new Dictionary<TagType, string>
            {
                {TagType.Player, "Player"},
                {TagType.Floor, "Floor"},                                               
                {TagType.Block, "Block"},               
                {TagType.Bonus, "Bonus"},
                {TagType.Base, "Base"},
                {TagType.Wall, "Wall"},
                {TagType.Target, "Target"},
                {TagType.Spawn, "Spawn"},
                {TagType.PanelEndLevel, "PanelEndLevel"},
                {TagType.BonusPoint, "BonusPoint"}
                
            };
        }

        public static string GetTag(TagType tagType)
        {
            return _tags[tagType];
        }
    }
}
