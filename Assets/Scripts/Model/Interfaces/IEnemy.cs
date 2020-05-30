using UnityEngine;

namespace Snake_box
{
    public interface IEnemy
    {
        #region Methods

        void OnUpdate();

        void Spawn(Vector3 position);

        Transform GetTransform();

        bool AmIDestroyed();

        Vector3 GetPosition();

        EnemyType GetEnemyType();

        bool IsValidTarget();

        #endregion
    }
}
