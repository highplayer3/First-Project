using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ConstantForce bullet;
    private float PressedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            PressedTime += Time.deltaTime;
        }
        if(Input.GetButtonUp("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                ConstantForce BUT = Instantiate<ConstantForce>(bullet, ray.origin,
                    Quaternion.LookRotation(hit.point - ray.origin));
                BUT.relativeForce = new Vector3(0, 0, PressedTime * 10);
            }
            PressedTime = 0f;
        }
    }
}
