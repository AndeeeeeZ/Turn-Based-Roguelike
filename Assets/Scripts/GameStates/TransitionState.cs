using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TransitionState : GameState, IGameState
{
    public event Action<GameManager.States> TransitionStateEnds;

    private GameManager.States nextState = GameManager.States.Battle; 

    public new void Enter()
    {
        GlobalReference.player.StartTransition();
        GlobalReference.enemySpawner.EnemyInstanceArrived += TransitionEnds;

        if (debugging)
            Debug.Log("Transition state starts"); 
    }

    public void StateUpdate()
    {
        GlobalReference.groundSpawner.TransitionUpdate();
        GlobalReference.enemySpawner.TransitionUpdate();
    }

    public void Exit() 
    {

    }

    public void TransitionEnds()
    {
        if (debugging)
            Debug.Log("Transition state ends");

        TransitionStateEnds?.Invoke(nextState);
        Exit();
    }
}
