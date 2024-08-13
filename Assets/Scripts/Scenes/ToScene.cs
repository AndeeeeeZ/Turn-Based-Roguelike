using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScene : MonoBehaviour
{
    [SerializeField]
    string nextSceneName, thisSceneName; 

    public void OnClick()
    {
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }
}
