using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    [SerializeField]
    bool debugging = false;

    [SerializeField]
    Animator animator;

    public void StartAnimation()
    {
        animator.SetBool("Attack", true); 
    }


    public void Exit()
    {
        animator.SetBool("Attack", false);

        if (debugging)
            Debug.Log("Attack animation ended"); 
    }
}
