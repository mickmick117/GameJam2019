using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreepyFrameTrigger : MonoBehaviour
{
    public Renderer rendoror;
    private bool isTriggering = false;
    private float timeleft = 300.0f; 

    private void OnTriggerEnter(Collider other)
    {
        if (timeleft > 0)
        {
            isTriggering = true;
            // TODO: make the frame shake
        }
    }

    private void Update()
    {
        if(isTriggering)
        {
            timeleft -= Time.deltaTime;
            if (timeleft % 2 == 0)
            {
                rendoror.transform.Rotate(new Vector3(1, 0, 0));
            }
            else
            {
                rendoror.transform.Rotate(new Vector3(-1, 0, 0));
            }
                
            if (timeleft < 1.0f)
            {
                isTriggering = false;
            }
        }
    }
}
