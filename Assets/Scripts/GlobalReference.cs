using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalReference
{
    public static Player player;
    public static Enemy enemy;

    public static GroundSpawner groundSpawner;
    public static SkySpawner skySpawner; 
    public static EnemySpawner enemySpawner;

    public static bool debuggingGameStates;

    public static BattleSystem battleSystem;
    public static ButtonController buttonController; 
}
