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
    public event Action<GameManager.States> BattleStateEnds;

    private GameManager.States nextState = GameManager.States.Transition;
    private Enemy enemyInstance; 

    public BattleState()
    {
        GlobalReference.battleSystem.BattleEnds += Exit; 
    }

    public new void Enter()
    {
        if (debugging)
            Debug.Log("Battle state starts");

        GlobalReference.player.Battle(); 
        enemyInstance = GlobalReference.enemySpawner.getEnemyInstance();
        GlobalReference.battleSystem.Enter();
    } 

    public void StateUpdate() { }

    public void Exit()
    {
        GlobalReference.enemySpawner.Exit();
        BattleStateEnds?.Invoke(nextState);

        if (debugging)
            Debug.Log("Battle state ends"); 
    }

}
