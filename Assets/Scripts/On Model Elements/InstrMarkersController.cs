using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrMarkersController : MonoBehaviour
{
    [SerializeField] private List<GameObject> instructionMarkers;
    [SerializeField] private Animator animator;
    [SerializeField] private string assemblingStateName;
    [SerializeField] private string disassemblingStateName;

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(assemblingStateName)) //Если нужная анимация
        {
            if (!(animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)) // Если нужная анимация закончилась
            {
                for (int i = 0; i < instructionMarkers.Count; i++)
                {
                    instructionMarkers[i].SetActive(true);// Включаем маркеры
                    instructionMarkers[i].GetComponent<InstructionMarker>().SetAssemblingNumber();
                }
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName(disassemblingStateName)) //Если нужная анимация
        {
            if (!(animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)) // Если нужная анимация закончилась
            {
                for (int i = 0; i < instructionMarkers.Count; i++)
                {
                    instructionMarkers[i].SetActive(true);// Включаем маркеры
                    instructionMarkers[i].GetComponent<InstructionMarker>().SetDisassemblingNumber();
                }
            }
        }
        else
        {
            for (int i = 0; i < instructionMarkers.Count; i++)
            {
                instructionMarkers[i].SetActive(false);// Выключаем маркеры
            }
        }
    }
}
