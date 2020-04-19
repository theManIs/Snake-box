namespace ExampleTemplate
{
    public enum TagType : byte
    {
        None   = 0,
        Player = 1, //Змейка
        Floor  = 2,
        Base   = 3,//База
        Block  = 4,//Блоки из которых состоит Хвост
        Bonus  = 5,// Бонус
        Wall   = 6//препятсвие : стены ,преграды и т.д.
    }
}
