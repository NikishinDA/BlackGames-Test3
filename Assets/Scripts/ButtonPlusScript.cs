using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPlusScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
            controllerScript.RedPlusClick();
        }
    }
    public void OnPointerDown(PointerEventData eventData)//если кнопка зажата
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)//если кнопка отжата
    {
        buttonPressed = false;
    }
}
