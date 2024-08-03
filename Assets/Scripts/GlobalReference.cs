using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalReference
{
    [SerializeField]
    public static Player player;

    [SerializeField]
    public static Enemy enemy;

    [SerializeField]
    public static GroundSpawner groundSpawner;

    [SerializeField]
    public static EnemySpawner enemySpawner;

    [SerializeField]
    public static bool debuggingGameStates; 
}
