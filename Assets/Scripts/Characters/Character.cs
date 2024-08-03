using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField, Min(0f)]
    protected float
        maxHealth = 100f,
        currentHealth = 100f,
        attack = 5f,
        defense = 0f,
        extraAttack = 0f;

    [SerializeField]
    protected TextMeshProUGUI health;

    [SerializeField]
    protected Animator animator;

    [SerializeField]
    protected Image healthBar;
    public void Enter()
    {
        currentHealth = maxHealth;
        health.SetText($"{currentHealth}/{maxHealth}");
    }
    public virtual float Attack(KeyCode input)
    {
        return attack + extraAttack;
    }

    public float TakeDamage(float enemyAttack)
    {
        float damage = Mathf.Max(0, (enemyAttack - defense));
        damage = Mathf.Min(damage, currentHealth);
        currentHealth -= damage;
        DisplayHealth();
        return damage;
    }

    public bool IsAlive() { return currentHealth > 0; }

    public void Recover()
    {
        currentHealth = maxHealth;
    }

    protected void DisplayHealth()
    {
        health.SetText($"{Mathf.Round((currentHealth / maxHealth) * 100)}%");
        healthBar.fillAmount = currentHealth / maxHealth;
    }


}
