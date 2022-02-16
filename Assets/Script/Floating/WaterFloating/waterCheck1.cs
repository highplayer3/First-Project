using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterCheck1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BoatFloat>())
        {
            other.gameObject.GetComponent<BoatFloat>().isInWater = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<BoatFloat>())
        {
            other.gameObject.GetComponent<BoatFloat>().isInWater = false;
        }
    }
}
