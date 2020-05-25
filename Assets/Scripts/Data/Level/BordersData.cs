using UnityEngine;

namespace Snake_box
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/BordersData")]
    public class BordersData : ScriptableObject
    {
        [SerializeField] private float _leftBorderX;
        [SerializeField] private float _rightBorderX;
        [SerializeField] private float _topBorderY;
        [SerializeField] private float _bottomBorderY;

        public float LeftBorderX => _leftBorderX;
        public float RightBorderX => _rightBorderX;
        public float TopBorderY => _topBorderY;
        public float BottomBorderY => _bottomBorderY;
    } 
}
