using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreepyFrameTrigger : MonoBehaviour
{
    public Renderer rendoror;
    private bool isTriggering = false;
    private float timeleft = 3.0f;
    private bool rotatesLeft = false;

    private bool isSimonaquementBruyant = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isSimonaquementBruyant)
        {
            isSimonaquementBruyant = true;
            GetComponent<AudioSource>().Play();
        }

        if (timeleft > 0)
        {
            isTriggering = true;
        }
    }

    private void Update()
    {
        if (isTriggering)
        {
            timeleft -= Time.deltaTime;
            if (rotatesLeft)
            {
                rotatesLeft = false;
                rendoror.transform.Rotate(new Vector3(1, 0, 0) * 8);
            }
            else
            {
                rotatesLeft = true;
                rendoror.transform.Rotate(new Vector3(-1, 0, 0) * 8);
            }

            if (timeleft < 1.0f)
            {
                isTriggering = false;
            }
        }
    }
}
