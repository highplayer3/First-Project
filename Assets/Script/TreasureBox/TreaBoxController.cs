using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreaBoxController : MonoBehaviour
{
    public Text remind_forTRBox;
    private bool isUIOpen;
    private bool isBoxOpen;
    [Header("控制箱子动画")]
    private Animator anim;
    private float time;
    private AudioSource sound;
    private void OnTriggerEnter(Collider other)
    {
        remind_forTRBox.enabled = true;
        isUIOpen = true;
    }
    private void OnTriggerStay(Collider other)
    {
        remind_forTRBox.enabled = true;
    }
    private void OnTriggerExit(Collider other)
    {
        remind_forTRBox.enabled = false;
        isUIOpen = false;
    }
    private void Start()
    {
        anim = GetComponentInParent<Animator>();
        sound = GetComponentInParent<AudioSource>();
        isBoxOpen = false;
    }
    private void Update()
    {
        if (isBoxOpen)
        {
            time += Time.deltaTime;
        }
        Respond_ForOpen();
        Respond_ForClose();

    }
    void Respond_ForOpen()
    {
        if (isUIOpen && Input.GetKeyDown(KeyCode.E))
        {
            anim.SetInteger("State", 1);
            isBoxOpen = true;
            sound.Play();
        }
    }
    void Respond_ForClose()
    {
        if (isUIOpen && isBoxOpen && Input.GetKeyDown(KeyCode.E) && time > 2.0f)
        {
            anim.SetInteger("State", 2);
            isBoxOpen = false;
            time = 0;
            anim.SetTrigger("Reset");
            sound.Play();
        }
    }
}
