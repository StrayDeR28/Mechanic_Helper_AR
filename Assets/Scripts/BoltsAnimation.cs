using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltsAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void PlayFlyAnimation()
    {
        animator.ResetTrigger("Idle");
        animator.SetTrigger("BoltsFly");
    }
    public void StopFlyAnimation()
    {
        animator.ResetTrigger("BoltsFly");
        animator.SetTrigger("Idle");
    }
}
