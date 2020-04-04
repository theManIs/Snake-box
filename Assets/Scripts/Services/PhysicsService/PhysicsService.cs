using System.Collections.Generic;
using UnityEngine;


namespace BottomlessCloset
{
    public sealed class PhysicsService : Service
    {
        #region Fields

        private const int COLLIDED_OBJECT_SIZE = 20;

        private readonly Collider2D[] _collidedObjects;
        private readonly RaycastHit2D[] _castBuffer;
        private readonly List<Collider2D> _triggeredObjects;
        private readonly CameraServices _cameraServices;

        #endregion

        
        #region ClassLifeCycles

        public PhysicsService(CameraServices cameraServices) : base()
        {
            _cameraServices = cameraServices;
            _collidedObjects = new Collider2D[COLLIDED_OBJECT_SIZE];
            _castBuffer = new RaycastHit2D[64];
            _triggeredObjects = new List<Collider2D>();
        }

        #endregion

        
        #region Methods

        public bool CheckGround(Vector3 position, float distanceRay, out Vector3 hitPoint, int layerMask = LayerManager.DEFAULT_LAYER)
        {
            hitPoint = Vector2.zero;

            var hit = Physics2D.Raycast(position, Vector3.down, distanceRay, layerMask);
            if (hit.collider == null)
            {
                return false;
            }

            hitPoint = hit.point;
            return true;
        }
        
        public List<Collider2D> GetObjectsInRadius(Vector3 position, float radius, int layerMask = LayerManager.DEFAULT_LAYER)
        {
            _triggeredObjects.Clear();
            Collider2D trigger;

            var collidersCount = Physics2D.OverlapCircleNonAlloc(position, radius, _collidedObjects, layerMask);
            
            for (var i = 0; i < collidersCount; i++)
            {
                trigger = _collidedObjects[i];

                if (trigger != null && !_triggeredObjects.Contains(trigger))
                {
                    _triggeredObjects.Add(trigger);
                }
            }

            return _triggeredObjects;
        }
        
        public HashSet<Collider2D> SphereCastObject(Vector2 center, float radius, HashSet<Collider2D> outBuffer,
            int layerMask = LayerManager.DEFAULT_LAYER)
        {
            outBuffer.Clear();

            var hitCount = Physics2D.OverlapCircleNonAlloc(center, radius, _collidedObjects, layerMask);

            for (var i = 0; i < hitCount; i++)
            {
                var carTriggerProvider = _castBuffer[i].collider;
                if (carTriggerProvider != null)
                {
                    outBuffer.Add(carTriggerProvider);
                }
            }

            return outBuffer;
        }
        
        public Collider2D GetNearestObject(Vector3 targetPosition, HashSet<Collider2D> objectBuffer)
        {
            var nearestDistance = Mathf.Infinity;
            Collider2D result = null;

            foreach (var trigger in objectBuffer)
            {
                var objectDistance = (targetPosition - trigger.transform.position).sqrMagnitude;
                if (objectDistance >= nearestDistance)
                {
                    continue;
                }

                nearestDistance = objectDistance;
                result = trigger;
            }

            return result;
        }

        public int GetIdObject(Vector2 position)
        {
            var raycastHit2D = Physics2D.Raycast(position, Vector2.zero, 0f);
            if (raycastHit2D.collider)
            {
                return raycastHit2D.collider.gameObject.GetInstanceID();
            }

            return -1;
        }

        #endregion
    }
}
