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
    private BackgroundObject groundOriginal;

    private List<BackgroundObject> grounds;
    private Vector3 startPosition = new Vector3(20, 0, 0);

    public void Enter()
    {
        if (debugging)
            Debug.Log("GroundSpawner started, created first instance");
        grounds = new List<BackgroundObject>();
        createNewInstance(Vector3.zero);
    }

    public void TransitionUpdate()
    {
        for (int i = 0; i < grounds.Count; i++)
        {
            grounds[i].TransitionUpdate();
            if (grounds[i].JustPassedHalfWay())
            {
                createNewInstance(startPosition);
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

    private void createNewInstance(Vector3 location)
    {
        if (debugging)
            Debug.Log("New ground instance created");
        BackgroundObject g = Instantiate(groundOriginal);
        g.Spawn(location);
        grounds.Add(g);
    }
}
