using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameState, IGameState
{
                                                                                                        
    private bool isAnimationOver = false; 
    public new void Enter()
    {
        isAnimationOver = false; 
        GlobalReference.player.Dead();
        EndGameCalculation();
    }

    public void StateUpdate()
    {

    }

    private IEnumerator EndGameCalculation ()
    {

        yield return new WaitForSeconds(1f);




        isAnimationOver = true; 
    }

    public void Exit()
    {

    }
}
