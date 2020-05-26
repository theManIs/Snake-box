using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Snake_box
{
    public sealed class Bar
    {

        #region Methods

        public static void ShowCount(Button button, float currentCount, float maxCount, Color fullColor, Color halfColor)
        {
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =((int)currentCount).ToString();
            currentCount = currentCount / maxCount;
            button.image.fillAmount = currentCount;
            button.image.color = (currentCount >= 0.6) ? fullColor : halfColor;
        }

        #endregion

    }
}
