using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalView : MonoBehaviour
{
    private GameObject Alter;
    private AlterRotate scr;
    private Vector3 Pos;
    private void Awake()
    {
        Alter = GameObject.Find("alternativePlayer");
        if (Alter != null)
        {
            scr = Alter.GetComponentInChildren<AlterRotate>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        print("进入到传送门的范围");
        if (other.gameObject.CompareTag("Player"))
        {
            Alter.GetComponent<ViewTransform>().enabled = true;
            scr.enabled = true;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = Alter.transform.position;
            //Alter.transform.position = transform.position;
        }
    }
}
