using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Floating : MonoBehaviour
{
    //public Transform[] floaters;
    public float underWaterDrag = 3;
    public float underWaterAngularDrag = 1;
    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;

    public float floatingPower = 75f;

    public float waterHeight = -1f;
   
    Rigidbody m_Rigidbody;

    //int floatersUnderwater;

    bool underwater;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //floatersUnderwater = 0;
        //for (int i = 0; i < floaters.Length; i++)
        //{
            float difference = transform.position.y - waterHeight;

            if (difference < 0)
            {
                m_Rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), transform.position, ForceMode.Force);
                //floatersUnderwater += 1;
                if (!underwater)
                {
                    underwater = true;
                    SwithState(true);
                }
            }
        //}
        if (underwater)
        {
            underwater = false;
            SwithState(false);
        }
    }
    void SwithState(bool isUnderwater)
    {
        if (isUnderwater)
        {
            m_Rigidbody.drag = underWaterDrag;
            m_Rigidbody.angularDrag = underWaterAngularDrag;
        }
        else
        {
            m_Rigidbody.drag = airDrag;
            m_Rigidbody.angularDrag = airAngularDrag;
        }
    }
}
