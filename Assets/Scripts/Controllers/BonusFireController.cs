namespace Snake_box
{
    public class BonusFireController : IExecute
    {   
        public void Execute()
        {
            if (Services.Instance.LevelService.ActiveBonusBullet.Count != 0)
            {
                for (int i = 0; i < Services.Instance.LevelService.ActiveBonusBullet.Count; i++)
                {
                    Services.Instance.LevelService.ActiveBonusBullet[i].Move();
                }
            }
        }
    }
}
