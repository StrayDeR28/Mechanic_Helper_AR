using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseCamera : MonoBehaviour
{
    void Update()
    {
        float moveHorizontal = -Input.acceleration.x;
        float moveVertical = -Input.acceleration.y;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        float speed = Input.gyro.rotationRate.magnitude;
        transform.Translate(movement * speed * Time.deltaTime);
    }
}