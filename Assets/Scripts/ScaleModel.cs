using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScaleModel : MonoBehaviour
{
    [SerializeField] private GameObject model;
    [SerializeField] private float scaleCoef = 1.5f;
 
    public void ScaleUp()
    {
        Vector3 scale = model.transform.localScale;
        Vector3 position = model.transform.localPosition;
        model.transform.localScale = new Vector3(scale.x * scaleCoef, scale.y * scaleCoef, scale.z * scaleCoef);
        model.transform.localPosition = new Vector3(position.x * scaleCoef, position.y, position.z);
    }
    public void ScaleDown()
    {
        Vector3 scale = model.transform.localScale;
        Vector3 position = model.transform.localPosition;
        model.transform.localScale = new Vector3(scale.x / scaleCoef, scale.y / scaleCoef, scale.z / scaleCoef);
        model.transform.localPosition = new Vector3(position.x / scaleCoef, position.y, position.z);
    }
}
