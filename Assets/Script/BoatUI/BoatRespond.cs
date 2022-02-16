using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatRespond : MonoBehaviour
{
    public Text Boat_Text;
    public bool isOnUI;
    public bool isOnBoat=false;
    private float time;
    private GameObject player;
    private Transform location;
    public Transform InitialPos;
    private BoatMove bm;
    private void Start()
    {
        location = transform.GetChild(4);
        bm = GetComponent<BoatMove>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Boat_Text.enabled = true;
            isOnUI = true;
            player = other.gameObject;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Boat_Text.enabled = true;
            isOnUI = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Boat_Text.enabled = false;
            isOnUI = false;
        }
    }
    private void Update()
    {
        EmbarkOn();
        if (isOnBoat)
        {
            time += Time.deltaTime;
        }
        Disembark();
    }
    //上船
    void EmbarkOn()
    {
        if (isOnUI && Input.GetKeyDown(KeyCode.E))
        {
            player.transform.SetParent(location, false);
            isOnBoat = true;
            player.GetComponent<PlayerController>().enabled = false;
            player.transform.localPosition = new Vector3(0, 0.8f, 0);
            //player.transform.localRotation = Quaternion.Euler(0, -83f, 0);
            bm.enabled = true;
        }
    }
    //下船
    void Disembark()
    {
        if (isOnBoat && isOnUI && Input.GetKeyDown(KeyCode.E)&&time>1.5f)
        {
            player.transform.SetParent(InitialPos, true);
            isOnBoat = false;
            isOnUI = false;
            player.GetComponent<PlayerController>().enabled = true;
            time = 0f;
            bm.enabled = false;
        }
    }
}
