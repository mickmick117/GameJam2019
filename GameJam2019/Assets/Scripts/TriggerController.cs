using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerController : MonoBehaviour
{
    public Text txt;
    public GameObject pickupObject;
    public int keyID;
    public string textToShow;
    bool objectIsActive = false;


    private void Start()
    {
        txt.text = textToShow;
    }

    void Update()
    {
        if (Input.GetKeyDown("f") && objectIsActive)
        {
            pickupObject.SetActive(false);
            Inventory.instance.addKey(keyID);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        txt.gameObject.SetActive(true);
        objectIsActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        txt.gameObject.SetActive(false);
        objectIsActive = false;
    }
}
