using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIControllerScript : MonoBehaviour
{
    private float redValue;//�������� ��� �������� �����
    private float greenValue;//�������� �������
    private float blueValue;//�������� ������
    private ColoredInterface cos;//������ ������� ��� ��������� �����

    private GameObject target;//������ ���������
    public Slider greenSlider;//������� ��� �������
    public Text redValueText;//����� ��� ��������
    public Text blueValueText;//����� ��� ������
    public Text greenValueText;//����� ��� �������

    PointerEventData pointerEventData;//���������� �� ������� ����
    public EventSystem eventSystem;//��������� �������

    void Update()
    {
        if (Input.GetMouseButton(0))
        {//��� ������� ������ ����
            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            eventSystem.RaycastAll(pointerEventData, results);//�������� ����� (���������� � �����������)
            if (!results[0].Equals(null)  && results[0].gameObject.CompareTag("Colored"))
            {//���� ������ � � ������ �������
                target = results[0].gameObject;//�������� ���
                cos = target.GetComponent<ColoredInterface>();//���� ��� ������
            }
        }
        if (target != null)
        {//���� ������ ������
            Color currentColor = cos.GetColor();//�������� ��� ����
            redValue = currentColor.r;//��������� ��������
            greenValue = currentColor.g;
            blueValue = currentColor.b;
            redValueText.text = ((int)(redValue * 255)).ToString();//������� ��������
            blueValueText.text = ((int)(blueValue * 255)).ToString();
            greenValueText.text = ((int)(greenValue * 255)).ToString();
            greenSlider.value = greenValue;
        }
    }

    public void BlueButtonClick()
    {//������� ������ ��� ������
        if (target != null)
        {//���� ������ ������
            blueValue = Random.value;//������ ����������� ��������� ��������
            cos.ChangeRGB(redValue, greenValue, blueValue);//��������� ����
        }
    }

    public void RedPlusClick()
    {//������� ������ + ��� ��������
        if (redValue < 1f && target != null)
        {//���� ����� ��������� � ���� ������ ������
            redValue = redValue + (float) 1 / 256;//����������
            cos.ChangeRGB(redValue, greenValue, blueValue);//���������
        }
    }
    public void RedMinusClick()
    {//������� ������ - ��� ��������
        if (redValue > 0f && target != null)
        {//���� ����� ������� � ���� ������ ������
            redValue = redValue - (float) 1 / 256;//��������
            cos.ChangeRGB(redValue, greenValue, blueValue);//���������
        }
    }

    public void GreenChange()
    { //��������� �������� �������� ��� �������
        if (target != null)
        {//���� ������ ������
            greenValue = greenSlider.value;//��� ������� ������� �������� ��������
            cos.ChangeRGB(redValue, greenValue, blueValue);//��������
        }
    }

}
