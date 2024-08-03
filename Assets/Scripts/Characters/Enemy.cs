using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Enemy : Character
{
    private float xTargetPosition, xStartPosition;

    [SerializeField]
    bool debugging = false;

    [SerializeField, Min(0f)]
    float
        speed = 2f,
        yPosition = 1.5f;
    public new void Enter()
    {
        gameObject.SetActive(true);
        animator.enabled = true;
        xTargetPosition = 5f;
        xStartPosition = 14f;
        maxHealth = 100f;
        currentHealth = 100f;
        attack = 5f;
        defense = 0f;
        extraAttack = 0f;
        animator.SetBool("IsDead", false);
        transform.position = new Vector2(xStartPosition, yPosition);
        DisplayHealth();

        if (debugging)
            Debug.Log("Enemy spawned");
    }

    public bool TransitionUpdate()
    {
        animator.SetBool("IsDead", false);
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x <= xTargetPosition)
        {
            transform.position = new Vector2(xTargetPosition, yPosition);

            

            return true;
        }
        return false;

    }
    public void Exit()
    {
        animator.SetBool("IsDead", true);
        if (debugging)
            Debug.Log("Enemy died");
    }


}
