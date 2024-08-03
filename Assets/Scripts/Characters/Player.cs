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
    private KeyCode
        UpAttackKey = KeyCode.W,
        LeftAttackKey = KeyCode.A;
    public new void Enter()
    {
        maxHealth = 200f;
        currentHealth = 200f;
        attack = 10f;
        defense = 0f;
        extraAttack = 0f;
        animator.SetBool("IsDead", false);
        StartTransition();
        DisplayHealth();
    }
    public override float Attack(KeyCode key)
    {
        if (key == UpAttackKey)
            return attack + extraAttack;
        if (key == LeftAttackKey)
            return 2f * (attack + extraAttack);
        return attack + extraAttack;
    }

    public void StartTransition()
    {
        animator.SetBool("Run", true);
    }

    public void Battle()
    {
        animator.SetBool("Run", false);
    }

}
