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
    public GameObject parent;

    public string NeedLighterString;

    Inventory inv;

    void OnTriggerEnter(Collider hit)
    {
        if (inv.items.Contains("Fire"))
        {
            prompt.text = UnlockText;
        }
        else
        {
            prompt.text = NeedLighterString;
        }
        
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
        yield return new WaitForSeconds(7.0f);
        f.SetActive(false);

        parent.gameObject.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
        inv = Inventory.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isEnter && inv.items.Contains("Fire"))
        {
            activateFire();
        }
    }
}
