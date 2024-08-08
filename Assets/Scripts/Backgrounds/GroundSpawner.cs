using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.Rendering.VirtualTexturing;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField]
    private bool debugging = false;

    [SerializeField]
    private BackgroundObject[] originalObjects;

    private List<BackgroundObject> grounds;
    private Vector3 startPosition = new Vector3(20, 0, 0);

    private int lastMap; 

    public void Enter()
    {
        if (debugging)
            Debug.Log("GroundSpawner started, created first instance");
        grounds = new List<BackgroundObject>();
        CreateNewInstance(Vector3.zero);
    }

    public void TransitionUpdate()
    {
        for (int i = 0; i < grounds.Count; i++)
        {
            grounds[i].TransitionUpdate();
            if (grounds[i].JustPassedHalfWay())
            {
                CreateNewInstance(startPosition);
            }
            if (grounds[i].OutsideOfScreen())
            {
                if (debugging)
                    Debug.Log($"The ground on the left is outside of screen and removed");
                grounds[i].Exit();
                grounds.RemoveAt(i--);
            }
        }
    }

    private void CreateNewInstance(Vector3 location)
    {
        if (debugging)
            Debug.Log("New ground instance created");
        BackgroundObject g = Instantiate(SelectRandomTile(), transform);
        g.Spawn(location);
        grounds.Add(g);
    }

    private BackgroundObject SelectRandomTile()
    {
        int randomIndex = UnityEngine.Random.Range(0, originalObjects.Length); 

        while (randomIndex == lastMap && originalObjects.Length > 1)
        {
            randomIndex = UnityEngine.Random.Range(0, originalObjects.Length);
        }
        
        lastMap = randomIndex;
        return originalObjects[randomIndex];
    }
}
