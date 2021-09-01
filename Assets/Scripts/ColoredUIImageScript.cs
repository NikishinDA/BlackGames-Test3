using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColoredUIImageScript : MonoBehaviour, ColoredInterface
{
    Image image;
    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void ChangeRGB(float r, float g, float b)
    {
        image.color = new Color(r, g, b);
    }

    public Color GetColor()
    {
        return image.color;
    }
}
