using UnityEngine;
using UnityEngine.Serialization;

namespace Snake_box
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/BordersData")]
    public class BordersData : ScriptableObject
    {
        [SerializeField] private float _leftBorderX;
        [SerializeField] private float _rightBorderX;
        [SerializeField] private float _topBorderZ;
        [SerializeField] private float _bottomBorderZ;

        public float LeftBorderX => _leftBorderX;
        public float RightBorderX => _rightBorderX;
        public float TopBorderZ => _topBorderZ;
        public float BottomBorderZ => _bottomBorderZ;
    } 
}
