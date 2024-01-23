using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialSteps : MonoBehaviour
{
    [SerializeField] private List<GameObject> elements = new List<GameObject>();
    [SerializeField] private List<string> instructions = new List<string>();
    [SerializeField] private List<string> headings = new List<string>();
    [SerializeField] private bool isAssembling = true;//сборка/разборка

    [SerializeField] private GameObject heading;
    [SerializeField] private GameObject instruction;

    private int i = 0;
    public void SetAssemblingType(bool flag)
    {
        isAssembling = flag;
        if (isAssembling) { SetAssembling(); }
        else { SetDisassembling(); }
    }
    public void SetAssembling()
    {
        i = 0;
        for(int j = 0; j < elements.Count; j++) 
        {
            elements[j].SetActive(false);
        }
        heading.GetComponent<TMP_Text>().text = headings[i];
        instruction.GetComponent<TMP_Text>().text = instructions[i];
    }
    public void SetDisassembling()
    {
        i = elements.Count - 1;
        for (int j = 0; j < elements.Count; j++)
        {
            elements[j].SetActive(true);
        }
        heading.GetComponent<TMP_Text>().text = headings[i];
        instruction.GetComponent<TMP_Text>().text = instructions[i];
    }
    public void NextStep()
    {
        if(isAssembling)
        {

        }
    }
    public void PrevStep() 
    { 

    }
}
