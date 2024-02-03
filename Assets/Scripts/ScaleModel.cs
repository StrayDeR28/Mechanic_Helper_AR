using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleModel : MonoBehaviour
{
    [SerializeField] private GameObject model;

    public void ScaleUp()
    {
        Vector3 scale = model.transform.localScale;
        model.transform.localScale = new Vector3(scale.x * 2, scale.y * 2, scale.z * 2);
    }
    public void ScaleDown()
    {
        Vector3 scale = model.transform.localScale;
        model.transform.localScale = new Vector3(scale.x * 0.5f, scale.y * 0.5f, scale.z * 0.5f);
    }
}
