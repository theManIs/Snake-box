using UnityEngine;

namespace Snake_box
{
    public interface IEnemy
    {
        #region Methods

        void OnUpdate();

        void Spawn();

        Transform GetTransform();

        bool AmIDestroyed();

        Vector3 GetPosition();

        EnemyType GetEnemyType(); 

        #endregion
    }
}
