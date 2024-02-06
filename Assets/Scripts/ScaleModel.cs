using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScaleModel : MonoBehaviour
{
    [SerializeField] private GameObject model;
    [SerializeField] private float scaleCoef = 1.5f;
    private bool isRotated = false;
 
    public void ScaleUp()
    {
        Vector3 scale = model.transform.localScale;
        Vector3 position = model.transform.localPosition;
        model.transform.localScale = new Vector3(scale.x * scaleCoef, scale.y * scaleCoef, scale.z * scaleCoef);
        //model.transform.localPosition = new Vector3(position.x * scaleCoef, position.y, position.z);
    }
    public void ScaleDown()
    {
        Vector3 scale = model.transform.localScale;
        Vector3 position = model.transform.localPosition;
        model.transform.localScale = new Vector3(scale.x / scaleCoef, scale.y / scaleCoef, scale.z / scaleCoef);
        //model.transform.localPosition = new Vector3(position.x / scaleCoef, position.y / scaleCoef, position.z / scaleCoef);
    }
    public void Rotate()
    {
        Quaternion rotation = model.transform.localRotation;
        if (!isRotated)
        {
            model.transform.localRotation = new Quaternion(rotation.x + 90, rotation.y, rotation.z, rotation.w);
            isRotated = true;
        }
        else
        {
            model.transform.localRotation = new Quaternion(rotation.x - 90, rotation.y, rotation.z, rotation.w);
            isRotated = false;
        }
    }
}
