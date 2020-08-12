using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusDemoCharacter : MonoBehaviour
{
    public float BusSpeed = 2f;
    public float SteerSpeed = 2f;
    public Camera BusCamera;
    public float CameraSmoothness = 10;

    private CharacterController _characterController;
    private float _accumulatedRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        Vector3 localPosition = transform.position;
        localPosition.y = localPosition.y < 0 ? 0 : localPosition.y;
        transform.position = localPosition;

        if (BusCamera)
        {
            BusCamera.transform.parent = null;

        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startTransform = transform.position;
        Quaternion startRotation = transform.rotation;
        Vector3 controllerVelocity = transform.forward * Input.GetAxis("Vertical");
        //        controllerVelocity = controllerVelocity + new Vector3(Input.GetAxis("Vertical"), 0, 0);
        //        controllerVelocity.z = Input.GetAxis("Horizontal");

        _characterController.Move(controllerVelocity * Time.deltaTime * BusSpeed);
        _characterController.Move(Vector3.down * Time.deltaTime * BusSpeed);

//        if (controllerVelocity != default && controllerVelocity.x > 0)
//        {
////            controllerVelocity.z = Mathf.Lerp(0, controllerVelocity.z, Time.deltaTime * BusSpeed);
//            transform.forward = controllerVelocity;
//        }

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            float absoluteRotation = Time.deltaTime * SteerSpeed * Input.GetAxis("Horizontal");
            _accumulatedRotation += absoluteRotation;

            transform.Rotate(Vector3.up, absoluteRotation);
        }

        /*Vector3 localPosition = transform.position;
        localPosition.y = 0;
        transform.position = localPosition;*/

        if (BusCamera)
        {
            BusCamera.transform.position = BusCamera.transform.position + (transform.position - startTransform);
            float frameRotationAngle = Time.deltaTime * CameraSmoothness;

            if (Mathf.Abs(_accumulatedRotation) < frameRotationAngle)
            {
                _accumulatedRotation = 0;
            } 
            else if (_accumulatedRotation > 0)
            {
                _accumulatedRotation -= Time.deltaTime * CameraSmoothness;

                BusCamera.transform.Rotate(Vector3.back, frameRotationAngle);
            } 
            else if (_accumulatedRotation < 0)
            {
                _accumulatedRotation += Time.deltaTime * CameraSmoothness;

                BusCamera.transform.Rotate(Vector3.back, -frameRotationAngle);
            }
        }
    }
}
