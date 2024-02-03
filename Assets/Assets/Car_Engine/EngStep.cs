using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngStep : MonoBehaviour
{
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
        ani.enabled = true;
    }
    public void NextStep()
    {
        if (ani.GetInteger("Step")<15)
        {
            int stepp = ani.GetInteger("Step");
            ani.SetInteger("Step", stepp + 1);
        }
    }
    public void BackStep()
    {
        if (ani.GetInteger("Step") > 0)
        {
            int stepp = ani.GetInteger("Step");
            ani.SetInteger("Step", stepp - 1);
        }
    }
}
