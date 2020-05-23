using UnityEngine;

namespace Snake_box
{
    public static partial class Vector3Extensions
    {
        public static Vector3 GetRoundPosition(this Vector3 value)
        {
            value.x = Mathf.Round(value.x * 100f)/100f;
            value.y = Mathf.Round(value.y * 100f)/100f;
            value.z = Mathf.Round(value.z * 100f)/100f;
            return value;
        }
        public static float CalcDistance(this Vector3 from, Vector3 to)
        {
            var distanceX = to.x - from.x;
            var distanceY = to.y - from.y;
            var distanceZ = to.z - from.z;

            return distanceX * distanceX + distanceY * distanceY + distanceZ * distanceZ;
        }
    }
}
