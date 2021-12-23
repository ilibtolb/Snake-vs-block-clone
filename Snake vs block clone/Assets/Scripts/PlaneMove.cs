using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{

    public Transform plane;
    public float Speed;
    private bool StopButton;
    private bool BounceButton;
    private float timeDelta;

    private void Awake()
    {
        StopButton = true;
        BounceButton = false;
    }

    void Update()
    {
        if (StopButton)
        {
            plane.Translate((new Vector3(0, 0, -Speed) * Time.deltaTime));
        }
        if (BounceButton)
        {
            plane.Translate((new Vector3(0, 0, 2 * Speed) * Time.deltaTime));
            if (Time.time - timeDelta > 0.1)
            {
                BounceButton = false;
            }
        }
    }


    public void Stop()
    {
        StopButton = false;
    }

    public void Bounce()
    {
        BounceButton = true;
        timeDelta = Time.time;
    }
}
