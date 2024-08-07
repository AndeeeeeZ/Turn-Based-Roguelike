using System;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class GameBeginState : GameState, IGameState
{
    private GameManager.States nextState = GameManager.States.Transition;
    public event Action<GameManager.States> GameBeginStateEnds; 
    public new void Enter()
    {
        if (debugging)
            Debug.Log("GameBegin state starts");

        GlobalReference.player.Enter();
        GlobalReference.groundSpawner.Enter();
        GlobalReference.enemySpawner.Enter();
        GlobalReference.skySpawner.Enter();
        Exit();
    }

    public void StateUpdate()
    {

    }

    public void Exit()
    {
        if (debugging)
            Debug.Log("GameBegin state ends");

        GameBeginStateEnds?.Invoke(nextState); 
    }
}

