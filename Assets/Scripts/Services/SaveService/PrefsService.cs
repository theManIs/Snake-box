using System;
using System.Text;


namespace ExampleTemplate
{
    public sealed class PrefsService : Service, ISaveData
    {        
        #region Fields

        private static readonly DateTime DefaultDateTimeValue = DateTime.Now;
        
        #endregion

        #region ISaveData

        public int GetInt(string key, int defaultValue = 0) => CustomPlayerPrefs.GetInt(key, defaultValue);
        public void SetInt(string key, int value) => CustomPlayerPrefs.SetInt(key, value);

        public long GetLong(string key, long defaultValue = 0)
        {
            if (!HasKey(key))
            {
                return defaultValue;
            }

            return Convert.ToInt64(GetString(key));
        }

        public void SetLong(string key, long value) => CustomPlayerPrefs.SetString(key, value.ToString());
        public float GetFloat(string key, float defaultValue = 0.0f) => CustomPlayerPrefs.GetFloat(key, defaultValue);
        public void SetFloat(string key, float value) => CustomPlayerPrefs.SetFloat(key, value);

        public string GetString(string key, string defaultValue = null)
        {
            string result = CustomPlayerPrefs.GetString(key, defaultValue);
            // HACK PlayerPrefs.GetString returns an empty string
            // despite of the default value was set to null
            if (defaultValue == null && string.IsNullOrEmpty(result))
            {
                result = null;
            }

            return result;
        }

        public void SetString(string key, string value) => CustomPlayerPrefs.SetString(key, value);
        public bool GetBool(string key, bool defaultValue) => CustomPlayerPrefs.GetBool(key, defaultValue);
        public void SetBool(string key, bool value) => CustomPlayerPrefs.SetBool(key, value);
        public DateTime GetDate(string key) => CustomPlayerPrefs.GetDateTime(key, DefaultDateTimeValue);
        public void SetDate(string key, DateTime value) => CustomPlayerPrefs.SetDateTime(key, value);

        public byte[] GetData(string key)
        {
            string stringData = GetString(key);
            if (string.IsNullOrEmpty(stringData))
            {
                return null;
            }

            #if USE_BASE64_DATA_ENCODING
                return System.Convert.FromBase64String(stringData);
            #else
            return Encoding.Default.GetBytes(stringData);
            #endif
        }

        public void SetData(string key, byte[] value)
        {
            #if USE_BASE64_DATA_ENCODING
                string stringData = System.Convert.ToBase64String(value);
            #else
            string stringData = Encoding.Default.GetString(value);
            #endif

            CustomPlayerPrefs.SetString(key, stringData);
        }

        public bool HasKey(string key) => CustomPlayerPrefs.HasKey(key);
        public void DeleteKey(string key) => CustomPlayerPrefs.DeleteKey(key);
        public void DeleteAll() => CustomPlayerPrefs.DeleteAll();
        public void Save() => CustomPlayerPrefs.Save();

        #endregion
    }
}
