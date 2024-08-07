using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathLibrary
{ 
    // Half main camera height
    public static float CameraHeight = Camera.main.orthographicSize;

    // Half main camera width
    public static float CameraWidth = Camera.main.orthographicSize * Camera.main.aspect;

    // Half sprite width
    public static float SpriteWidth(GameObject g)
    {
        return g.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }
    
    // Half sprite height
    public static float SpriteHeight(GameObject g)
    {
        return g.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }
}
