using UnityEngine;
using UnityEngine.UI;



namespace Snake_box
{
    public class Bar : MonoBehaviour
    {
        #region Fields    

        private Image _image;

        #endregion


        #region Methods

        public Color ShowCount(float count,Color fullColor,Color halfColor)
        {
            _image.fillAmount = count / 100;
            if (count > 60)
            {               
                return fullColor;
            }
           
            else
            {
                return halfColor;
            }
        }

        #endregion

    }
}
