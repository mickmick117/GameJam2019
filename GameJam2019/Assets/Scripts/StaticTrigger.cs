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

    private Animator RealAnim;

    void OnTriggerEnter(Collider hit)
    {
        prompt.text = displayText;
        isEnter = true;
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
            RealAnim = anim;
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        RealAnim.SetBool("open", true);

        prompt.text = "";
        isEnter = false;
    }
}
