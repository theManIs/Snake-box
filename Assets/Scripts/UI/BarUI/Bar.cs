using UnityEngine;
using UnityEngine.UI;


namespace Snake_box
{
    public sealed class Bar : MonoBehaviour
    {

        #region Methods

        public static void ShowCount(Button button, float currentCount, float maxCount, Color fullColor, Color halfColor)
        {
            currentCount = currentCount / maxCount;
            button.image.fillAmount = currentCount;
            button.image.color = (currentCount >= 0.6) ? fullColor : halfColor;
        }

        #endregion

    }
}
