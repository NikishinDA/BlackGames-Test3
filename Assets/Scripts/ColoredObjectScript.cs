using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredObjectScript : MonoBehaviour, ColoredInterface
{
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    public void ChangeRGB(float r, float g, float b)
    {
        renderer.material.SetColor("_Color", new Color(r,g,b));

    }

    public Color GetColor()
    {
        return renderer.material.GetColor("_Color");
    }
}
