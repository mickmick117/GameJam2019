using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StaticTrigger : MonoBehaviour
{
    public string displayText;
    public Text prompt;

    bool isEnter = false;

    public Animator anim;

    void OnTriggerEnter(Collider hit)
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            prompt.text = displayText;
            isEnter = true;
        }
    }

    void OnTriggerExit(Collider hit)
    {
        prompt.text = "";
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

        
        prompt.text = "";
        isEnter = false;
    }
}
