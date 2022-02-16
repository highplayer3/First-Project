using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private float h;
    private float v;
    public float speed;
    public float Rotatespeed;
    private Vector3 movement;

    //public Transform boat;
    //private float mouseX, mouseY;
    //public float mouseSensitivity;
    //private float xRotation;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    //void Update()
    //{
    //    mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    //    mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    //    xRotation -= mouseY;    //注意正负，不然镜头会与鼠标移动位置相反
    //    xRotation = Mathf.Clamp(xRotation, -90f, 90f);  //限制上下移动的范围
    //    boat.Rotate(Vector3.up * mouseX); //player以y轴为轴，以mouseX的角度来旋转
    //    transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    //}
    
    void FixedUpdate()
    {
        ///<summary>
        ///W,A,S,D的控制方式
        ///</summary>
        //h = Input.GetAxis("Horizontal");
        //v = Input.GetAxis("Vertical");
        //movement.Set(h, 0, v);
        //movement = movement.normalized * speed * Time.deltaTime;
        //m_rigidbody.MovePosition(transform.position + movement);
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var move = transform.right* speed * v * Time.deltaTime;
        m_rigidbody.MovePosition(transform.position - move);
        transform.Rotate(Vector3.up, h * Rotatespeed);
    }   
}
