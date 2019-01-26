﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceTrigger : MonoBehaviour
{
    public bool isTrigger = false;
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTrigger)
        {
            isTrigger = true;
            character.SetActive(true);
        }
    }
}
