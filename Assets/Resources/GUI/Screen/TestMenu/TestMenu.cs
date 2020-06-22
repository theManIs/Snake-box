using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake_box
{
    public class TestMenu : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ScreenInterface.GetInstance().Execute(ScreenType.TestMenu);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
