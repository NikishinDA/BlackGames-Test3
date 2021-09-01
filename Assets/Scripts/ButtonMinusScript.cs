using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMinusScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    UIControllerScript controllerScript;
    public bool buttonPressed = false;
    private void Start()
    {
        controllerScript = FindObjectOfType<UIControllerScript>();
    }
    private void Update()
    {
        if (buttonPressed)
        {
            controllerScript.RedMinusClick();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }
}
