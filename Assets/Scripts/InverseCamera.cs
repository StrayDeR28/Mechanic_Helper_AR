using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseCamera : MonoBehaviour
{
    [SerializeField] private Quaternion initialRotation;
    [SerializeField] private Quaternion gyroInitialRotation;
    private Camera cam;
    private void Awake()
    {
        cam = Camera.main;
        initialRotation = transform.rotation;
        gyroInitialRotation = Input.gyro.attitude;
    }
    void Update()
    {
        Quaternion offsetRotation = Quaternion.Inverse(gyroInitialRotation) * Input.gyro.attitude;
        cam.transform.localRotation = initialRotation * offsetRotation;
    }
}