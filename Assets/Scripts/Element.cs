using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Element : MonoBehaviour
{
    [SerializeField] internal string Instruction { get; set; }
    [SerializeField] internal string Heading { get; set; }

    [SerializeField] private List<Transform> parts = new List<Transform>();
    [SerializeField] private List<Material> defaultMaterials = new List<Material>();

    private void Awake()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)//Заносим в лист цветов изначальные цвета
        {
            Transform child = gameObject.transform.GetChild(i);
            if (child.GetComponent<MeshRenderer>())
            {
                defaultMaterials.Add(child.GetComponent<MeshRenderer>().material);
                parts.Add(child);
            }
            if (child.transform.childCount > 0)//Если у ребенка есть дети
            {
                for(int j = 0; j < child.transform.childCount; j++)
                {
                    Transform child2 = child.transform.GetChild(j);
                    if (child2.GetComponent<MeshRenderer>())
                    {
                        defaultMaterials.Add(child2.GetComponent<MeshRenderer>().material);
                        parts.Add(child2);
                    }
                }
            }
        }
    }

    public void SetToDefaultColor()
    {
        for ( int i = 0; i < defaultMaterials.Count; i++)
        {
            parts[i].GetComponent<MeshRenderer>().material = defaultMaterials[i];
        }
    }
    public void SetToGreenColor()
    {
        for (int i = 0; i < defaultMaterials.Count; i++)
        {
            if (parts[i].GetComponent<MaterialsSwitcher>())
            {
                Material tmpMaterial = parts[i].GetComponent<MaterialsSwitcher>().SetGreenMaterial();
                parts[i].GetComponent<MeshRenderer>().material = tmpMaterial;
            }
            
        }
    }
}
