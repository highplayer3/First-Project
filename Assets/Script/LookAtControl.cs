using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtControl : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Sphere").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);
    }
}
