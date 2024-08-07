using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class BackgroundObject : MonoBehaviour
{
    [SerializeField]
    private bool debugging = false;

    [SerializeField]
    float
        speed = 2f,
        cameraHalfWidth = 10f,
        groundHalfWidth = 10f;

    // Check if the current ground object is already half way through
    // This variable is necessary for the JustPassedHalfWay function
    private bool halfWayThrough = false;
    private bool fullyEnterScreen = false;
    public bool skip = false; 
    public void TransitionUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void Spawn(Vector3 location)
    {
        if (debugging)
            Debug.Log($"New {this.gameObject.name} spawned");
        gameObject.SetActive(true);
        transform.position = location;
        halfWayThrough = false;
    }
    public bool OutsideOfScreen()
    {
        bool outside = transform.position.x <= -(cameraHalfWidth + groundHalfWidth + 1);
        if (debugging && outside)
            Debug.Log($"{this.gameObject.name} currently outsideOfScreen");
        return outside;
    }

    public bool JustPassedHalfWay()
    {
        if (!halfWayThrough && transform.position.x <= 0)
        {
            halfWayThrough = true;
            if (debugging)
                Debug.Log($"{this.gameObject.name} halfway through");
            return true;
        }
        return false;
    }

    public bool JustFullyEnteredScreen()
    {
        //If the current object is not fully inside the screen yet & the right side just entered the screen
        if (!fullyEnterScreen && 
            (transform.position.x + this.GetComponent<SpriteRenderer>().bounds.size.x / 2) <= MathLibrary.CameraWidth)
        {
            fullyEnterScreen = true;
            return true; 
        }
        return false; 
    }   
    public void Exit()
    {
        if (debugging)
            Debug.Log($"Removed {this.gameObject.name} outside of screen");
        UnityEngine.Object.Destroy(gameObject);
    }

}
