using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    Button button1, button2;

    [SerializeField]
    TextMeshProUGUI button1Text, button2Text; 
    public void EnableButtons()
    {
        button1.interactable = true;
        button1Text.alpha = 1f;

        button2.interactable = true;
        button2Text.alpha = 1f;
    }

    public void DisableButtons()
    {
        button1.interactable = false;
        button1Text.alpha = 0.5f; 

        button2.interactable = false;
        button2Text.alpha = 0.5f;
    }
}
