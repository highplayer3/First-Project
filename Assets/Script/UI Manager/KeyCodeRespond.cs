using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCodeRespond 
{
    public bool UI_Respond_ForG()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Close()
    {
        if (Input.anyKeyDown) return true;
        else return false;
    }
}
