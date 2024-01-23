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
        i = 0;
        for(int j = 0; j < elements.Count; j++) 
        {
            elements[j].SetActive(false);
        }
        heading.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Heading;
        instruction.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Instruction;
    }
    public void SetDisassembling()
    {
        i = elements.Count - 1;
        for (int j = 0; j < elements.Count; j++)
        {
            elements[j].SetActive(true);
        }
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
        if(isAssembling)
        { 
            if(i<=elements.Count -1)
                elements[i].SetActive(true);
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
            }
           
        }
        else
        { 
            if(i>=0)
                elements[i].SetActive(false);
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
            }
           
        }
    }
    public void PrevStep() 
    {
        if (isAssembling)
        {
            
            if (i > 0 && elements[i - 1] != null)
            {
                i--;
                elements[i].SetActive(false);
                heading.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Heading;
                instruction.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Instruction;
            }
        }
        else
        {
            
            if (i < elements.Count - 1)
            {
                i++;
                elements[i].SetActive(true);
                heading.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Heading;
                instruction.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Instruction;
            }
        }
    }
}
