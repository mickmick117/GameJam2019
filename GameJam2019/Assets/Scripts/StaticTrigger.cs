using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StaticTrigger : MonoBehaviour
{
    public string displayText;
    public Text prompt;

    bool isEnter = false;
    bool isOpen = false;

    public Animator anim;

    void OnTriggerEnter(Collider hit)
    {
        if (!isOpen)
        {
            prompt.text = displayText;
            isEnter = true;
        }
    }

    void OnTriggerExit(Collider hit)
    {
        prompt.text = "";
        isEnter = false;
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isEnter)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        anim.SetBool("open", true);

        isOpen = true;
        prompt.text = "";
    }
}
