using System;
using System.IO;
// using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;


namespace BottomlessCloset
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        #region Fields
        
        [SerializeField] private string _shakeDataPath;
        [SerializeField] private string _locationPath;
        [SerializeField] private string _itemDataPath;
        private static ShakesData _shake;
        private static LocationData _location;
        private static ItemData _itemData;
        private static readonly Lazy<Data> _instance = new Lazy<Data>(() => Load<Data>("Data/" + typeof(Data).Name));
        
        #endregion
        

        #region Properties

        public static Data Instance => _instance.Value;

        public ShakesData Shakes
        {
            get
            {
                if (_shake == null)
                {
                    _shake = Load<ShakesData>("Data/" + Instance._shakeDataPath);
                }

                return _shake;
            }
        }

        public LocationData Location
        {
            get
            {
                if (_location == null)
                {
                    _location = Load<LocationData>("Data/" + Instance._locationPath);
                }

                return _location;
            }
        }

        public ItemData ItemData
        {
            get
            {
                if (_itemData == null)
                {
                    _itemData = Load<ItemData>("Data/" + Instance._itemDataPath);
                }

                return _itemData;
            }
        }

        #endregion


        #region Methods

        private static T Load<T>(string resourcesPath) where T : Object =>
            CustomResources.Load<T>(Path.ChangeExtension(resourcesPath, null));
        
        
        
        // [InitializeOnLoadMethod]
        private static void CustomSetup()
        {
            _shake = null;
            _location = null;
            _itemData = null;
        }
    
        #endregion
    }
}
