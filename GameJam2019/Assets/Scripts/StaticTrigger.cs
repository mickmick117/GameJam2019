using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTrigger : MonoBehaviour
{
    bool hasCollided = false;
    public string referencetotext;

    void OnTriggerEnter(Collider hit)
    {
        referencetotext = "Necesito mas comida";
    }

    void OnTriggerExit(Collider hit)
    {
        referencetotext = "";
    }

    void OnTriggerExit(Collider hit)
    {
        hasCollided = false;

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
