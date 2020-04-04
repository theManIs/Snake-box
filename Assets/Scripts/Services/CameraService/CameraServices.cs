using UnityEngine;


namespace BottomlessCloset
{
    public sealed class CameraServices : Service
    {
        #region ClassLifeCycles

        public CameraServices()
        {
            SetCamera(Camera.main);
        }

        #endregion
        
        
        #region Properties

        public Camera CameraMain { get; private set; }

        #endregion
        
        
        #region Methods


        // public void CreateShake(ShakeType shakeType)
        // {
        //     var shakeInfo = Data.Instance.Shakes.GetShakeInfo(shakeType);
        //
        //     Tweener tweener = DOTween.Shake(() => CameraMain.transform.position, pos => CameraMain.transform.position = pos,
        //         shakeInfo.Duration, shakeInfo.Strength, shakeInfo.Vibrato, shakeInfo.Randomness);
        // }


        // public void MoveToPosition(Vector3 position, float moveDuration,
        //     Ease ease = Ease.OutSine)
        // {
        //     if (CameraMain.transform.hasTweener)
        //     {
        //         CameraMain.transform.tweener.value.Kill();
        //         CameraMain.transform.RemoveTweener();
        //     }
        //
        //     Tweener tweener = DOTween.To(() => CameraMain.transform.position, CameraMain.transform.position,
        //         position, moveDuration).SetEase(ease).OnComplete(CameraMain.transform.RemoveTweener);
        // }
        

        public void SetCamera(Camera camera)
        {
            CameraMain = camera;
        }

        #endregion
    }
}
