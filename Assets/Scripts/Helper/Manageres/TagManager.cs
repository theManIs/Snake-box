using System.Collections.Generic;


namespace ExampleTemplate
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
                {TagType.Wall, "Wall"}
            };
        }

        public static string GetTag(TagType tagType)
        {
            return _tags[tagType];
        }
    }
}
