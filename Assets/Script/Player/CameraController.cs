using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private float mouseX, mouseY;
    public float mouseSensitivity;
    public float xRotation;

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;    //注意正负，不然镜头会与鼠标移动位置相反
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  //限制上下移动的范围
        player.Rotate(Vector3.up * mouseX); //player以y轴为轴，以mouseX的角度来旋转
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
