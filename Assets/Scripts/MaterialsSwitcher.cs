using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsSwitcher : MonoBehaviour
{
    [SerializeField] private Material greenMaterial;

    public Material SetGreenMaterial()
    {
        return greenMaterial;
    }
}