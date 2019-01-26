using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StaticTrigger : MonoBehaviour
{
    public string UnlockText;
    public string LockText;
    public Text prompt;

    bool isEnter = false;

    public Animator anim;

    public int numInvToWin;

    private Inventory inv;

    void OnTriggerEnter(Collider hit)
    {
        if( inv != null && inv.itemKeys.Count >= numInvToWin)
        {
            if (anim.GetBool("open") == false)
            {
                prompt.text = UnlockText;
                isEnter = true;
            }
        }
        else
        {
            prompt.text = "You need " + LockText;
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
