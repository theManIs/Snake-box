using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "SpriteDictonary", menuName = "Data/Sprites/SpriteDictonary")]
    public class SpriteDictionary : ScriptableObject
    {
        [SerializeField] private List<SpriteDictionaryPair> pairs = new List<SpriteDictionaryPair>();

        public Sprite GetSprite(string name)
        {
            Sprite result = pairs.SingleOrDefault(x => x.Name == name).Sprite;
            if (result == null)
                throw new ArgumentException($"Sprite named {name} doesn't exist in sprite dictionary");
            return result;
        }
    }

}