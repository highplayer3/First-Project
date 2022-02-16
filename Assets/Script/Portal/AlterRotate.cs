using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterRotate : MonoBehaviour
{
    public float speed = 200;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        if (x != 0 || y != 0)
        {
            RotateView(x, y);
        }
    }
    void RotateView(float x,float y)
    {
        x *= speed * Time.deltaTime;
        transform.Rotate(0, x, 0, Space.World);

        y *= speed * Time.deltaTime;
        transform.Rotate(-y, 0, 0);
    }
}
