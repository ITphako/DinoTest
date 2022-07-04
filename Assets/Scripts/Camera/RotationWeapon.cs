using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWeapon : MonoBehaviour
{
   [SerializeField] private float _mouseSensitivity = 100.0f;
   [SerializeField] private float _clampAngle = 80.0f;

    private float _rotY = 0.0f;
    private float _rotX = 0.0f;

    private void Start()
    {
         Vector3 rot = transform.localRotation.eulerAngles;
        _rotX = rot.x;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");

        _rotY += mouseX * _mouseSensitivity * Time.deltaTime;

        _rotX = Mathf.Clamp(_rotX, -_clampAngle, _clampAngle);

        Quaternion localRotation = Quaternion.Euler(_rotX, _rotY, 0.0f);
        transform.rotation = localRotation;
    }
}

