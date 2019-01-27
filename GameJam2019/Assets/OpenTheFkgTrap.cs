using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheFkgTrap : MonoBehaviour
{
    public Light light;

    // Start is called before the first frame update
    void Start()
    {
        light.gameObject.SetActive(false);
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
