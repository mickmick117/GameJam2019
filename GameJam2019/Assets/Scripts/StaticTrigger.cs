using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StaticTrigger : MonoBehaviour
{
    public string UnlockText;
    public Text prompt;

    bool isEnter = false;

    public Animator anim;

    public int numInvToWin;
    public GameObject door;

    private Inventory inv;

    void OnTriggerEnter(Collider hit)
    {
        if( inv != null)
        {
            if(door.tag == "all")
            {
                if(inv.itemKeys.Count >= numInvToWin)
                {
                    if (anim.GetBool("open") == false)
                    {
                        prompt.text = UnlockText;
                        isEnter = true;
                    }
                }
            }
            else if(true/*inv.itemKeys.Contains(door.tag)*/)
            {
                if (anim.GetBool("open") == false)
                {
                    prompt.text = UnlockText;
                    isEnter = true;
                }
            }
            else
            {
                prompt.text = "You need " + door.tag + " item to open this door";
            }           
        }
        else
        {
            prompt.text = "Inventory is NULL";
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
