using UnityEngine;

namespace Snake_box
{
    public interface IEnemy
    {
        void OnUpdate();
        void Spawn();
        Transform GetTransform();
        bool AmIDestroyed();
    }
}
