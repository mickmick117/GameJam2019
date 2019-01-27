using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTrap : MonoBehaviour
{
    Light light;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (light.isActiveAndEnabled)
        {
            gameObject.SetActive(false);
        }
    }
}
