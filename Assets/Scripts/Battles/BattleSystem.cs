using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;
using UnityEngine.Events; 

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    bool debugging = false; 

    bool playerTurn = false;

    public event Action BattleEnds;
    public event Action EnemyTakeDamage;

    public UnityEvent PlayEnemyAttackAnimation; 

    public void NormnalAttack()
    {
        if (playerTurn) 
            StartCoroutine(PlayerAttack(10f)); 
    }

    public void SpecialAttack()
    {
        if (playerTurn)
            StartCoroutine(PlayerAttack(20f)); 
    }

    public void Enter()
    {
        playerTurn = true;
        if (debugging)
            Debug.Log("Battle system enabled"); 
    }

    public void Exit ()
    {
        if (debugging)
            Debug.Log("Battle ends"); 
        BattleEnds?.Invoke();
        playerTurn = false; 
    }

    private IEnumerator PlayerAttack(float damage)
    {
        playerTurn = false;
        GlobalReference.buttonController.DisableButtons();

        //add player attack animation & enemy take damage animation

        GlobalReference.enemySpawner.getEnemyInstance().TakeDamage(damage);
        EnemyTakeDamage?.Invoke();

        if (debugging)
            Debug.Log($"Enemy took {damage} damage");

        yield return new WaitForSeconds(0.4f);

        //add enemy attack animation & player damage animation 

        GlobalReference.player.TakeDamage(GlobalReference.enemySpawner.getEnemyInstance().Attack());
        PlayEnemyAttackAnimation?.Invoke();

        if (debugging)
            Debug.Log("Player took damage");

        if (!GlobalReference.enemySpawner.getEnemyInstance().IsAlive())
        {
            Exit();
        } 
        else
        {
            playerTurn = true;
            GlobalReference.buttonController.EnableButtons();
        }
    }
}
