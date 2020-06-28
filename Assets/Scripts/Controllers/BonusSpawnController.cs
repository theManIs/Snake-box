using UnityEngine;


namespace Snake_box
{
    public class BonusSpawnController : IInitialization ///отвечает за место и время спауна
    {
        #region PrivateData

        private GameObject[] _spawnPoints;//точки споуна бонусов
        private TimeRemaining _spawnInvoker;
        private BonusList _bonuses;//список всех бонусов
        private int _spawnTime= 25;       

        #endregion


        #region Methods

        public void Initialization()
        {
            if (_spawnPoints == null)
            {
                _spawnPoints = GameObject.FindGameObjectsWithTag(TagManager.GetTag(TagType.BonusPoint));
            }
            _spawnInvoker = new TimeRemaining(SpawnBonus, _spawnTime, true);
            _spawnInvoker.AddTimeRemaining();
            _bonuses = new BonusList();
        }        

        private void SpawnBonus()
        {
            int random = Random.Range(0, _bonuses._bonusList.Count);
            int point = Random.Range(0, _spawnPoints.Length);
            _bonuses._bonusList[3].Spawn(_spawnPoints[21].transform.position);         ///загружается 3(random) бонус в 5(point) точке   
        }

        #endregion

    }
}
