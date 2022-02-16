using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCmove1 : MonoBehaviour
{
    private CharacterController cc;
    public float speed = 5f;
    public float Rotatespeed = 5f;
    public float Gravity;
    private Vector3 Velocity = Vector3.zero;
    void Start()
    {
        cc = transform.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveLikeWow();
        //MoveLikeChiJi();
    }
    /*魔兽世界的移动方式：W,S控制前进和后退，A,D控制转向*/
    private void MoveLikeWow()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");   //horizontal和vertical都是属于（-1,1）,控制前进还是后退

        var move = transform.forward * speed * vertical * Time.deltaTime; //每次移动的距离（前进和后退）
        cc.Move(move);
        transform.Rotate(Vector3.up, horizontal * Rotatespeed);

        Velocity.y -= Gravity * Time.deltaTime;
        cc.Move(Velocity * Time.deltaTime);
    }
    private void MoveLikeChiJi()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var direction = new Vector3(horizontal, 0, vertical).normalized;    //向量单位化
        var move = direction * speed * Time.deltaTime;
        cc.Move(move);

        //人物旋转部分
        var playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);//把物体在世界坐标的位置转化成屏幕坐标中
        var point = Input.mousePosition - playerScreenPoint;
        var angle = Mathf.Atan2(point.x, point.y) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
    }
}
