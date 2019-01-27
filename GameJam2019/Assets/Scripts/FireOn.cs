using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FireOn : MonoBehaviour
{
    public string UnlockText;
    public Text prompt;

    bool isEnter = false;

    public GameObject f;
    public GameObject meuble1;
    public GameObject meuble2;

    void OnTriggerEnter(Collider hit)
    {
        prompt.text = UnlockText;
        isEnter = true;
    }

    void OnTriggerExit(Collider hit)
    {
        prompt.text = "";
        isEnter = false;
    }

    void activateFire()
    {
        f.SetActive(true);

        StartCoroutine(Burn());
    }

    private IEnumerator Burn()
    {
        yield return new WaitForSeconds(0.25f);
        f.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        
        //meuble1.SetActive(false);
        //meuble2.SetActive(false);
        f.SetActive(false);
        this.gameObject.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isEnter)
        {
            activateFire();
        }
    }
}
