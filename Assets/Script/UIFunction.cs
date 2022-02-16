using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIFunction : MonoBehaviour
{
    public Text text;
    public Text text01;
    private int fontSize;
    private Vector3 pos;

    public void Start()
    {
        fontSize = text.fontSize;//用fontSize来保存最开始的字体大小
        pos = new Vector3(text.transform.position.x, text.transform.position.y, text.transform.position.z);
    }
    public void ButtonFun()
    {
        text01.text = "<color=#00FF00>哈哈，你被骗了^_^</color>";  //#00FF00是绿色，注意格式
    }
    public void ToggleFun(Toggle toggle)
    {
        text.color = toggle.isOn ? Color.black : Color.red; //换颜色的一种方法
    }
    public void SliderFun(Slider slider)
    {
        float s = slider.value * 10f;
        text.fontSize = fontSize + Convert.ToInt32(s);
    }
    public void ScrollbarFun(Scrollbar scrollbar)
    {
        text.transform.position = new Vector3(pos.x, pos.y + scrollbar.value * 80f, pos.z);
    }
    public void DropdownFun(Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                text.fontStyle = FontStyle.Normal;
                break;
            case 1:
                text.fontStyle = FontStyle.Bold;
                break;
            case 2:
                text.fontStyle = FontStyle.Italic;
                break;
        }
    }
    public void InputFieldFun(InputField inputField)
    {
        text.text = inputField.text;
    }
}