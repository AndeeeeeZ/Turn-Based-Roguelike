using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    bool debugging = false; 

    bool playerTurn = false;
    Enemy enemyInstance;

    public event Action BattleEnds; 

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

        //add player attack animation & enemy take damage animation

        GlobalReference.enemySpawner.getEnemyInstance().TakeDamage(damage);

        if (debugging)
            Debug.Log($"Enemy took {damage} damage");

        yield return new WaitForSeconds(1f);

        //add enemy attack animation & player damage animation 

        GlobalReference.player.TakeDamage(GlobalReference.enemySpawner.getEnemyInstance().Attack());

        if (debugging)
            Debug.Log("Player took damage");

        if (!GlobalReference.enemySpawner.getEnemyInstance().IsAlive())
        {
            Exit();
        } 
        else
        {
            playerTurn = true; 
        }
    }
}
