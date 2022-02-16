using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTransform : MonoBehaviour
{
    public Transform door1;
    public Transform door2;
    public Transform playerCamera;
    private Vector3 vec;

    // Update is called once per frame
    void Update()
    {
        vec = playerCamera.position - door1.position;
        vec.y = 0;
        //print(vec);
        this.transform.position = door2.position + vec;

    }
}
