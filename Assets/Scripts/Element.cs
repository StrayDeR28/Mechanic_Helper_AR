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
        int childCount = 0;//количество детей без детей + количество детей у детей
        for (int k = 0; k < gameObject.transform.childCount; k++)//считаем количество элементов с материалами
        {
            Transform child = gameObject.transform.GetChild(k);
            if (child.transform.childCount > 0)
            {
                for (int j = 0; j < child.transform.childCount; j++)
                {
                    if (child.GetChild(j).GetComponent<MeshRenderer>())
                    {
                        childCount++;
                    }
                }
            }
            else if (child.GetComponent<MeshRenderer>()) { childCount++; }
        }
        int childIterator = 0;
        for (int i = 0; i < childCount; i++)//Заносим в лист цветов изначальные цвета
        {
            Transform child = gameObject.transform.GetChild(childIterator);
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
            childIterator++;
        }
    }

    public void SetToDefaultColor()
    {
        if (gameObject.name == "Bolts") { gameObject.GetComponent<BoltsAnimation>().StopFlyAnimation(); }//Хардкод для одной анимации, переделать

        for ( int i = 0; i < defaultMaterials.Count; i++)
        {
            parts[i].GetComponent<MeshRenderer>().material = defaultMaterials[i];
        }
    }
    public void SetToGreenColor()
    {
        //для анимаций сюда добавить флаг -> стал зеленым = запускаем анимацию. Или отслеживать подругому, так пока проще, для демки норм будет решение
        if (gameObject.name == "Bolts") 
        {
            gameObject.GetComponent<BoltsAnimation>().PlayFlyAnimation(); 
        }

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
