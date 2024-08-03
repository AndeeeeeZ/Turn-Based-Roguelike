using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Ground : MonoBehaviour
{
    [SerializeField]
    private bool debugging = false;

    [SerializeField]
    float
        speed = 2f,
        cameraHalfWidth = 10f,
        groundHalfWidth = 10f;

    private bool halfWayThrough = false;
    public void TransitionUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void Spawn(Vector3 location)
    {
        if (debugging)
            Debug.Log("New ground spawned");
        gameObject.SetActive(true);
        transform.position = location;
        halfWayThrough = false;
    }
    public bool OutsideOfScreen()
    {
        bool outside = transform.position.x <= -(cameraHalfWidth + groundHalfWidth + 1);
        if (debugging && outside)
            Debug.Log("Ground currently outsideOfScreen");
        return outside;
    }

    public bool JustPassedHalfWay()
    {
        if (!halfWayThrough && transform.position.x <= 0)
        {
            halfWayThrough = true;
            if (debugging)
                Debug.Log("Ground halfway through");
            return true;
        }
        return false;
    }

    public void Exit()
    {
        if (debugging)
            Debug.Log("Removed ground outside of screen");
        UnityEngine.Object.Destroy(gameObject);
    }

}
