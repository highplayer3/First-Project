using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
/*有CharacterController，Rigidbody会失效，所以要手动写重力效果*/
public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    public float movespeed;
    public float jumpspeed;
    private float horizontalMove, verticalMove;
    private Vector3 direction;
    //重力代码
    public float gravity;
    private Vector3 velocity; //y轴加速度
    //检测是否在地和靠近NPC
    public Transform NPCCheck;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;//检测的层级
    public LayerMask NPCLayer;
    public bool isGround;
    public bool FindNPC;
    //UI
    public Text remindText;
    public Image textBox;
    private bool isUIOpen;
    private bool isTextBoxOpen=false;
    private Image paper01;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        paper01 = GameObject.Find("PaperImage01").GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        Shift_Respond();
        RespondForG();
        Close_TextBox();
        FindNPC = Physics.CheckSphere(NPCCheck.position, 1.0f, NPCLayer);
        if(!FindNPC)
        {
            remindText.enabled = false;
            isUIOpen = false;
            //print("检测到NPC");
        }
            
        isGround = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);
        if (isGround && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        horizontalMove = Input.GetAxis("Horizontal") * movespeed;
        verticalMove = Input.GetAxis("Vertical") * movespeed;
        direction = transform.forward * verticalMove + transform.right * horizontalMove;
        characterController.Move(direction * Time.deltaTime);
        //自由落体效果
        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        if (Input.GetButtonDown("Jump")&&isGround)
        {
            velocity.y = jumpspeed;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("NPC"))
        {
            remindText.enabled = true;
            isUIOpen = true;
            //print("OnControllerColliderHit调用（与NPC）");
        }
    }
    //按“G”执行对话
    void RespondForG()
    {
        if (isUIOpen && Input.GetKeyDown(KeyCode.G))
        {
            textBox.GetComponentInChildren<Text>().enabled = true;
            textBox.enabled = true;
            isTextBoxOpen = true;
            isUIOpen = false;
            remindText.enabled = false;
        }
    }
    //关闭对话框
    void Close_TextBox()
    {
        if (isTextBoxOpen&&Input.GetKeyDown(KeyCode.C))
        {
            textBox.GetComponentInChildren<Text>().enabled = false;
            textBox.enabled = false;
            isTextBoxOpen = false;
            Invoke("OpenHideUI", 5f);
        }
    }
    //调用隐藏提示对话框
    void OpenHideUI()
    {
        paper01.enabled = true;
        paper01.GetComponentInChildren<GraduallyDisplay>().enabled = true;
        paper01.GetComponentInChildren<Text>().enabled = true;
    }
    //按Shift加快人物移速
    void Shift_Respond()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            movespeed = 6;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            movespeed = 3;
        }
    }
}   
