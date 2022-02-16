using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoveWithTime : MonoBehaviour
{
    public float movespeed;
    private int time = System.DateTime.Now.Hour;
    private Light light;
    private float ReTime;
    //private int degree;
    // Start is called before the first frame update
    void Start()
    {
        light = GameObject.Find("Directional Light").GetComponent<Light>();
        //degree = Random.Range(0, 360);
        //transform.Rotate(degree, 0, 0);
        if (0 <= time && time <= 6)
        {
            light.intensity = 0.2f;
        }else if (7 <= time && time <= 12)
        {
            light.intensity = 1.7f;
            //light.color =new Color(209, 175, 43, 255);
        }else if (13 <= time && time <= 15)
        {
            light.intensity = 1.8f;
        }
        else
        {
            light.intensity = 0.6f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ReTime++;
        transform.Rotate(-movespeed * Time.deltaTime,0,0);
        if (0 <= time && time <= 6)
        {
            if (ReTime == 1800)
            {
                light.intensity += 0.02f;
                ReTime = 0;
            }
        }else if (7 <= time && time <= 12)
        {
            if (ReTime == 1800)
            {
                light.intensity += 0.05f;
                ReTime = 0;
            }
        }else if(13 <= time && time <= 15)
        {
            if (ReTime == 1800)
            {
                light.intensity += 0.05f;
                ReTime = 0;
            }
        }else if (time >= 20)
        {
            if (ReTime == 600 && light.intensity > 0)
            {
                light.intensity -= 0.02f;
                ReTime = 0;
            }
        }
    }
}
