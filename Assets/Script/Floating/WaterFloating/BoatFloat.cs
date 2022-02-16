using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatFloat : MonoBehaviour
{
    public bool isInWater;
    private GameObject water;
    private float waterY;
    private float floatingPower = 0;
    public float density = 1;
    public float g = 9.8f;
    public float waterDrag = 5;
    private Rigidbody m_rigidbody;
         

    // Start is called before the first frame update
    void Start()
    {
        isInWater = false;
        water = GameObject.FindWithTag("water");
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isInWater)
        {
            calculateFloating();
            m_rigidbody.drag = waterDrag;
        }
    }
    void calculateFloating()
    {
        waterY = water.transform.position.y;
        if (waterY > (transform.position.y - transform.localScale.y))
        {
            float h = waterY - (transform.position.y - transform.localScale.y / 2) > transform.localScale.y ? transform.localScale.y : waterY - (transform.position.y - transform.localScale.y / 2);
            float floatingPower = density * g * transform.localScale.x * transform.localScale.z * h;
            m_rigidbody.AddForce(0, floatingPower, 0);
        }
    }

}
