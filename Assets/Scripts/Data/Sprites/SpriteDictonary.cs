using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "SpriteDictonary", menuName = "Data/Sprites/SpriteDictonary")]
    public class SpriteDictonary : ScriptableObject
    {
        [SerializeField] private List<SpriteDictionaryPair> pairs = new List<SpriteDictionaryPair>();

        public Sprite GetSprite(string name) => pairs.SingleOrDefault(x => x.Name == name).Sprite;
    }

}