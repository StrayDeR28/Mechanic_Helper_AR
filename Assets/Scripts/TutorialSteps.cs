using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialSteps : MonoBehaviour
{
    [SerializeField] private List<GameObject> elements = new List<GameObject>();
    [SerializeField] private List<string> instructionsAssembly = new List<string>();
    [SerializeField] private List<string> instructionsDisassembly = new List<string>();
    [SerializeField] private List<string> headings = new List<string>();
    [SerializeField] private bool isAssembling = true;//сборка/разборка

    [SerializeField] private GameObject heading;
    [SerializeField] private GameObject instruction;

    private int i = 0;
    private Color tmpColor = Color.white;
    [SerializeField] private string congrats = "ura pobeda";

    public void SetAssemblingType(bool flag)
    {
        isAssembling = flag;
        SetElementParametrs(isAssembling);
        if (isAssembling) { SetAssembling();}
        else { SetDisassembling(); }
    }
    public void SetAssembling()
    {
        if (i >= 0 && i <= 14) elements[i].GetComponentInChildren<MeshRenderer>().material.color = tmpColor;

        i = 0;
        for(int j = 0; j < elements.Count; j++) 
        {
            elements[j].SetActive(false);
        }
        //Задаем следующий элемент зеленым
        tmpColor = elements[i].GetComponentInChildren<MeshRenderer>().material.color;
        elements[i].GetComponentInChildren<MeshRenderer>().material.color = new Color(0,1,0,0.5f);
        elements[i].SetActive(true);

        heading.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Heading;
        instruction.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Instruction;
    }
    public void SetDisassembling()
    {
        if(i>=0 && i<=14) elements[i].GetComponentInChildren<MeshRenderer>().material.color = tmpColor;

        i = elements.Count - 1;
        for (int j = 0; j < elements.Count; j++)
        {
            elements[j].SetActive(true);
        }
        //Задаем следующий элемент зеленым
        tmpColor = elements[i].GetComponentInChildren<MeshRenderer>().material.color;
        elements[i].GetComponentInChildren<MeshRenderer>().material.color = new Color(0, 1, 0, 0.5f);
        elements[i].SetActive(true);

        heading.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Heading;
        instruction.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Instruction;
    }
    public void SetElementParametrs(bool isAssemble)
    {
        for(int j = 0;j < elements.Count;j++)
        {
            elements[j].GetComponent<Element>().Instruction = isAssemble ? instructionsAssembly[j] : instructionsDisassembly[j];
            elements[j].GetComponent<Element>().Heading = headings[j];
        }
    }
    public void NextStep()
    {
        if (isAssembling)
        {
            if (i <= elements.Count - 1)
            {
                //сделать текущий цветом из буфера
                elements[i].GetComponentInChildren<MeshRenderer>().material.color = tmpColor;

                elements[i].SetActive(true);
            } 
            if (i == elements.Count - 1)
            {
                i++;
                heading.GetComponent<TMP_Text>().text = congrats;
                instruction.GetComponent<TMP_Text>().text = " ";
            }
            if (i < elements.Count - 1)
            {
                i++;
                heading.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Heading;
                instruction.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Instruction;
                //зеленым следующий элемент
                tmpColor = elements[i].GetComponentInChildren<MeshRenderer>().material.color;
                elements[i].GetComponentInChildren<MeshRenderer>().material.color = new Color(0, 1, 0, 0.5f);
                elements[i].SetActive(true);
            }
        }
        else
        { 
            if (i>=0)
            {
                //сделать текущий цветом из буфера
                elements[i].GetComponentInChildren<MeshRenderer>().material.color = tmpColor;

                elements[i].SetActive(false);
            }
            if (i == 0)
            {
                i--;
                heading.GetComponent<TMP_Text>().text = congrats;
                instruction.GetComponent<TMP_Text>().text = " ";
            }
            if (i > 0 && elements[i - 1] != null)
            {
                i--;
                heading.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Heading;
                instruction.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Instruction;
                //зеленым следующий элемент
                tmpColor = elements[i].GetComponentInChildren<MeshRenderer>().material.color;
                elements[i].GetComponentInChildren<MeshRenderer>().material.color = new Color(0, 1, 0, 0.5f);
                elements[i].SetActive(true);
            }

        }
    }
    public void PrevStep() 
    {
        if (isAssembling)
        {
            if (i > 0 && elements[i - 1] != null)
            {
                //следующий, зеленый элемент, выключить и сделать цветом из буфера
                if (i <= elements.Count - 1)
                {
                    elements[i].GetComponentInChildren<MeshRenderer>().material.color = tmpColor;
                    elements[i].SetActive(false);
                }

                i--;
                //elements[i].SetActive(false);
                heading.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Heading;
                instruction.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Instruction;
                //текущий становится зеленым и не выключается
                tmpColor = elements[i].GetComponentInChildren<MeshRenderer>().material.color;
                elements[i].GetComponentInChildren<MeshRenderer>().material.color = new Color(0, 1, 0, 0.5f);
            }
        }
        else
        {
            
            if (i < elements.Count - 1)
            {
                //предыдущий, зеленый элемент, включить и сделать цветом из буфера
                if (i >= 0)
                {
                    elements[i].GetComponentInChildren<MeshRenderer>().material.color = tmpColor;
                    elements[i].SetActive(true);
                }

                i++;
                elements[i].SetActive(true);
                heading.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Heading;
                instruction.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Instruction;
                //текущий становится зеленым и не выключается
                tmpColor = elements[i].GetComponentInChildren<MeshRenderer>().material.color;
                elements[i].GetComponentInChildren<MeshRenderer>().material.color = new Color(0, 1, 0, 0.5f);
            }
        }
    }
}
