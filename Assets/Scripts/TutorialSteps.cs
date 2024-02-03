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
    [SerializeField] private Animator animator;

    private int i = 0;
    [SerializeField] private int animationsCount = 16;
    [SerializeField] private string congrats = "ura pobeda";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.enabled = true;
    }
    public void SetAssemblingType(bool flag)
    {
        isAssembling = flag;
        SetElementParametrs(isAssembling);
        Setup();
    }
    public void Setup()
    {
        if (i >= 0 && i < elements.Count) elements[i].GetComponent<Element>().SetToDefaultColor();

        if (isAssembling)
        {
            i = 0;
            animator.SetInteger("Step", i);
            animator.SetTrigger("StartPosition");
            for (int j = 0; j < elements.Count; j++) 
            {
                elements[j].SetActive(false);
            }
        }
        else
        {
            i = elements.Count - 1;
            animator.SetInteger("Step", i);
            animator.SetTrigger("EndPosition");
            for (int j = 0; j < elements.Count; j++)
            {
                elements[j].SetActive(true);
            }
        }
        //Задаем следующий элемент зеленым
        elements[i].GetComponent<Element>().SetToGreenColor();
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
                elements[i].GetComponent<Element>().SetToDefaultColor();
                animator.SetInteger("Step", i);
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
                elements[i].GetComponent<Element>().SetToGreenColor();
                animator.SetInteger("Step", i);
                elements[i].SetActive(true);
            }
        }
        else
        { 
            if (i>=0)
            {
                //сделать текущий цветом из буфера
                elements[i].GetComponent<Element>().SetToDefaultColor();
                animator.SetInteger("Step", i);
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
                elements[i].GetComponent<Element>().SetToGreenColor();
                animator.SetInteger("Step", i);
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
                    elements[i].GetComponent<Element>().SetToDefaultColor();
                    animator.SetInteger("Step", i);
                    elements[i].SetActive(false);
                }

                i--;
                animator.SetInteger("Step", i);
                heading.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Heading;
                instruction.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Instruction;
                //текущий становится зеленым и не выключается
                elements[i].GetComponent<Element>().SetToGreenColor();
            }
        }
        else
        {
            if (i < elements.Count - 1)
            {
                //предыдущий, зеленый элемент, включить и сделать цветом из буфера
                if (i >= 0)
                {
                    elements[i].GetComponent<Element>().SetToDefaultColor();
                    elements[i].SetActive(true);
                    animator.SetInteger("Step", i);
                }

                i++;
                elements[i].SetActive(true);
                animator.SetInteger("Step", i);
                heading.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Heading;
                instruction.GetComponent<TMP_Text>().text = elements[i].GetComponent<Element>().Instruction;
                //текущий становится зеленым и не выключается
                elements[i].GetComponent<Element>().SetToGreenColor();
            }
        }
    }
}