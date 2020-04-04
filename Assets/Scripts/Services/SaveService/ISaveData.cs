using System;


namespace BottomlessCloset
{
    public interface ISaveData
    {
        int GetInt(string key, int defaultValue = 0);
        void SetInt(string key, int value);

        long GetLong(string key, long defaultValue = 0);
        void SetLong(string key, long value);
        
        float GetFloat(string key, float defaultValue = 0.0f);
        void SetFloat(string key, float value);

        string GetString(string key, string defaultValue = null);
        void SetString(string key, string value);
        
        bool GetBool(string key, bool defaultValue);
        void SetBool(string key, bool value);
        
        DateTime GetDate(string key);
        void SetDate(string key, DateTime value);

        byte[] GetData(string key);
        void SetData(string key, byte[] value);

        bool HasKey(string key);
        void DeleteKey(string key);
        void DeleteAll();
        void Save();
    }
}
