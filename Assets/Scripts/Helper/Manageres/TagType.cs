namespace Snake_box
{
    public enum TagType : byte
    {
        None   = 0,
        Player = 1, //Змейка
        Floor  = 2,
        Target = 3,
        Block  = 4,//Блоки из которых состоит Хвост
        Bonus  = 5,// Бонус
        Wall   = 6,//препятсвие : стены ,преграды и т.д.
        Base   = 7,//База        
        Spawn  = 8,
        PanelEndLevel = 9,
        Enemy  = 10
    }
}
