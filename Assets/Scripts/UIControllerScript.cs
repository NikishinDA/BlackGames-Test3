using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIControllerScript : MonoBehaviour
{
    private float redValue;//значение для красного цвета
    private float greenValue;//значение зелёного
    private float blueValue;//значение синиго
    private ColoredInterface cos;//скрипт объекта для изменения цвета

    private GameObject target;//объект изменения
    public Slider greenSlider;//слайдер для зелёного
    public Text redValueText;//текст для красного
    public Text blueValueText;//текст для синего
    public Text greenValueText;//текст для зелёного

    PointerEventData pointerEventData;//информация об ивентах мыши
    public EventSystem eventSystem;//ивентовая система

    void Update()
    {
        if (Input.GetMouseButton(0))
        {//при нажатии кнопки мыши
            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            eventSystem.RaycastAll(pointerEventData, results);//стреляем лучом (физическим и графическим)
            if (!results[0].Equals(null)  && results[0].gameObject.CompareTag("Colored"))
            {//если попали и в нужный объекта
                target = results[0].gameObject;//выбираем его
                cos = target.GetComponent<ColoredInterface>();//берём его скрипт
            }
        }
        if (target != null)
        {//если объект выбран
            Color currentColor = cos.GetColor();//получаем его цвет
            redValue = currentColor.r;//обновляем значения
            greenValue = currentColor.g;
            blueValue = currentColor.b;
            redValueText.text = ((int)(redValue * 255)).ToString();//выводим значения
            blueValueText.text = ((int)(blueValue * 255)).ToString();
            greenValueText.text = ((int)(greenValue * 255)).ToString();
            greenSlider.value = greenValue;
        }
    }

    public void BlueButtonClick()
    {//нажатие кнопки для синего
        if (target != null)
        {//если выбран объект
            blueValue = Random.value;//синему присваиваем случайное значение
            cos.ChangeRGB(redValue, greenValue, blueValue);//обновляем цвет
        }
    }

    public void RedPlusClick()
    {//нажатие кнопки + для красного
        if (redValue < 1f && target != null)
        {//если можно увеличить и если выбран объект
            redValue = redValue + (float) 1 / 256;//прибавляем
            cos.ChangeRGB(redValue, greenValue, blueValue);//обновляем
        }
    }
    public void RedMinusClick()
    {//нажатие кнопки - для красного
        if (redValue > 0f && target != null)
        {//если можно убавить и если выбран объект
            redValue = redValue - (float) 1 / 256;//убавляем
            cos.ChangeRGB(redValue, greenValue, blueValue);//обновляем
        }
    }

    public void GreenChange()
    { //изменение значения слайдера для зелёного
        if (target != null)
        {//если выбран объект
            greenValue = greenSlider.value;//для зелёного приянть значение слайдера
            cos.ChangeRGB(redValue, greenValue, blueValue);//обновить
        }
    }

}
