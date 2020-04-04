using UnityEngine;

namespace BottomlessCloset
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
    }
}
