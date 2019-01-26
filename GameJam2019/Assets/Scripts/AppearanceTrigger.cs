using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceTrigger : MonoBehaviour
{
    public bool isTrigger = false;
    public GameObject monster;
    public Light light;

    // Start is called before the first frame update
    void Start()
    {
        monster.SetActive(false);
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
            light.enabled = false;
            GetComponent<AudioSource>().Play();
            monster.SetActive(true);
            StartCoroutine(HideCharacter());
        }
    }

    private IEnumerator HideCharacter()
    {
        yield return new WaitForSeconds(0.25f);
        light.enabled = true;
        yield return new WaitForSeconds(0.25f);
        light.enabled = false;
        yield return new WaitForSeconds(0.20f);
        light.enabled = true;
        yield return new WaitForSeconds(0.05f);
        light.enabled = false;
        yield return new WaitForSeconds(0.20f);
        monster.SetActive(false);
        light.enabled = true;
    }
}
