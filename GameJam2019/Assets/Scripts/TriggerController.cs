using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerController : MonoBehaviour
{
    public Text txt;

    public string textToShow;

    private void Start()
    {
        txt.text = textToShow;
    }

    private void OnTriggerEnter(Collider other)
    {
        txt.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        txt.gameObject.SetActive(false);
    }
}
