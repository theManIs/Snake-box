using UnityEngine;


namespace BottomlessCloset
{
    [CreateAssetMenu(fileName = "LocationData", menuName = "Data/Location/LocationData")]
    public sealed class LocationData : ScriptableObject
    {
        [SerializeField] private LocationInfo[] LocationInfos;
        
        public int CountLocation => LocationInfos.Length;

        public LocationInfo GetLocationData(int locationIndex)
        {
            if (locationIndex <= 0 && locationIndex > LocationInfos.Length)
            {
                return LocationInfos[LocationInfos.Length];
            }
            
            return LocationInfos[locationIndex];
        }
    }
}
