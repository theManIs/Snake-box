using System;
using System.IO;
using UnityEngine;


namespace BottomlessCloset
{
    public sealed class JsonService : Service
    {
        #region Fields

        private readonly string _folderName = "dataSave";
        private readonly string _path;

        #endregion
        

        #region ClassLifeCycles

        public JsonService()
        {
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        #endregion
        

        #region Methods

        public void Save<T>(string fileName, T dataSave) where T : Type
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            var filePath = Path.Combine(_path, fileName);
            var json = JsonUtility.ToJson(dataSave);
            File.WriteAllText(filePath, json);
        }

        public void Load<T>(string fileName, T dataSave) where T : Type
        {
            var filePath = Path.Combine(_path, fileName);
            if(!File.Exists(filePath)) return;
            var json = File.ReadAllText(filePath);
            JsonUtility.FromJson(json, dataSave);
        }

        #endregion
    }
}
