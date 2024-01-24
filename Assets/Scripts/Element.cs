using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Element : MonoBehaviour
{
    [SerializeField] internal string Instruction { get; set; }
    [SerializeField] internal string Heading { get; set; }

    [SerializeField] private List<Color> defaultColors = new List<Color>();
    [SerializeField] private List<Transform> parts = new List<Transform>();

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
                    childCount++;
                }
            }
            else { childCount++; }
        }
        int childIterator = 0;
        for (int i = 0; i < childCount; i++)//Заносим в лист цветов изначальные цвета
        {
            Transform child = gameObject.transform.GetChild(childIterator);
            if (child.GetComponent<MeshRenderer>())
            {
                defaultColors.Add(child.GetComponent<MeshRenderer>().material.color);
                parts.Add(child);
            }
            if (child.transform.childCount > 0)//Если у ребенка есть дети
            {
                for(int j = 0; j < child.transform.childCount; j++)
                {
                    Transform child2 = child.transform.GetChild(j);
                    if (child2.GetComponent<MeshRenderer>())
                    {
                        defaultColors.Add(child2.GetComponent<MeshRenderer>().material.color);
                        parts.Add(child2);
                    }
                }
            }
            childIterator++;
        }
    }

    public void SetToDefaultColor()
    {
        for ( int i = 0; i < defaultColors.Count; i++)
        {
            if (parts[i].GetComponent<ChangeRenderingMode>()) 
            { 
                parts[i].GetComponent<ChangeRenderingMode>().ChangeMaterialRenderingMode(parts[i].GetComponent<MeshRenderer>().material, RenderingMode.Opaque); 
            }
            parts[i].GetComponent<MeshRenderer>().material.color = defaultColors[i];
        }
    }
    public void SetToGreenColor()
    {
        for (int i = 0; i < defaultColors.Count; i++)
        {
            if (parts[i].GetComponent<ChangeRenderingMode>())
            {
                parts[i].GetComponent<ChangeRenderingMode>().ChangeMaterialRenderingMode(parts[i].GetComponent<MeshRenderer>().material, RenderingMode.Fade);
            }
            parts[i].GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0, 0.5f);
            //для анимаций сюда добавить флаг -> стал зеленым = запускаем анимацию. Или отслеживать подругому, так пока проще, для демки норм будет решение
        }
    }
}
