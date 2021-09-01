using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCenterAnimation : MonoBehaviour
{
    int direction = 1;//направление движения
    public float speed = 100f;//скорость
    RectTransform rect;//прямоугольник для трансформа
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * direction * Time.deltaTime*speed);//перемещаем
        if( transform.position.x - rect.rect.width/2 <= 0 || transform.position.x + rect.rect.width/2 >= Screen.width)
        {//если дошли до края, меняем направление
            direction *= -1;
        }
    }
}
