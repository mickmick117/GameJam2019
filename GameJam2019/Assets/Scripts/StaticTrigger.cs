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

    Inventory inv;

    void OnTriggerEnter(Collider hit)
    {


        if (anim.GetBool("open") == false)
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
        inv = Inventory.instance;
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
    }
}
