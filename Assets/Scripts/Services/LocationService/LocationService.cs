using UnityEngine;


namespace BottomlessCloset
{
    public sealed class LocationService : Service
    {
        #region Fields

        private const string CURRENT_LOCATION = "CurrentLocation";
        private readonly LocationData _locationData;
        private readonly ISaveData _saveData;
        private readonly int _maxCountLocation;
        private int _currentLocation;

        #endregion
        
        
        #region Propertis
        
        public int CurrentLocation => _currentLocation;

        #endregion

        
        #region ClassLifeCycles

        public LocationService(ISaveData saveData)
        {
            _locationData = Data.Instance.Location;
            _saveData = saveData;
            _maxCountLocation = _locationData.CountLocation;
            _currentLocation = _saveData.GetInt(CURRENT_LOCATION);
        }

        #endregion

        
        #region Methods

        public void Load()
        {
            var info = _locationData.GetLocationData(_currentLocation);

            var location = CustomResources.Load<GameObject>(AssetsPathLocation.Location[info.LocationType]);
            Object.Instantiate(location);

            foreach (var itemType in info.ItemsType)
            {
                var item = CustomResources.Load<ItemBehaviour>(AssetsPathItem.Item[itemType]);
                var itemBehaviour = Object.Instantiate(item);
                itemBehaviour.Add();
            }
        }


        public void NextLocation()
        {
            if (IsThereNext())
            {
                _saveData.GetInt(CURRENT_LOCATION, ++_currentLocation);
                Load();
            }
        }


        public bool IsThereNext() => _currentLocation + 1 < _maxCountLocation;

        #endregion
    }
}
