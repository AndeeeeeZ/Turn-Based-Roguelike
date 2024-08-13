using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{

    public new void Enter()
    {
        animator.SetBool("IsDead", false);
        StartTransition();
        DisplayHealth();
    }

    public void StartTransition()
    {
        animator.SetBool("Run", true);
    }

    public void Battle()
    {
        animator.SetBool("Run", false);
    }

    public void Dead()
    {
        animator.SetBool("IsDead", true); 
    }

}
