using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ColoredInterface
{//интерфейс для объекта, у которого будем менять цвет
    public void ChangeRGB(float r, float g, float b);
    public Color GetColor();
}
