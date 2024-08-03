using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region variables

    [SerializeField]
    private bool debugging = false,
        debuggingGameStates = false;

    [SerializeField]
    public Player player;

    [SerializeField]
    public EnemySpawner enemySpawner;

    [SerializeField]
    public GroundSpawner groundSpawner;

    [SerializeField]
    public BattleSystem battleSystem; 
    public enum States { Battle, GameBegin, Transition }

    //Consider using dictionary for switching states with enum
    BattleState battleState;
    TransitionState transitionState;
    GameBeginState gameBeginState;
    
    private IGameState currentState;

    #endregion

    #region Loading methods
    private void Start()
    {
        if (debugging) 
            Debug.Log("Game starts");
        
        SetGlobalReference();
        Initialize();
        Subscribe();

        toState(gameBeginState);
    }

    private void Initialize()
    {
        battleState = new BattleState();
        transitionState = new TransitionState();
        gameBeginState = new GameBeginState();
    }

    private void SetGlobalReference()
    {
        GlobalReference.battleSystem = battleSystem;
        GlobalReference.player = player;
        GlobalReference.enemySpawner = enemySpawner;
        GlobalReference.groundSpawner = groundSpawner;
        GlobalReference.debuggingGameStates = debuggingGameStates;
    }

    private void Subscribe()
    {
        transitionState.TransitionStateEnds += switchStateTo;
        gameBeginState.GameBeginStateEnds += switchStateTo;
        battleState.BattleStateEnds += switchStateTo;
    }

    #endregion

    #region Methods
    private void toState(IGameState state)
    {
        if (currentState == state)
            return; 
        currentState = state; 
        currentState?.Enter();
        Debug.Log("Entered " + currentState.GetType().Name); 
    }

    //Take in enum States
    public void switchStateTo(States state)
    {
        toState(convertToState(state));
    }

    private IGameState convertToState(States state)
    {
        switch (state)
        {
            case States.Battle:
                return battleState;
            case States.Transition:
                return transitionState; 
            case States.GameBegin:
                return gameBeginState;
            default:
                Debug.Log("State not found");
                return transitionState; 
        }
    }

    #endregion

    private void Update()
    {
        currentState?.StateUpdate();
    }
}
