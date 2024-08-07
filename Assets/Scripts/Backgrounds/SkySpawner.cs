using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class SkySpawner : MonoBehaviour
{
    [SerializeField]
    bool debugging = false; 

    [SerializeField]
    BackgroundObject
        cloud,
        furtherTree,
        closerTree,
        bird;

    [SerializeField]
    float
        yInt = 4f, 
        scale = 2f;

    float width; 

    private List<BackgroundObject> clouds, furtherTrees, closerTrees, birds;
    private List<BackgroundObject>[] skyParts;
    private BackgroundObject[] BackgroundObjects; 

    private Vector3 startPosition;

    public void Enter()
    {
        if (debugging)
            Debug.Log("SkySpawner entered");
        clouds = new List<BackgroundObject>();
        furtherTrees = new List<BackgroundObject>();
        closerTrees = new List<BackgroundObject>();
        birds = new List<BackgroundObject>();

        width = cloud.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        startPosition = new Vector3(MathLibrary.CameraWidth + width, yInt, 0);

        Scale();

        skyParts = new List<BackgroundObject>[] { clouds, furtherTrees, closerTrees, birds };
        BackgroundObjects = new BackgroundObject[] { cloud, furtherTree, closerTree, bird };

        Initialize();
    }

    private void Scale()
    {
        //scale = MathLibrary.CameraWidth / width;
        //Debug.Log($"OrthographicSize: {Camera.main.orthographicSize * Camera.main.aspect}, Cloud Width: {cloud.GetComponent<SpriteRenderer>().bounds.size.x / 2}, Scale: {scale}"); 
        cloud.transform.localScale = new Vector3(scale, scale, scale);
        furtherTree.transform.localScale = new Vector3(scale, scale, scale);
        closerTree.transform.localScale = new Vector3(scale, scale, scale);
        bird.transform.localScale = new Vector3(scale, scale, scale);
    }

    private void Initialize()
    {
        for(float i = MathLibrary.CameraWidth; i >= -MathLibrary.CameraWidth - width * 2; i -= (width * 2))
        {
            for (int j = 0; j < 4; j++)
            {
                if (i == MathLibrary.CameraWidth)
                    createNewInstance(new Vector3(i, yInt, 0), j, false);
                else
                    createNewInstance(new Vector3(i, yInt, 0), j, true);
            }  
        }
    }

    public void TransitionUpdate()
    {
        for (int i = 0; i < skyParts.Length; i++)
        {
            for(int j = 0; j < skyParts[i].Count; j++)
            {
                skyParts[i][j].TransitionUpdate();
                if (skyParts[i][j].JustFullyEnteredScreen() && !skyParts[i][j].skip)
                {
                    createNewInstance(startPosition, i, false) ;
                }
                if (skyParts[i][j].OutsideOfScreen())
                {
                    if (debugging)
                        Debug.Log("The sky part on the left is outside of screen and removed");
                    skyParts[i][j].Exit();
                    skyParts[i].RemoveAt(j--);
                }
            }
        }
    }

    private void createNewInstance(Vector3 location, int n, bool skip)
    {
        if (debugging)
            Debug.Log("New sky parts instance created");
        BackgroundObject g = Instantiate(BackgroundObjects[n]);
        g.skip = skip; 
        g.Spawn(location);
        skyParts[n].Add(g); 
    }
}
