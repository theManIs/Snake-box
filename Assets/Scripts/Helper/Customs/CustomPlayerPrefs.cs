using System;
using UnityEngine;


namespace ExampleTemplate
{
    public sealed class CustomPlayerPrefs 
    {
        #region Fields

        private const string DOUBLE_FORMAT_SPECIFIER      = "G17";

        public static readonly string DEFAULT_STRING      = string.Empty;
        public static readonly DateTime DEFAULT_DATE_TIME = DateTime.MinValue;   

        private const int       DEFAULT_INT_VALUE         = 0;
        private const int       BOOL_TRUE_INT_VALUE       = 1;
        private const int       BOOL_FALSE_INT_VALUE      = 0;
        private const float     DEFAULT_FLOAT_VALUE       = 0f;
        private const double    DEFAULT_DOUBLE_VALUE      = 0d;
        
        #endregion
        

        #region Methods
        
        public static void SetBool(string key, bool value, bool isSaveImmediately = false)
        {
            int targetValue = (value) ? (BOOL_TRUE_INT_VALUE) : (BOOL_FALSE_INT_VALUE);
            SetInt(key, targetValue, isSaveImmediately);
        }

        public static void SetFloat(string key, float value, bool isSaveImmediately = false)
        {
            PlayerPrefs.SetFloat(key, value);
            
            if (isSaveImmediately)
            {
                Save();
            }
        }

        public static void SetDouble(string key, double value, bool isSaveImmediately = false)
        {
            PlayerPrefs.SetString(key, value.ToString(DOUBLE_FORMAT_SPECIFIER));

            if (isSaveImmediately)
            {
                Save();
            }
        }

        public static void SetInt(string key, int value, bool isSaveImmediately = false)
        {
            PlayerPrefs.SetInt(key, value);

            if (isSaveImmediately)
            {
                Save();
            }
        }
        
        public static void SetDateTime(string key, DateTime value, bool isSaveImmediately = false)
        {
            PlayerPrefs.SetString(key, value.ToBinary().ToString());

            if (isSaveImmediately)
            {
                Save();
            }
        }

        public static void SetString(string key, string value, bool isSaveImmediately = false)
        {
            PlayerPrefs.SetString(key, value);
            
            if (isSaveImmediately)
            {
                Save();
            }
        }

        public static void SetEnumValue<T>(string key, T value, bool isSaveImmediately = false) 
            where T : struct, IConvertible
        {
            SetString(key, value.ToString(), isSaveImmediately);
        }
            
        public static void SetObjectValue<T>(string key, T value, bool saveImmediately = false)
            where T : class
        {
            string objectValue = (value == null) ? (string.Empty) : (JsonUtility.ToJson(value));

            SetString(key, objectValue, saveImmediately);
        }
        
        public static bool GetBool(string key)
        {
            return (GetInt(key) == BOOL_TRUE_INT_VALUE);
        }

        public static bool GetBool(string key, bool defaultValue)
        {
            int currentDefaultValue = (defaultValue) ? (BOOL_TRUE_INT_VALUE) : (BOOL_FALSE_INT_VALUE);
            return (GetInt(key, currentDefaultValue) == BOOL_TRUE_INT_VALUE);
        }

        public static float GetFloat(string key)
        {
            return GetFloat(key, DEFAULT_FLOAT_VALUE);
        }

        public static float GetFloat(string key, float defaultValue)
        {
            return PlayerPrefs.GetFloat(key, defaultValue);
        }

        public static double GetDouble(string key)
        {
            return GetDouble(key, DEFAULT_DOUBLE_VALUE);
        }

        public static double GetDouble(string key, double defaultValue)
        {
            string savedString = PlayerPrefs.GetString(key);
            double result = defaultValue;

            if (!string.IsNullOrEmpty(savedString))
            {
                double parsedValue = 0d;
                if (double.TryParse(savedString, out parsedValue))
                {
                    result = parsedValue;
                }
            }

            return result;
        }

        public static int GetInt(string key)
        {
            return GetInt(key, DEFAULT_INT_VALUE);
        }

        public static int GetInt(string key, int defaultValue)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public static DateTime GetDateTime(string key)
        {
            return GetDateTime(key, DEFAULT_DATE_TIME);
        }

        public static DateTime GetDateTime(string key, DateTime defaultValue)
        {
            string savedString = PlayerPrefs.GetString(key);
            DateTime result = defaultValue;

            if (!string.IsNullOrEmpty(savedString))
            {
                long temp = Convert.ToInt64(savedString);
                result = DateTime.FromBinary(temp);
            }

            return result;
        }

        public static string GetString(string key)
        {
            return GetString(key, DEFAULT_STRING);
        }

        public static string GetString(string key, string defaultValue)
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }

        public static T GetEnumValue<T>(string key, T defaultValue = default(T)) 
            where T : struct, IConvertible
        {
            string value = GetString(key);        
            if (!string.IsNullOrEmpty(value))
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            
            return defaultValue;
        }

        public static T GetObjectValue<T>(string key) where T : class
        {
            string savedObjectValue = GetString(key);

            return (string.IsNullOrEmpty(savedObjectValue))
                ? (null)
                : (JsonUtility.FromJson<T>(savedObjectValue));
        }
        
        public static bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        public static void DeleteKey(string key)
        {
            PlayerPrefs.DeleteKey(key);

            Save();
        }

        public static void DeleteAll()
        {
            PlayerPrefs.DeleteAll();

            Save();
        }

        public static void Save()
        {
            PlayerPrefs.Save();
        }
        
        #endregion
    }
}
