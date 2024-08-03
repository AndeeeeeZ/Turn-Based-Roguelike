using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.Rendering.VirtualTexturing;

public class BattleState : GameState, IGameState
{
    //public event Action MoveSelected;
    public event Action<GameManager.States> BattleStateEnds;

    private GameManager.States nextState = GameManager.States.Transition;
    private Enemy enemyInstance; 

    public new void Enter()
    {
        if (debugging)
            Debug.Log("Battle state starts");

        GlobalReference.player.Battle(); 
        enemyInstance = GlobalReference.enemySpawner.getEnemyInstance();
    } 

    public void StateUpdate()
    {
        KeyCode key = HandleInput();
        if (key != KeyCode.None)
        {
            if (debugging)
                Debug.Log("Input detected, attack");
            enemyInstance.TakeDamage(GlobalReference.player.Attack(key));
            GlobalReference.player.TakeDamage(enemyInstance.Attack(key));
        }
        if (!enemyInstance.IsAlive())
        {
            BattleStateEnds?.Invoke(nextState);
            Exit();
        }
    }

    public void Exit() {
        if (debugging)
            Debug.Log("Battle state ends");
        GlobalReference.enemySpawner.Exit();
    }
    private KeyCode HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
            return KeyCode.W;
        if (Input.GetKeyDown(KeyCode.A))
            return KeyCode.A;
        if (Input.GetKeyDown(KeyCode.S))
            return KeyCode.S;
        if (Input.GetKeyDown(KeyCode.D))
            return KeyCode.D;
        return KeyCode.None;
    }

    
}
