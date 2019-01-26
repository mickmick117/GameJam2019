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
    public Renderer rend;
    public float outlineValue;

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
        
        rend.material.SetFloat("_Outline", outlineValue);
        //rend.material.SetVector("_OutlineColor", new Vector4(255.0f, 181.0f, 0.0f, 255.0f));
    }

    private void OnTriggerExit(Collider other)
    {
        txt.gameObject.SetActive(false);
        objectIsActive = false;
        rend.material.SetFloat("_Outline", 0.0f);
    }
}
