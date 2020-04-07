using UnityEngine;


namespace ExampleTemplate
{
    [CreateAssetMenu(fileName = "ShakesData", menuName = "Data/Shake/ShakesData")]
    public sealed class ShakesData : ScriptableObject
    {
        [SerializeField] private SerializeShakeData[] _shakes;

        public ShakeInfo GetShakeInfo(ShakeType type)
        {
            ShakeInfo result = default;
            foreach (var shakeData in _shakes)
            {
                if (shakeData.ShakeType == type)
                {
                    result = shakeData.ShakeInfo;
                }
            }

            return result;
        }
    }
}

