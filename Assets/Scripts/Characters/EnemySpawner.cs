using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    bool debugging; 

    [SerializeField]
    Enemy orginialEnemy;

    Enemy enemyInstance;
    bool arrived = false; 

    public event Action EnemyInstanceArrived; 

    public void Enter ()
    {
        SpawnEnemy();
    }
    public void SpawnEnemy()
    {
        if (enemyInstance == null)
            enemyInstance = Instantiate(orginialEnemy);
        enemyInstance.Enter();
        arrived = false; 

        if (debugging)
            Debug.Log("EnemySpawner spawned new enemy instance"); 
    }

    public void TransitionUpdate()
    {
        if (enemyInstance.TransitionUpdate())
        {
            if (!arrived)
            {
                EnemyInstanceArrived?.Invoke();
                arrived = true;

                if (debugging)
                    Debug.Log("Enemy has arrived target location");
            }
        }
    }

    public void Exit()
    {
        enemyInstance.Exit(); 
        Invoke("SpawnEnemy", 1f);
    }

    public Enemy getEnemyInstance()
    {
        return enemyInstance;
    }
}
