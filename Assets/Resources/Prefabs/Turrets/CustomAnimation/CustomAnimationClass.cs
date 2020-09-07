using UnityEngine;

namespace Snake_box
{
    public enum SimpleAnimationTypes
    {
        CeaseFire = 0,
        OpenFire = 10
    }

    public class CustomAnimationClass : MonoBehaviour
    {
        public Animator CharacterAnimator;
        public bool OpenFire = false;
        public bool WasFireOpened = false;

        void Start()
        {
            CharacterAnimator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (WasFireOpened)
            {
                WasFireOpened = false;
                CharacterAnimator.SetInteger("WeaponType_int", (int)SimpleAnimationTypes.CeaseFire);
            }

            if (OpenFire)
            {
                OpenFire = false;
                WasFireOpened = true;
                CharacterAnimator.SetInteger("WeaponType_int", (int)SimpleAnimationTypes.OpenFire);
            }
        }

        public void DoOpenFire()
        {
            OpenFire = true;
        }
    }
}
