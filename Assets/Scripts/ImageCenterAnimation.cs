using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCenterAnimation : MonoBehaviour
{
    int direction = 1;
    public float speed = 100f;
    RectTransform rect;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * direction * Time.deltaTime*speed);
        if( transform.position.x - rect.rect.width/2 <= 0 || transform.position.x + rect.rect.width/2 >= Screen.width)
        {
            direction *= -1;
        }
    }
}
